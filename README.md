# Build

1. Install the contents of [BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.665+6aabdb5](https://builds.bepinex.dev/projects/bepinex_be/665/BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.665%2B6aabdb5.zip) into the game folder

2. Install latest [.NET sdk](https://dotnet.microsoft.com/en-us/)

3. Copy the following DLLs to `/lib/`:

```
UnityEngine.dll
UnityEngine.CoreModule.dll
Assembly-CSharp.dll
Il2Cppmscorlib.dll
UnhollowerBaseLib.dll
```

4. Build
```
tools\build.bat
```

5. Install
```
dist\ayce-modding-install.bat
```
