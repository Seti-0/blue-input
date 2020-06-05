<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="494095774">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1912476936">
        <_items dataType="Array" type="Duality.Component[]" id="2805379948">
          <item dataType="Struct" type="Duality.Components.Transform" id="551372992">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">494095774</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="2040482251">
            <active dataType="Bool">true</active>
            <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">494095774</gameobj>
            <nearZ dataType="Float">50</nearZ>
            <priority dataType="Int">0</priority>
            <projection dataType="Enum" type="Duality.Drawing.ProjectionMode" name="Screen" value="2" />
            <renderSetup dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderSetup]]" />
            <renderTarget dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
            <shaderParameters dataType="Struct" type="Duality.Drawing.ShaderParameterCollection" id="2459254343" custom="true">
              <body />
            </shaderParameters>
            <targetRect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">1</H>
              <W dataType="Float">1</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </targetRect>
            <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
          </item>
          <item dataType="Struct" type="Duality.Components.VelocityTracker" id="2565230241">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">494095774</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.SoundListener" id="2526748301">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">494095774</gameobj>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1881948126" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3736283082">
            <item dataType="Type" id="4265998688" value="Duality.Components.Transform" />
            <item dataType="Type" id="2884588686" value="Duality.Components.VelocityTracker" />
            <item dataType="Type" id="1204300668" value="Duality.Components.Camera" />
            <item dataType="Type" id="2098613010" value="Duality.Components.SoundListener" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1721766042">
            <item dataType="ObjectRef">551372992</item>
            <item dataType="ObjectRef">2565230241</item>
            <item dataType="ObjectRef">2040482251</item>
            <item dataType="ObjectRef">2526748301</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">551372992</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2515342122">TLJlPmLs+U+hFiPjVuyMvA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">MainCamera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="790557846">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="3856503488">
        <_items dataType="Array" type="Duality.GameObject[]" id="718099740" length="8">
          <item dataType="Struct" type="Duality.GameObject" id="1064589658">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="4205310522">
              <_items dataType="Array" type="Duality.Component[]" id="37633280" length="4">
                <item dataType="Struct" type="Soulstone.Duality.Plugins.BlueInput.Testing.SelectionTest" id="3885856518">
                  <_messageContent />
                  <_messageTime dataType="Double">0</_messageTime>
                  <_x003C_Color_x003E_k__BackingField dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">0</B>
                    <G dataType="Byte">0</G>
                    <R dataType="Byte">255</R>
                  </_x003C_Color_x003E_k__BackingField>
                  <_x003C_FreezeOnDrag_x003E_k__BackingField dataType="Bool">false</_x003C_FreezeOnDrag_x003E_k__BackingField>
                  <_x003C_MessageChannel_x003E_k__BackingField dataType="Int">1</_x003C_MessageChannel_x003E_k__BackingField>
                  <_x003C_MessageLifetime_x003E_k__BackingField dataType="Float">1E+10</_x003C_MessageLifetime_x003E_k__BackingField>
                  <_x003C_SelectionTrigger_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.BlueInput.Selection.SelectionTrigger" name="MouseDown" value="1" />
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">1064589658</gameobj>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="140083898" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="3076666752">
                  <item dataType="Type" id="3220268444" value="Soulstone.Duality.Plugins.BlueInput.Testing.SelectionTest" />
                </keys>
                <values dataType="Array" type="System.Object[]" id="2324601038">
                  <item dataType="ObjectRef">3885856518</item>
                </values>
              </body>
            </compMap>
            <compTransform />
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="3569402652">EFxup8chH0u6vbnMFCjmrQ==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">SelectionTestDown</name>
            <parent dataType="ObjectRef">790557846</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="248901068">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1892163580">
              <_items dataType="Array" type="Duality.Component[]" id="1984246596" length="4">
                <item dataType="Struct" type="Soulstone.Duality.Plugins.BlueInput.Testing.MouseFocusTest" id="3130969853">
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">248901068</gameobj>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1229944726" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="3850288470">
                  <item dataType="Type" id="2386947616" value="Soulstone.Duality.Plugins.BlueInput.Testing.MouseFocusTest" />
                </keys>
                <values dataType="Array" type="System.Object[]" id="1957478618">
                  <item dataType="ObjectRef">3130969853</item>
                </values>
              </body>
            </compMap>
            <compTransform />
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="3711538550">3KWhHFZsi0GU9Sy3onU+3w==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">MouseFocusTest</name>
            <parent dataType="ObjectRef">790557846</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="1514197647">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="832918451">
              <_items dataType="Array" type="Duality.Component[]" id="1358373414" length="4">
                <item dataType="Struct" type="Soulstone.Duality.Plugins.BlueInput.Testing.InputEventTest" id="1072927431">
                  <_x003C_LongLifeTime_x003E_k__BackingField dataType="Float">1000</_x003C_LongLifeTime_x003E_k__BackingField>
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">1514197647</gameobj>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1348511928" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="52306393">
                  <item dataType="Type" id="1752033742" value="Soulstone.Duality.Plugins.BlueInput.Testing.InputEventTest" />
                </keys>
                <values dataType="Array" type="System.Object[]" id="2341743104">
                  <item dataType="ObjectRef">1072927431</item>
                </values>
              </body>
            </compMap>
            <compTransform />
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="2845136027">/jZTNoihg0CHkeZU01jC/w==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">InputEventTest</name>
            <parent dataType="ObjectRef">790557846</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="2563092514">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1442955922">
              <_items dataType="Array" type="Duality.Component[]" id="577321040" length="4">
                <item dataType="Struct" type="Soulstone.Duality.Plugins.BlueInput.Testing.SelectionTest" id="1089392078">
                  <_messageContent />
                  <_messageTime dataType="Double">0</_messageTime>
                  <_x003C_Color_x003E_k__BackingField dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">248</B>
                    <G dataType="Byte">123</G>
                    <R dataType="Byte">236</R>
                  </_x003C_Color_x003E_k__BackingField>
                  <_x003C_FreezeOnDrag_x003E_k__BackingField dataType="Bool">false</_x003C_FreezeOnDrag_x003E_k__BackingField>
                  <_x003C_MessageChannel_x003E_k__BackingField dataType="Int">2</_x003C_MessageChannel_x003E_k__BackingField>
                  <_x003C_MessageLifetime_x003E_k__BackingField dataType="Float">1E+10</_x003C_MessageLifetime_x003E_k__BackingField>
                  <_x003C_SelectionTrigger_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.BlueInput.Selection.SelectionTrigger" name="MouseUp" value="0" />
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">2563092514</gameobj>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2932946378" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="1521596616">
                  <item dataType="ObjectRef">3220268444</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="616325854">
                  <item dataType="ObjectRef">1089392078</item>
                </values>
              </body>
            </compMap>
            <compTransform />
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="583781684">feYtJlFAFECCkLAw39KdCw==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">SelectionTestUp</name>
            <parent dataType="ObjectRef">790557846</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="1750737594">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3809133402">
              <_items dataType="Array" type="Duality.Component[]" id="2090635776" length="4">
                <item dataType="Struct" type="Soulstone.Duality.Plugins.BlueInput.Testing.SelectionTest" id="277037158">
                  <_messageContent />
                  <_messageTime dataType="Double">0</_messageTime>
                  <_x003C_Color_x003E_k__BackingField dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">236</B>
                    <G dataType="Byte">96</G>
                    <R dataType="Byte">106</R>
                  </_x003C_Color_x003E_k__BackingField>
                  <_x003C_FreezeOnDrag_x003E_k__BackingField dataType="Bool">false</_x003C_FreezeOnDrag_x003E_k__BackingField>
                  <_x003C_MessageChannel_x003E_k__BackingField dataType="Int">0</_x003C_MessageChannel_x003E_k__BackingField>
                  <_x003C_MessageLifetime_x003E_k__BackingField dataType="Float">1E+10</_x003C_MessageLifetime_x003E_k__BackingField>
                  <_x003C_SelectionTrigger_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.BlueInput.Selection.SelectionTrigger" name="MouseOver" value="2" />
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">1750737594</gameobj>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="103746490" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="1381479584">
                  <item dataType="ObjectRef">3220268444</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="770795662">
                  <item dataType="ObjectRef">277037158</item>
                </values>
              </body>
            </compMap>
            <compTransform />
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="2832263356">tubyM0eyEkORZ38IyPA1rw==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">SelectionTestOver</name>
            <parent dataType="ObjectRef">790557846</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="3768439271">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="881067163">
              <_items dataType="Array" type="Duality.Component[]" id="3708067734" length="4">
                <item dataType="Struct" type="Soulstone.Duality.Plugins.BlueInput.Testing.SelectionTest" id="2294738835">
                  <_messageContent />
                  <_messageTime dataType="Double">0</_messageTime>
                  <_x003C_Color_x003E_k__BackingField dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">123</B>
                    <G dataType="Byte">233</G>
                    <R dataType="Byte">248</R>
                  </_x003C_Color_x003E_k__BackingField>
                  <_x003C_FreezeOnDrag_x003E_k__BackingField dataType="Bool">false</_x003C_FreezeOnDrag_x003E_k__BackingField>
                  <_x003C_MessageChannel_x003E_k__BackingField dataType="Int">3</_x003C_MessageChannel_x003E_k__BackingField>
                  <_x003C_MessageLifetime_x003E_k__BackingField dataType="Float">1E+10</_x003C_MessageLifetime_x003E_k__BackingField>
                  <_x003C_SelectionTrigger_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.BlueInput.Selection.SelectionTrigger" name="MouseClick" value="3" />
                  <active dataType="Bool">true</active>
                  <gameobj dataType="ObjectRef">3768439271</gameobj>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1579358824" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="4025655281">
                  <item dataType="ObjectRef">3220268444</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="898954208">
                  <item dataType="ObjectRef">2294738835</item>
                </values>
              </body>
            </compMap>
            <compTransform />
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="2016354979">HA6usVy0Jk6UuJx21FEkqw==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">SelectionTestClick</name>
            <parent dataType="ObjectRef">790557846</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">6</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="440834638">
        <_items dataType="Array" type="Duality.Component[]" id="1127790354" length="0" />
        <_size dataType="Int">0</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="190116444" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2089474104" length="0" />
          <values dataType="Array" type="System.Object[]" id="2225986270" length="0" />
        </body>
      </compMap>
      <compTransform />
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3295819364">l4g6qALzaUaQqlKSvgqtug==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Tests</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2396132337">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="2849187475">
        <_items dataType="Array" type="Duality.GameObject[]" id="701998310" length="4">
          <item dataType="Struct" type="Duality.GameObject" id="1075758564">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="4286708288">
              <_items dataType="Array" type="Duality.Component[]" id="569379612" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="1133035782">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">1075758564</gameobj>
                  <ignoreParent dataType="Bool">false</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">400</X>
                    <Y dataType="Float">500</Y>
                    <Z dataType="Float">0</Z>
                  </pos>
                  <posAbs dataType="Struct" type="Duality.Vector3">
                    <X dataType="Float">400</X>
                    <Y dataType="Float">500</Y>
                    <Z dataType="Float">0</Z>
                  </posAbs>
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2544377844">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">255</B>
                    <G dataType="Byte">161</G>
                    <R dataType="Byte">47</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">1075758564</gameobj>
                  <offset dataType="Float">0</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">256</H>
                    <W dataType="Float">256</W>
                    <X dataType="Float">-128</X>
                    <Y dataType="Float">-128</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group1" value="2" />
                </item>
              </_items>
              <_size dataType="Int">2</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3890299982" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="177127314">
                  <item dataType="ObjectRef">4265998688</item>
                  <item dataType="Type" id="2602702416" value="Duality.Components.Renderers.SpriteRenderer" />
                </keys>
                <values dataType="Array" type="System.Object[]" id="602648522">
                  <item dataType="ObjectRef">1133035782</item>
                  <item dataType="ObjectRef">2544377844</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">1133035782</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="2178099106">nJMvsIWeuU2zD0vDE+gasA==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">Blue Checker</name>
            <parent dataType="ObjectRef">2396132337</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="1139950902">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2217254138">
              <_items dataType="Array" type="Duality.Component[]" id="1172140416" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="1197228120">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">1139950902</gameobj>
                  <ignoreParent dataType="Bool">false</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3" />
                  <posAbs dataType="Struct" type="Duality.Vector3" />
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2608570182">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">158</B>
                    <G dataType="Byte">216</G>
                    <R dataType="Byte">255</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">1139950902</gameobj>
                  <offset dataType="Float">1</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">256</H>
                    <W dataType="Float">256</W>
                    <X dataType="Float">-128</X>
                    <Y dataType="Float">-128</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group4" value="16" />
                </item>
              </_items>
              <_size dataType="Int">2</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3464680762" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="320366400">
                  <item dataType="ObjectRef">4265998688</item>
                  <item dataType="ObjectRef">2602702416</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="2743600718">
                  <item dataType="ObjectRef">1197228120</item>
                  <item dataType="ObjectRef">2608570182</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">1197228120</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="191728092">EAhgBraRP064YbcDD10Z7A==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">Checker</name>
            <parent dataType="ObjectRef">2396132337</parent>
            <prefabLink />
          </item>
          <item dataType="Struct" type="Duality.GameObject" id="1306691979">
            <active dataType="Bool">true</active>
            <children />
            <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2290131035">
              <_items dataType="Array" type="Duality.Component[]" id="2695762326" length="4">
                <item dataType="Struct" type="Duality.Components.Transform" id="1363969197">
                  <active dataType="Bool">true</active>
                  <angle dataType="Float">0</angle>
                  <angleAbs dataType="Float">0</angleAbs>
                  <gameobj dataType="ObjectRef">1306691979</gameobj>
                  <ignoreParent dataType="Bool">false</ignoreParent>
                  <pos dataType="Struct" type="Duality.Vector3" />
                  <posAbs dataType="Struct" type="Duality.Vector3" />
                  <scale dataType="Float">1</scale>
                  <scaleAbs dataType="Float">1</scaleAbs>
                </item>
                <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2775311259">
                  <active dataType="Bool">true</active>
                  <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                    <A dataType="Byte">255</A>
                    <B dataType="Byte">255</B>
                    <G dataType="Byte">255</G>
                    <R dataType="Byte">255</R>
                  </colorTint>
                  <customMat />
                  <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                  <gameobj dataType="ObjectRef">1306691979</gameobj>
                  <offset dataType="Float">0</offset>
                  <pixelGrid dataType="Bool">false</pixelGrid>
                  <rect dataType="Struct" type="Duality.Rect">
                    <H dataType="Float">256</H>
                    <W dataType="Float">256</W>
                    <X dataType="Float">-128</X>
                    <Y dataType="Float">-128</Y>
                  </rect>
                  <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                  <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                    <contentPath dataType="String">Default:Material:DualityIcon</contentPath>
                  </sharedMat>
                  <spriteIndex dataType="Int">-1</spriteIndex>
                  <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0, Group1" value="3" />
                </item>
              </_items>
              <_size dataType="Int">2</_size>
            </compList>
            <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1287852136" surrogate="true">
              <header />
              <body>
                <keys dataType="Array" type="System.Object[]" id="2576981937">
                  <item dataType="ObjectRef">4265998688</item>
                  <item dataType="ObjectRef">2602702416</item>
                </keys>
                <values dataType="Array" type="System.Object[]" id="723936352">
                  <item dataType="ObjectRef">1363969197</item>
                  <item dataType="ObjectRef">2775311259</item>
                </values>
              </body>
            </compMap>
            <compTransform dataType="ObjectRef">1363969197</compTransform>
            <identifier dataType="Struct" type="System.Guid" surrogate="true">
              <header>
                <data dataType="Array" type="System.Byte[]" id="2174747235">NcPBU2WUP0auZ8oq73ePkw==</data>
              </header>
              <body />
            </identifier>
            <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
            <name dataType="String">Disk</name>
            <parent dataType="ObjectRef">2396132337</parent>
            <prefabLink />
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2956886776">
        <_items dataType="ObjectRef">1127790354</_items>
        <_size dataType="Int">0</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3057680761" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="84219732" length="0" />
          <values dataType="Array" type="System.Object[]" id="3045875126" length="0" />
        </body>
      </compMap>
      <compTransform />
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1817629808">fHQLspSS+0m5T0lyDulaDg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Sprites</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="ObjectRef">1064589658</item>
    <item dataType="ObjectRef">248901068</item>
    <item dataType="ObjectRef">1514197647</item>
    <item dataType="ObjectRef">2563092514</item>
    <item dataType="ObjectRef">1750737594</item>
    <item dataType="ObjectRef">3768439271</item>
    <item dataType="ObjectRef">1075758564</item>
    <item dataType="ObjectRef">1139950902</item>
    <item dataType="ObjectRef">1306691979</item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
