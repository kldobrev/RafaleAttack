using UnityEngine;

public static class Constants {

    // Weapons

    public static WeaponData BulletCannon = new WeaponData("Bullet cannon", 5, 2000, 1000, "WeaponIcons/CannonRound", "CannonEffectPrefabs/FireBulletEffect");

    // Weapon controllers

    public const string EnemyLayerName = "Enemy";
    public const string PlayerLayerName = "Player";
    public const int MaxNumWeapons = 1; // Change when adding missiles

    // Enemy Seahawk

    public const float MaxMaintainedHeight = 1500;
    public const int MainPropellerIndex = 0;
    public const int SmallPropellerIndex = 1;
    public const float MainPropellerSpeed = 600;
    public const float SmallPropellerSpeed = 700;
    public const float Speed = 30;
    public const float forwardAngleLimit = 300;
    public const float backwardAngleLimit = 60;
    public const float leftAngleLimit = 310;
    public const float rightAngleLimit = 50;

    // Player controller

    public const string RetractGearsAnimParamName = "RetractLandingGears";
    public const float PlDefaultDrag = 0.1f;
    public const float PlBrakeDrag = 0.001f;
    public const float PlTurnDrag = 0.7f;
    public const float PlMinSpeedAir = 100f;
    public const int SendHeightFramerule = 2;
    public const int SendCoordsFramerule = 1;
    public const int SendSpeedFramerule = 5;
    public const float HeightTreshold = 15000f;
    public const float HeightDrag = 200f;
    public const float HeightDragTurn = 1f;

    // Tracker controller

    public const string EnemyPointTagName = "RadarPointEnemy";
    public const string RadarPointLayerName = "RadarTracked";
    public const float CoveredDistance = 30000;

    // UI

    public const string DefaultSpeedValueUI = "Speed: 0000 km/h";
    public const string DefaultAutoSpeedValueUI = "Auto speed: 0000 km/h";
    public const float HeightMeterValueMinUI = 0f;
    public const float HeightMeterValueAlertUI = 1000f;
    public const float HeightMeterValueMaxUI = 15230f;
    public static Color32 heightAboveAlertColor = new Color32(80, 255, 0, 255);
    public static Color32 heightBelowAlertColor = new Color32(255, 141, 0, 255);
    public static Color32 autoSpeedColorOff = new Color32(130, 130, 130, 190);
    public static Color32 autoSpeedColorOn = new Color32(53, 255, 0, 255);
    public static Color32 weaponEmptyIconColor = new Color32(78, 78, 78, 178);

}