using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace BatteryTweak;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string PluginGuid = "maxenterme.BatteryTweak";
    private const string PluginName = "BatteryTweak";
    private const string PluginVersion = "1.0.4";

    internal static Plugin Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger => Instance._logger;
    private ManualLogSource _logger => base.Logger;

    internal static ConfigEntry<int> DrainRateMultiplier = null!;
    internal static ConfigEntry<int> ChargeRateMultiplier = null!;
    internal static ConfigEntry<int> GunAmmoDrainMultiplier = null!;

    private void Awake()
    {
        Instance = this;

        DrainRateMultiplier = Config.Bind("General", "DrainRateMultiplier", 50,
            new ConfigDescription(
                "Battery drain speed multiplier (100 = 100%, 50 = 50% = batteries last 2x longer)",
                new AcceptableValueRange<int>(0, 200)));

        ChargeRateMultiplier = Config.Bind("General", "ChargeRateMultiplier", 100,
            new ConfigDescription(
                "Charging station speed multiplier (100 = 100%, 200 = 200% = charge 2x faster)",
                new AcceptableValueRange<int>(0, 200)));

        GunAmmoDrainMultiplier = Config.Bind("Ammo", "GunAmmoDrainMultiplier", 100,
            new ConfigDescription(
                "Gun battery drain per shot multiplier (100 = 100%, 50 = 50% = double ammo)",
                new AcceptableValueRange<int>(0, 200)));

        new Harmony(PluginGuid).PatchAll(typeof(Plugin).Assembly);
        Logger.LogInfo($"{PluginName} v{PluginVersion} loaded!");
    }
}
