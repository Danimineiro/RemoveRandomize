using UnityEngine;
using Verse;

namespace RemoveRandomize
{
	class RRMod : Mod
	{
		private readonly RRSettings settings;

		public RRMod(ModContentPack content) : base(content)
		{
			settings = GetSettings<RRSettings>();
		}

        public override void DoSettingsWindowContents(Rect inRect)
        {
			Listing_Standard ls = new Listing_Standard();
			ls.Begin(inRect);

			ls.CheckboxLabeled("RRUseWidgetsPatch".Translate(), ref settings.widgetsPatchEnabled);
			ls.CheckboxLabeled("RRUseCCUPatch".Translate(), ref settings.characterCardUtilityPatchEnabled);

			ls.Label("RRLabelDesc".Translate("Randomize".Translate()));
			ls.End();
		}

		public override string SettingsCategory()
		{
			return "RRSettingsCategoryName".Translate();
		}
	}
}
