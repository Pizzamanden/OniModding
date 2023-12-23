using HarmonyLib;
using STRINGS;

namespace RocketPortTileExtension
{
    public class RocketPortTileExtensionPatches
    {
        [HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch(nameof(GeneratedBuildings.LoadGeneratedBuildings))]
		public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
		{
			

            public static void Prefix()
			{
                Debug.Log("Executing prefix, adding buildings to list");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{RocketPortTileExtensionConfig.ID.ToUpperInvariant()}.NAME", UI.FormatAsLink(RocketPortTileExtensionConfig.NAME, RocketPortTileExtensionConfig.ID));
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{RocketPortTileExtensionConfig.ID.ToUpperInvariant()}.DESC", RocketPortTileExtensionConfig.DESC);
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{RocketPortTileExtensionConfig.ID.ToUpperInvariant()}.EFFECT", RocketPortTileExtensionConfig.EFFECT);
                ModUtil.AddBuildingToPlanScreen("Rocketry", RocketPortTileExtensionConfig.ID, "Ports", ModularLaunchpadPortBridgeConfig.ID);
            }
		}

		[HarmonyPatch(typeof(Db))]
		[HarmonyPatch(nameof(Db.Initialize))]
		public static class Db_Initialize_Patch
		{
			public static void Postfix()
			{
                Debug.Log("Executing postfix, adding building to technology");
                Db.Get().Techs.Get("Smelting").unlockedItemIDs.Add(RocketPortTileExtensionConfig.ID);
            }
		}
    }
}