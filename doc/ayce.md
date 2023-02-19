# Overcooked! All You Can Eat Notes

This file contains useful notes for reverse engineering OC AYCE.

Unity Version - v2019.4.5.8478991

The game was packaged with IL2CPP. This took the nice neat JIT IL DLLs and packs them down into standard binaries. By simply running the game with BepInEx, BepInEx will "unhollow" the standard unity DLLs you know and love into `BepInEx/unhollowed`. This contains all the symbols for classes and functions, but implementations are not accessible this way.

To view function implementations you'll need to use [Cpp2IL](https://github.com/SamboyCoding/Cpp2IL/releases/tag/2022.0.5) with the following command:

```
Cpp2IL-2022.0.5-Windows.exe --game-path "Overcooked! All You Can Eat" --experimental-enable-il-to-assembly-please
```

This will use black magic to rebuild the original IL code and output them in a folder.

Open `Assembly-CSharp.dll` and `Assembly-CSharp-firstpass.dll` in [DnSpyEx](https://github.com/dnSpyEx/dnSpy) the unofficial continuation of DnSpy. Use this reverse engineered code to inform your Harmony patches.
