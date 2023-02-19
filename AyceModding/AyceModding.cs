using System.IO;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;

namespace AyceModding
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Overcooked All You Can Eat.exe")]
    public class AyceModding : BasePlugin
    {
        internal static new ManualLogSource Log;
        public static ConfigFile configFile;
        private static ConfigEntry<bool> configDisableAllMods;

        public override void Load()
        {
            /* Setup Logging */
            AyceModding.Log = base.Log;
            AyceModding.Log.LogInfo($"AyceModding is alive!");

            /* Initialize Configuration */
            configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "AyceModding.cfg"), true);
            configDisableAllMods = AyceModding.configFile.Bind(
                "General",
                "DisableAllMods",
                false,
                "Set to true to completely return the game back to it's original state"
            );

            if (configDisableAllMods.Value)
            {
                AyceModding.Log.LogInfo($"All mods DISABLED!");
                return;
            }

            /* Inject Mods */
            PatchUnlockAllChefs.load();
            LevelProgression.load();
        }
    }
}
