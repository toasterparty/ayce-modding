using System.IO;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using UnhollowerBaseLib;
using HarmonyLib;

namespace AyceModding
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Overcooked All You Can Eat.exe")]
    public class AyceModding : BasePlugin
    {
        internal static new ManualLogSource Log;
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        private static ConfigFile configFile;
        private static ConfigEntry<bool> configUnlockAllChefs;

        public override void Load()
        {
            /* Setup Logging */
            AyceModding.Log = base.Log;

            /* Initialize Configuration */
            configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "AyceModding.cfg"), true);
            bindConfig();

            /* Inject Mods */
            if (configUnlockAllChefs.Value)
            {
                Harmony.CreateAndPatchAll(typeof(PatchUnlockAllChefs));
            }

            AyceModding.Log.LogInfo($"Loaded Successfully");
        }

        private void bindConfig()
        {
            configUnlockAllChefs = configFile.Bind(
                "Cosmetic", // Config Category
                "UnlockAllChefs", // Config key name
                true, // Default Config value
                "Set to true to show all Chefs on the Chef selection screen" // Friendly description
            );
        }

        class PatchUnlockAllChefs
        {
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
}
