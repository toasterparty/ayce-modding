# Build

1. Install the contents of [BepInEx_UnityIL2CPP_x64_9c2b17f_6.0.0-be.572](https://builds.bepinex.dev/projects/bepinex_be/572/BepInEx_UnityMono_x64_9c2b17f_6.0.0-be.572.zip) into the game folder

2. Install latest [.NET sdk](https://dotnet.microsoft.com/en-us/)

3. Copy the following DLLs to `/lib/`:

```
UnityEngine.dll
UnityEngine.CoreModule.dll
Assembly-CSharp.dll
```

4. Build
```
tools\build.bat
```

5. Install
```
dist\ayce-modding-install.bat
```
