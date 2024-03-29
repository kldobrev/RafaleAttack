using System.Collections;
using System.Collections.Generic;
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
                if (Physics.Raycast(originPoint.position, directionPoint.TransformDirection(Vector3.forward), out enemy, cannonRange, enemyLayer))
                {
                    enemy.collider.GetComponent<Damageable>().TakeDamage(damage);
                }
                frameCounter = 0;
                ammoLeft--;
                PlayerController.uiAmmoTracker.UpdateWeaponAmmoInUI(Ammunition);
            }
        }
    }

    public override void SetWeapon(WeaponData weapon)
    {
        base.SetWeapon(weapon);
        PlayerController.uiAmmoTracker.AddWeaponIcon(weapon.iconPath);
    }
}
