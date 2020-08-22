using HarmonyLib;
using RimWorld;
using Verse;

namespace MoreRandomSeeds
{
    internal static class Patches
    {
        [HarmonyPatch(typeof(GenText), "RandomSeedString")]
        internal static class Verse_GenText_RandomSeedString
        {
            private static bool Prefix(ref string __result)
            {
                __result = Settings.GetSeed();
                return false;
            }
        }

        [HarmonyPatch(typeof(Dialog_ModSettings), MethodType.Constructor)]
        internal static class RimWorld_Dialog_ModSettings_Ctor
        {
            private static void Postfix(ref Dialog_ModSettings __instance) => __instance.closeOnAccept = false;
        }
    }
}
