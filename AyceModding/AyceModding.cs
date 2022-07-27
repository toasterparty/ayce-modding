using System.IO;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Configuration;
namespace AyceModding
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Overcooked All You Can Eat.exe")]
    public class AyceModding : BasePlugin
    {

        private ConfigEntry<bool> configExampleBool;

        public override void Load()
        {
            var configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "AyceModding.cfg"), true);

            configExampleBool = configFile.Bind(
                "Example", // Config Category
                "ExampleBool", // Config key name
                false, // Default Config value
                "This boolean does nothing. It is for demonstration purposes only" // Friendly description
            );

            Log.LogInfo($"Plugin '{PluginInfo.PLUGIN_GUID}' loaded.");
            Log.LogInfo($"Example Config = {configExampleBool.Value}");
        }
    }
}
