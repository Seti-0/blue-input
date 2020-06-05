using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;
using Duality.Editor;
using Duality.Input;

namespace Soulstone.Duality.Plugins.BlueInput.Testing
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class InputEventTest : Component, ICmpUpdatable, ICmpMouseListener, ICmpMouseWheelListener, ICmpMouseDragListener, ICmpKeyListener, ICmpResizeListener
    {
        public float LongLifeTime { get; set; } = 1000;

        private class Entry
        {
            public double CreationTimeMillis;
            public string Content;
            public ColorRgba Color;
        }

        private class QuickEntry
        {
            public string Content;
            public ColorRgba Color;
        }

        [DontSerialize] private Dictionary<int, Entry> _entries = new Dictionary<int, Entry>();
        [DontSerialize] private Dictionary<int, QuickEntry> _quickEntries = new Dictionary<int, QuickEntry>();
        [DontSerialize] private Dictionary<int, int> _duplicates = new Dictionary<int, int>();

        private bool CheckDuplicate(int channel)
        {
            if (_entries.ContainsKey(channel) || _quickEntries.ContainsKey(channel))
            {
                if (_duplicates.ContainsKey(channel))
                    _duplicates[channel] += 1;

                else _duplicates.Add(channel, 1);

                return true;
            }

            return false;
        }

        private void AddQuick(string content, ColorRgba color, int channel)
        {
            if (CheckDuplicate(channel))
                return;

            _quickEntries.Add(channel,
                new QuickEntry
                {
                    Content = content,
                    Color = color
                }
            );
        }

        private void Add(string content, ColorRgba color, int channel)
        {
            if (CheckDuplicate(channel))
                return;

            _entries.Add(channel,
                new Entry
                {
                    Content = content,
                    Color = color,
                    CreationTimeMillis = Time.MainTimer.TotalMilliseconds
                }
            );
        }

        public void OnUpdate()
        {
            float x = 50;
            float y = DualityApp.WindowSize.Y - 100;

            float stepY = -50;

            foreach (var pair in _quickEntries)
            {
                var channel = pair.Key;
                var entry = pair.Value;

                string text = entry.Content;
                if (_duplicates.ContainsKey(channel))
                {
                    text += $" (+{_duplicates[channel]})";
                    _duplicates.Remove(channel);
                }

                VisualLogs.Default
                    .DrawText(x, y + stepY * channel, text)
                    .WithColor(entry.Color);
            }

            _quickEntries.Clear();

            var channels = _entries.Keys.ToArray();
            foreach (var channel in channels)
            {
                var entry = _entries[channel];

                bool end = Time.MainTimer.TotalMilliseconds - entry.CreationTimeMillis > LongLifeTime;
                bool duplicates = _duplicates.ContainsKey(channel);

                if (end)
                {
                    if (duplicates)
                    {
                        _duplicates[channel] -= 1;
                        if (_duplicates[channel] == 0)
                            _duplicates.Remove(channel);
                    }

                    _entries.Remove(channel);
                }

                else
                {
                    string text = entry.Content;
                    if (duplicates)
                        text += $" (+{_duplicates[channel]})";

                    VisualLogs.Default
                        .DrawText(x, y + stepY * channel, text)
                        .WithColor(entry.Color)
                        .KeepAlive(LongLifeTime, false);
                }
            }
        }

        public void OnAvailable(EventArgs e)
        {
            Add("Keyboard Available", ColorRgba.Green, 0);
        }

        public void OnNoLongerAvailable(EventArgs e)
        {
            Add("Keyboard no longer available", ColorRgba.Red, 1);
        }

        public void OnMouseEnter(EventArgs e)
        {
            var color = ColorRgba.Green;

            Add("Mouse enter", color, 2);

            VisualLogs.Default
                .DrawPoint(DualityApp.Mouse.Pos)
                .WithColor(color)
                .KeepAlive(LongLifeTime, false);
        }

        public void OnMouseExit(EventArgs e)
        {
            var color = ColorRgba.Red;

            Add("Mouse exit", color, 3);

            VisualLogs.Default
                .DrawPoint(DualityApp.Mouse.Pos)
                .WithColor(color)
                .KeepAlive(LongLifeTime, false);
        }

        public void OnMove(MouseMoveEventArgs e)
        {
            var color = ColorRgba.Grey;

            AddQuick("Mouse move", color, 4);

            VisualLogs.Default
                .DrawPoint(e.Pos)
                .WithColor(color);

            VisualLogs.Default
                .DrawVector(e.Pos, DualityApp.Mouse.Vel)
                .WithColor(ColorRgba.DarkGrey);
        }

        public void OnButtonDown(MouseButtonEventArgs e)
        {
            var color = ColorRgba.Blue;

            Add($"Button Down: {e.Button}", color, 5);

            VisualLogs.Default
                .DrawPoint(e.Pos)
                .WithColor(color)
                .KeepAlive(LongLifeTime, false);
        }

        public void OnButtonUp(MouseButtonEventArgs e)
        {
            var color = ColorRgba.Green;

            Add($"Button Up: {e.Button}", color, 6);

            VisualLogs.Default
                .DrawPoint(e.Pos)
                .WithColor(color)
                .KeepAlive(LongLifeTime, false);
        }

        public void OnDragStart(MouseDragEventArgs e)
        {
            var color = ColorRgba.Blue;

            Add($"Drag start", color, 7);

            VisualLogs.Default
                .DrawPoint(e.Pos)
                .WithColor(color)
                .KeepAlive(LongLifeTime, false);
        }

        public void OnDragContinue(MouseDragEventArgs e)
        {
            var color = ColorRgba.Blue;

            AddQuick($"Drag Continue", color, 8);

            VisualLogs.Default
                .DrawPoint(e.Pos)
                .WithColor(color);

            VisualLogs.Default
                .DrawPoint(e.Origin)
                .WithColor(color);

            VisualLogs.Default
                .DrawVector(e.Origin, e.Pos - e.Origin)
                .WithColor(ColorRgba.Grey);
        }

        public void OnDragEnd(MouseDragEventArgs e)
        {
            var color = ColorRgba.Green;

            Add($"Drag end", color, 9);

            VisualLogs.Default
                .DrawPoint(e.Pos)
                .WithColor(color)
                .KeepAlive(LongLifeTime, false);
        }

        public void OnKeyDown(KeyboardKeyEventArgs e)
        {
            Add($"Key down: {e.Key}", ColorRgba.Blue, 10);
        }

        public void OnKeyUp(KeyboardKeyEventArgs e)
        {
            Add($"Key up: {e.Key}", ColorRgba.Green, 11);
        }

        public void OnWheelChanged(MouseWheelEventArgs e)
        {
            Add($"Wheel changed: (x = {e.WheelValue}, v = {e.WheelSpeed})", ColorRgba.LightGrey, 12);
        }

        public void OnWindowSizeChanged(ResizeEventArgs e)
        {
            Add($"Resize: (old = {e.OldSize}, new = {e.NewSize})", ColorRgba.LightGrey, 13);
        }
    }
}
