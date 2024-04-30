using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCannonController : CannonController
{

    public override void Start()
    {
        base.Start();
        enemyLayer = LayerMask.GetMask(Constants.EnemyLayerName);
    }

    void Update()
    {
        if (ammoLeft != 0 && isFiring)
        {
            frameCounter++;
            if (frameCounter == rateOfFireFrames)
            {
                ShootCannon(Constants.EnemiesTagName);
                PlayerController.UIAmmoTracker.UpdateWeaponAmmoInUI(Ammunition);
            }
        }
    }

    public override void SetWeapon(WeaponData weapon)
    {
        base.SetWeapon(weapon);
        PlayerController.UIAmmoTracker.AddWeaponIcon(weapon.iconPath);
    }
}
