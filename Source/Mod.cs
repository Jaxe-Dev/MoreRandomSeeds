using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace MoreRandomSeeds
{
    internal class Mod : Verse.Mod
    {
        public const string Id = "MoreRandomSeeds";
        public const string Name = "More Random Seeds";
        public const string Version = "4.0";

        private string _tempLines;
        private List<string> _tempFormats;

        public Mod(ModContentPack content) : base(content)
        {
            new Harmony(Id).PatchAll();
            Settings.Init(this);
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            if (_tempLines == null) { _tempLines = Settings.Formats; }

            var listing = new Listing_Standard();
            listing.Begin(inRect);
            listing.Label("MoreRandomSeeds.Format".Translate().Bold());
            listing.GapLine();
            var lines = listing.TextEntry(_tempLines, 10);
            listing.Gap();
            listing.Label("MoreRandomSeeds.Instructions".Translate());
            listing.GapLine();
            listing.Label(Settings.AnyDigit.ToString().Bold() + "\t\t" + "MoreRandomSeeds.Instructions.AnyDigit".Translate().Italic());
            listing.Label(Settings.UpperLetter.ToString().Bold() + "\t\t" + "MoreRandomSeeds.Instructions.UpperLetter".Translate().Italic());
            listing.Label(Settings.LowerLetter.ToString().Bold() + "\t\t" + "MoreRandomSeeds.Instructions.LowerLetter".Translate().Italic());
            listing.Label(Settings.AnyLetter.ToString().Bold() + "\t\t" + "MoreRandomSeeds.Instructions.AnyLetter".Translate().Italic());
            listing.GapLine();

            _tempFormats = Settings.Validate(lines);

            if (listing.ButtonText("MoreRandomSeeds.Reset".Translate()))
            {
                Settings.Reset();
                lines = null;
            }

            var lastColor = GUI.color;

            if (_tempFormats == null)
            {
                GUI.color = Color.red;
                listing.Label("MoreRandomSeeds.Invalid".Translate().Bold());
            }
            else
            {
                GUI.color = Color.green;
                listing.Label("MoreRandomSeeds.Saved".Translate().Bold());

                if (_tempLines != lines)
                {
                    Settings.UpdateSettings(_tempFormats);
                    lines = Settings.Formats;
                }
            }

            GUI.color = lastColor;
            _tempLines = lines;

            listing.End();
        }

        public override string SettingsCategory() => Name;
    }
}
