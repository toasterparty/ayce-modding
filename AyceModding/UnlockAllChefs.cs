using BepInEx.Configuration;
using UnhollowerBaseLib;
using HarmonyLib;

namespace AyceModding
{
    public static class PatchUnlockAllChefs
    {
        private static ConfigEntry<bool> configUnlockAllChefs;

        public static void load()
        {
            /* Setup Configuration */
            configUnlockAllChefs = AyceModding.configFile.Bind(
                "Cosmetic", // Config Category
                "UnlockAllChefs", // Config key name
                false, // Default Config value
                "Set to true to show all Chefs on the Chef selection screen" // Friendly description
            );

            /* Inject Mod */
            if (configUnlockAllChefs.Value)
            {
                AyceModding.Log.LogInfo($"Force unlocked all chefs");
                Harmony.CreateAndPatchAll(typeof(PatchUnlockAllChefs));
            }
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
