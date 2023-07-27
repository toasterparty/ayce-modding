using System;
using System.IO;
using HarmonyLib;
using Polenter.Serialization;

namespace AyceModding
{
    public static class ExportAvatarDirectory
    {
        public static void load()
        {
            Harmony.CreateAndPatchAll(typeof(ExportAvatarDirectory));
        }

        [HarmonyPatch(typeof(MetaGameProgress), "InitialiseAvatarUnlocks")]
        [HarmonyPostfix]
        public static void InitialiseAvatarUnlocks(ref AvatarDirectoryData avatarDirectoryData)
        {
            if (avatarDirectoryData == null)
            {
                return;
            }

            var baseAvatars = avatarDirectoryData.BaseAvatars;

            for (int i = 0; i < baseAvatars.Length; i++)
            {
                try
                {
                    var variants = baseAvatars[i].m_variants;
                    for (int j = 0; j < variants.Length; j++)
                    {
                        ChefAvatarData variant = variants[j];
                        try
                        {
                            // SerializeChefAvatarData(variant, $"{variant.name}.xml");
                            AyceModding.Log.LogInfo($"Exported {variant.name}");
                        }
                        catch (Exception e)
                        {
                            AyceModding.Log.LogError($"Failed to export avatar variant {variant.name}: {e}");
                        }
                    }
                }
                catch (Exception e)
                {
                    AyceModding.Log.LogError($"Failed export avatar: {e}");
                }
            }

            AyceModding.Log.LogInfo($"Successfully exported chefs from {avatarDirectoryData.name}");
        }

        private static void SerializeChefAvatarData(ChefAvatarData data, string filename)
        {
            var serializer = new SharpSerializer();
            serializer.Serialize(data, filename);
        }
    }
}
