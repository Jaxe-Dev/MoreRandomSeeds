using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace MoreRandomSeeds
{
    internal static class SeedGenerator
    {
        private const int MaxLength = 24;

        private const int MinParts = 2;
        private const int MaxParts = 5;

        private const int MinDigits = 2;

        private static readonly string[] Separators = { "", "-" };

        public static string Get()
        {
            var separator = Separators[Rand.RangeInclusive(0, Separators.Length - 1)];
            var partCount = Rand.RangeInclusive(MinParts, MaxParts);

            var maxDigits = Mathf.FloorToInt((MaxLength - (separator.Length * (partCount - 1))) / (float) partCount);
            var partDigits = Rand.RangeInclusive(MinDigits, maxDigits);

            return GetStyledSeed(partDigits, partCount, separator);
        }

        private static string GetPart(int digits)
        {
            var part = "";
            for (var index = 0; index < digits; index++) { part += Rand.RangeInclusive(0, 9); }
            return part;
        }

        private static string GetStyledSeed(int partDigits, int partCount, string separator)
        {
            var parts = new List<string>();
            for (var part = 0; part < partCount; part++) { parts.Add(GetPart(partDigits)); }
            return string.Join(separator, parts.ToArray());
        }
    }
}
