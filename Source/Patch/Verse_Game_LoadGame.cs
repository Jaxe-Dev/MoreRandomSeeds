using Harmony;
using Verse;

namespace MoreRandomSeeds.Patch
{
    [HarmonyPatch(typeof(GenText), nameof(GenText.RandomSeedString))]
    internal static class Patch
    {
        private static bool Prefix(ref string __result)
        {
            __result = Rand.Range(0, int.MaxValue).ToString();
            return false;
        }
    }
}
