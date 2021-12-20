using Verse;

namespace RemoveRandomize
{
	class RRSettings : ModSettings
	{
		public bool widgetsPatchEnabled = false;
		public bool characterCardUtilityPatchEnabled = false;

		/// <summary>
		/// Saves the set bools
		/// </summary>
		public override void ExposeData()
		{
			Scribe_Values.Look(ref widgetsPatchEnabled, "widgetsPatchEnabled");
			Scribe_Values.Look(ref characterCardUtilityPatchEnabled, "characterCardUtilityPatchEnabled");
			base.ExposeData();
		}
	}
}
