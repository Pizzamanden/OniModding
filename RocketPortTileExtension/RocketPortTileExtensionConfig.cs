using STRINGS;
using TUNING;
using UnityEngine;
using static STRINGS.BUILDINGS.PREFABS;

namespace RocketPortTileExtension
{
    public class RocketPortTileExtensionConfig : IBuildingConfig
    {
        public static string ID = "ModularLaunchpadPortTile";
        public static LocString NAME = (LocString)UI.FormatAsLink("Rocket Port Tile Extension", "Rocket Port Tile Extension");
        public static LocString DESC = MODULARLAUNCHPADPORTBRIDGE.DESC;
        public static LocString EFFECT = (LocString)("Automatically links when built to the side of a " + (string)LAUNCHPAD.NAME + " or any " + (string)MODULARLAUNCHPADPORT.NAME + ".");


        public override string[] GetDlcIds() => DlcManager.AVAILABLE_EXPANSION1_ONLY;

        public override BuildingDef CreateBuildingDef()
        {
            // Yoinked from ModularLaunchpadPortBridge
            float[] tieR3 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] refinedMetals = MATERIALS.REFINED_METALS;
            EffectorValues tieR0 = NOISE_POLLUTION.NOISY.TIER0;
            EffectorValues none = TUNING.BUILDINGS.DECOR.NONE;
            EffectorValues noise = tieR0;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, 1, 2, "rocket_loader_extension_kanim", 1000, 60f, tieR3, refinedMetals, 9999f, BuildLocationRule.OnFloor, none, noise);
            buildingDef.SceneLayer = Grid.SceneLayer.Background;
            buildingDef.OverheatTemperature = 2273.15f;
            buildingDef.Floodable = false;
            buildingDef.Entombable = false;
            buildingDef.DefaultAnimState = "idle";
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "medium";
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            // Yoinked from MetalTileConfig.cs
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
            simCellOccupier.movementSpeedMultiplier = DUPLICANTSTATS.MOVEMENT.BONUS_3;
            simCellOccupier.notifyOnMelt = true;
            go.AddOrGet<TileTemperature>();

            // Yoinked from ModularLaunchpadPortBridge
            KPrefabID component = go.GetComponent<KPrefabID>();
            component.AddTag(GameTags.ModularConduitPort);
            component.AddTag(GameTags.NotRocketInteriorBuilding);
            component.AddTag(BaseModularLaunchpadPortConfig.LinkTag);
            ChainedBuilding.Def def = go.AddOrGetDef<ChainedBuilding.Def>();
            def.headBuildingTag = "LaunchPad".ToTag();
            def.linkBuildingTag = BaseModularLaunchpadPortConfig.LinkTag;
            def.objectLayer = ObjectLayer.Building;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
        }
    }
}

