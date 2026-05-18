using HarmonyLib;
using UnityEngine;

namespace BatteryTweak.Patches;

[HarmonyPatch(typeof(ItemBattery))]
public static class ItemBatteryPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("Update")]
    static void Update_Prefix(ItemBattery __instance, out float __state)
    {
        __state = __instance.batteryDrainRate;
        __instance.batteryDrainRate = __state * (Plugin.DrainRateMultiplier.Value / 100f);
    }

    [HarmonyPostfix]
    [HarmonyPatch("Update")]
    static void Update_Postfix(ItemBattery __instance, float __state)
    {
        __instance.batteryDrainRate = __state;
    }

    /// <summary>
    /// Prefix on ChargeBattery to scale the charge amount.
    /// Signature: ChargeBattery(GameObject chargerObject, float chargeAmount)
    /// </summary>
    [HarmonyPrefix]
    [HarmonyPatch("ChargeBattery")]
    static void ChargeBattery_Prefix(ref float chargeAmount)
    {
        chargeAmount *= Plugin.ChargeRateMultiplier.Value / 100f;
    }
}
