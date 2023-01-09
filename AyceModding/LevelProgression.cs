using HarmonyLib;

namespace AyceModding
{
    public static class LevelProgression
    {
        public static void load()
        {
            Harmony.CreateAndPatchAll(typeof(LevelProgression));
        }

        [HarmonyPatch(typeof(GameProgress.GameProgressData), "IsLevelUnlocked")]
        [HarmonyPostfix]
        private static void IsLevelUnlocked(ref int _levelIndex, ref bool _rootCompleteCheck, ref bool __result)
        {
            __result = true;
        }

        
        [HarmonyPatch(typeof(GameProgress.GameProgressData), "GetLevelProgress")]
        [HarmonyPostfix]
        private static void GetLevelProgress(ref int _id, ref GameProgress.GameProgressData.LevelProgress __result)
        {
            __result.Purchased = true;
            __result.Revealed = true;
            __result.NGPEnabled = true;
            __result.Completed = true;
            __result.ObjectivesCompleted = true;
        }
    }
}
