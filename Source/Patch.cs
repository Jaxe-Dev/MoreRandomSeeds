using Harmony;
using Verse;

namespace MoreRandomSeeds
{
    [HarmonyPatch(typeof(GenText), "RandomSeedString")]
    internal static class Patch
    {
        private static bool Prefix(ref string __result)
        {
            __result = Settings.GetSeed();
            //__result = SeedGenerator.Get();
            return false;
        }
    }
}
