using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreRandomSeeds
{
    internal class Settings : ModSettings
    {
        public const string DefaultFormats = "%%%%-%%%%-%%%%-%%%%\n%%%-%%%-%%%-%%%\n%%-%%-%%-%%-%%";

        public const char AnyDigit = '%';
        public const char UpperLetter = '$';
        public const char LowerLetter = '@';
        public const char AnyLetter = '&';

        private const string UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string AnyLetters = UpperLetters + LowerLetters;

        private const int MaxSeedLength = 24;
        public static string Formats = DefaultFormats;
        public static List<string> ValidatedFormats;

        private static Settings _instance;

        static Settings() => ValidateSettings();

        public static void Init(Mod controller) => _instance = controller.GetSettings<Settings>();

        public static List<string> Validate(string formats)
        {
            var list = new List<string>();
            foreach (var line in formats.Split('\n').Select(line => line.Trim()))
            {
                if ((line.Length > MaxSeedLength) || string.IsNullOrEmpty(line)) { return null; }
                list.Add(line);
            }

            return list.Count == 0 ? null : list;
        }

        private static void ValidateSettings()
        {
            var list = Validate(Formats);
            ValidatedFormats = list ?? Validate(DefaultFormats);
        }

        public static void UpdateSettings(List<string> formats)
        {
            Formats = string.Join("\n", formats.ToArray());
            ValidatedFormats = formats;
            _instance.Write();
        }

        public static string GetSeed()
        {
            var line = Rand.RangeInclusive(0, ValidatedFormats.Count - 1);

            var format = ValidatedFormats[line];

            var seed = new StringBuilder();
            foreach (var c in format)
            {
                if (c == AnyDigit) { seed.Append(Rand.RangeInclusive(0, 9).ToString()[0]); }
                else if (c == UpperLetter) { seed.Append(UpperLetters[Rand.RangeInclusive(0, UpperLetters.Length - 1)]); }
                else if (c == LowerLetter) { seed.Append(LowerLetters[Rand.RangeInclusive(0, LowerLetters.Length - 1)]); }
                else if (c == AnyLetter) { seed.Append(AnyLetters[Rand.RangeInclusive(0, AnyLetters.Length - 1)]); }
                else { seed.Append(c); }
            }

            return seed.ToString();
        }

        public static void Reset()
        {
            Formats = DefaultFormats;
            ValidateSettings();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref Formats, "Formats");
            ValidateSettings();
        }
    }
}
