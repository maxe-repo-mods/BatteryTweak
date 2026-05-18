using HarmonyLib;

namespace BatteryTweak.Patches;

[HarmonyPatch(typeof(ItemGun))]
public static class ItemGunPatch
{
    private struct GunState
    {
        public float batteryDrain;
        public bool fullBar;
        public int fullBars;
    }

    [HarmonyPrefix]
    [HarmonyPatch("ShootRPC")]
    static void ShootRPC_Prefix(ItemGun __instance, out GunState __state)
    {
        __state = new GunState
        {
            batteryDrain = __instance.batteryDrain,
            fullBar = __instance.batteryDrainFullBar,
            fullBars = __instance.batteryDrainFullBars,
        };

        float mult = Plugin.GunAmmoDrainMultiplier.Value / 100f;

        if (__instance.batteryDrainFullBar)
        {
            var battery = __instance.GetComponent<ItemBattery>();
            if (battery != null && battery.batteryBars > 0)
            {
                float drainPerBar = 100f / battery.batteryBars;
                __instance.batteryDrainFullBar = false;
                __instance.batteryDrain = drainPerBar * __instance.batteryDrainFullBars * mult;
            }
        }
        else
        {
            __instance.batteryDrain = __state.batteryDrain * mult;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch("ShootRPC")]
    static void ShootRPC_Postfix(ItemGun __instance, GunState __state)
    {
        __instance.batteryDrain = __state.batteryDrain;
        __instance.batteryDrainFullBar = __state.fullBar;
        __instance.batteryDrainFullBars = __state.fullBars;
    }
}
