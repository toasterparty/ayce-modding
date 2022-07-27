using System.IO;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using UnhollowerBaseLib;
using BepInEx.Configuration;
using HarmonyLib;

namespace AyceModding
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Overcooked All You Can Eat.exe")]
    public class AyceModding : BasePlugin
    {
        private ConfigEntry<bool> configExampleBool;
        internal static new ManualLogSource Log;
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

        public override void Load()
        {
            /* Setup Logging */
            AyceModding.Log = base.Log;

            /* Handle Configuration */
            var configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "AyceModding.cfg"), true);

            configExampleBool = configFile.Bind(
                "Cosmetic", // Config Category
                "UnlockAllChefs", // Config key name
                true, // Default Config value
                "Set to True to show all Chefs on the Chef selection screen" // Friendly description
            );

            /* Patch Modifications */
            Harmony.CreateAndPatchAll(typeof(AyceModding));

            /* Log Success */
            AyceModding.Log.LogInfo($"Loaded Successfully");
            AyceModding.Log.LogInfo($"Example Config = {configExampleBool.Value}");
        }

        [HarmonyPatch(typeof(ChefSelectMenu), "SetUpGridItem")]
        [HarmonyPrefix]
        public static bool Prefix(ref Il2CppStructArray<bool> variantsUnlocked, ref int firstUnlockedVariant, ref bool unlockable)
        {
            /* Unlock all variants */
            for (int i = 0; i < variantsUnlocked.Count; i++)
            {
                variantsUnlocked[i] = true;
            }

            /* Unlock all chefs */
            firstUnlockedVariant = 0;
            unlockable = true;

            return true; // Execute original function
        }
    }
}
