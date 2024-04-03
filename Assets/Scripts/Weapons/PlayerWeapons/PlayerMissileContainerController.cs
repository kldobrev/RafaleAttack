using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMissileContainerController : MissileContainerController
{
    private WeaponData missileType;

    public override void Fire()
    {
        if (missileReady)
        {
            missileReady = false;
            currentSpawnPosIdx = currentSpawnPosIdx == 0 ? 1 : 0;
            Transform missile = Instantiate(missileTypePrefab, originPoint).transform;
            missile.Translate(spawnPositions[currentSpawnPosIdx]);
            missile.AddComponent<HeatseekerMissileController>();
            missile.GetComponent<MissileController>().ConfigureMissile(missileType);
            StartCoroutine(MissileReadyCountdown());
            ammoLeft--;
            PlayerController.uiAmmoTracker.UpdateWeaponAmmoInUI(Ammunition);
        }
    }
    public override void SetWeapon(WeaponData weapon)
    {
        base.SetWeapon(weapon);
        PlayerController.uiAmmoTracker.AddWeaponIcon(weapon.iconPath);
        missileType = weapon;
    }
}
