using Harmony;
using Verse;

namespace MoreRandomSeeds
{
    [StaticConstructorOnStartup]
    internal static class Mod
    {
        public const string Id = "MoreRandomSeeds";
        public const string Name = "More Random Seeds";
        public const string Version = "2.0";

        static Mod() => HarmonyInstance.Create(Id).PatchAll();
    }
}
