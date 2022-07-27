# Dev Setup

1. Install the contents of [BepInEx_UnityIL2CPP_x64_9c2b17f_6.0.0-be.572](https://builds.bepinex.dev/projects/bepinex_be/572/BepInEx_UnityMono_x64_9c2b17f_6.0.0-be.572.zip) into the game folder

1. Install latest [.NET sdk](https://dotnet.microsoft.com/en-us/)

2. Copy the following dlls to `/lib/`:

```
BepInEx.dll
0Harmony.dll
UnityEngine.dll
UnityEngine.CoreModule.dll
Assembly-CSharp.dll
```

3. Build
```
cd AyceModding
dotnet build
```

4. Copy `/AyceModding/bin/Debug/netstandard2.0/com.github.toasterparty.AyceModding.dll` to `<game-folder>/BepInEx/plugins` and run the game
