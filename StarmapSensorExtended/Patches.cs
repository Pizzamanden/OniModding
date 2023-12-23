using HarmonyLib;

namespace StarmapSensorExtended
{
    public class Patches
    {
        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public class Db_Initialize_Patch
        {
            public static void Prefix()
            {
                Debug.Log("I execute before Db.Initialize!");
            }

            public static void Postfix()
            {
                Debug.Log("I execute after Db.Initialize!");
            }
        }

        // FOR LogicClusterLocationSensor :

        // TODO new class attribute, private boolean 

        // TODO : New method for checking if on a POI

        // TODO : Postfix CheckCurrentLocationSelected 
        // Either short circuit logic check by saying "Previous OR POI_allowed AND at_POI"
        // Or do method SC on normal method being true, otherwise do POI_allowed AND at_Poi




        // FOR ClusterLocationFilterSideScreen

        // TODO new class attribute, private GameObject




    }
}
