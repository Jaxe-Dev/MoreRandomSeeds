using Harmony;
using Verse;

namespace MoreRandomSeeds
{
    [StaticConstructorOnStartup]
    internal static class Mod
    {
        static Mod() => HarmonyInstance.Create("MoreRandomSeeds").PatchAll();
    }
}
