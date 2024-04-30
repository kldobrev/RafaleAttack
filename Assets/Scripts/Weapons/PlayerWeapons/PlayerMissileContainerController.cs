using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMissileContainerController : MissileContainerController
{
    [SerializeField]
    private CameraController cmr;
    private Transform enemyPoint;

    public override void Fire()
    {
        if (missileReady && ammoLeft != 0)
        {
            missileReady = false;
            currentSpawnPosIdx = launchPoints.Length == currentSpawnPosIdx + 1 ? 0 : currentSpawnPosIdx + 1;
            Transform missile = Instantiate(missileTypePrefab, launchPoints[currentSpawnPosIdx]).transform;
            missile.SetParent(SharedInstances.ProjectilesParent);
            missile.GetComponent<MissileController>().ConfigureMissile(transform, aircraftBody.velocity.magnitude, enemyPoint);
            StartCoroutine(MissileReadyCountdown());
            ammoLeft--;
            PlayerController.UIAmmoTracker.UpdateWeaponAmmoInUI(Ammunition);
            Debug.Log("Missile fired");
        }
    }
    public override void SetWeapon(WeaponData weapon)
    {
        base.SetWeapon(weapon);
        PlayerController.UIAmmoTracker.AddWeaponIcon(weapon.iconPath);
        missileTypePrefab = Resources.Load<GameObject>(weapon.prefabPath);
    }

    public void SetLockedTarget(Transform target)
    {
        enemyPoint = target;
    }
}
