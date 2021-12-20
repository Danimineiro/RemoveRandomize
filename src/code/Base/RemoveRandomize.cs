using Verse;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using System;

namespace RemoveRandomize
{
	[StaticConstructorOnStartup]
	public static class Patcher
	{
		static Patcher()
		{
			var harmony = new Harmony("dani.removeRandomizeButton");
			harmony.PatchAll();
		}
	}

	[HarmonyPatch(typeof(CharacterCardUtility), "DrawCharacterCard")]
	class RemoveRandomizePatch
	{
		static void Prefix(Rect rect, Pawn pawn, ref Action randomizeCallback, Rect creationRect = default(Rect))
		{
			if (LoadedModManager.GetMod<RRMod>().GetSettings<RRSettings>().characterCardUtilityPatchEnabled)
			{
				randomizeCallback = null;
			}
		}
	}

	/// <summary>
	/// Removes the randomize button by removing any button with the "Randomize" string on it
	/// </summary>
	[HarmonyPatch(typeof(Widgets), "ButtonText", typeof(Rect), typeof(string), typeof(bool), typeof(bool), typeof(bool))]
	class WidgetsRemoveRandomizePatch
	{
		private readonly static Rect toRemoveRect = new Rect(678f, 0f, 100f, 30f);

		static bool Prefix(ref bool __result, Rect rect, string label, bool drawBackground = true, bool doMouseoverSound = true, bool active = true)
		{
			if (LoadedModManager.GetMod<RRMod>().GetSettings<RRSettings>().widgetsPatchEnabled && label == "Randomize".Translate() && rect.Equals(toRemoveRect))
			{
				__result = false;
				return false;
			}

			__result = false;
			return true;
		}
	}
}
