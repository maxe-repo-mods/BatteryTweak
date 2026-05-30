# BatteryTweak

Customize battery drain and charge rates for items in R.E.P.O.

## Features

- Adjust battery drain rate multiplier (make batteries last longer)
- Adjust charging station speed multiplier (charge faster or slower)
- Customize gun ammunition drain per shot
- Real-time configuration without restart

## Installation

1. Install [BepInEx 5.x](https://github.com/BepInEx/BepInEx/releases) for R.E.P.O.
2. Download the latest `BatteryTweak.dll` from releases
3. Place `BatteryTweak.dll` in `BepInEx/plugins/`
4. Launch the game to generate config file

## Configuration

Configuration file: `BepInEx/config/maxenterme.BatteryTweak.cfg`

| Section | Key | Type | Default | Description |
|---------|-----|------|---------|-------------|
| General | DrainRateMultiplier | int | 50 | Battery drain speed multiplier (100 = 100%, 50 = 50% = batteries last 2x longer). Range: 0-200 |
| General | ChargeRateMultiplier | int | 100 | Charging station speed multiplier (100 = 100%, 200 = 200% = charge 2x faster). Range: 0-200 |
| Ammo | GunAmmoDrainMultiplier | int | 100 | Gun battery drain per shot multiplier (100 = 100%, 50 = 50% = double ammo). Range: 0-200 |

## Build

```bash
dotnet build -c Release
```

Output: `bin/Release/netstandard2.1/BatteryTweak.dll`


## AI Disclosure

This mod was developed with the assistance of AI (Claude by Anthropic). All code has been reviewed and tested by the developer.

## License

MIT
