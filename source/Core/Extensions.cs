using Verse;

namespace MoreRandomSeeds.Core
{
  internal static class Extensions
  {
    public static string Italic(this string self) => "<i>" + self + "</i>";
    public static string Italic(this TaggedString self) => self.ToString().Italic();

    public static string Bold(this string self) => "<b>" + self + "</b>";
    public static string Bold(this TaggedString self) => self.ToString().Bold();
  }
}
