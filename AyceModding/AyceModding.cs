using System.IO;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using BepInEx.IL2CPP;

namespace AyceModding
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Overcooked All You Can Eat.exe")]
    public class AyceModding : BasePlugin
    {
        internal static new ManualLogSource Log;
        public static ConfigFile configFile;

        public override void Load()
        {
            AyceModding.Log.LogInfo($"AyceModding is alive!");

            /* Setup Logging */
            AyceModding.Log = base.Log;

            /* Initialize Configuration */
            configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "AyceModding.cfg"), true);

            /* Initialize Components */
            PatchUnlockAllChefs.load();
        }
    }
}
