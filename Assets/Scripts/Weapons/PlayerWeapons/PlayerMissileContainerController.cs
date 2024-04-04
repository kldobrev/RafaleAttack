using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMissileContainerController : MissileContainerController
{
    public override void Fire()
    {
        if (missileReady && ammoLeft != 0)
        {
            missileReady = false;
            currentSpawnPosIdx = currentSpawnPosIdx == 0 ? 1 : 0;
            Transform missile = Instantiate(missileTypePrefab, originPoint).transform;
            missile.Translate(spawnPositions[currentSpawnPosIdx]);
            missile.GetComponent<MissileController>().ConfigureMissile(transform, aircraftBody.velocity.magnitude);
            StartCoroutine(MissileReadyCountdown());
            ammoLeft--;
            PlayerController.uiAmmoTracker.UpdateWeaponAmmoInUI(Ammunition);
        }
    }
    public override void SetWeapon(WeaponData weapon)
    {
        base.SetWeapon(weapon);
        PlayerController.uiAmmoTracker.AddWeaponIcon(weapon.iconPath);
        missileTypePrefab = Resources.Load<GameObject>(weapon.prefabPath);
    }
}
