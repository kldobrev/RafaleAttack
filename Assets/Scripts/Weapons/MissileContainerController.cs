using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileContainerController : WeaponContainer
{
    [SerializeField]
    protected Vector3 [] spawnPositions;
    protected int currentSpawnPosIdx;
    protected bool missileReady;
    public override float Range => 0;

    [SerializeField]
    protected GameObject missileTypePrefab;

    public override void Fire()
    {
        if(missileReady)
        {
            missileReady = false;
            currentSpawnPosIdx = currentSpawnPosIdx == 0 ? 1 : 0;
            Transform missile = Instantiate(missileTypePrefab, originPoint).transform;
            missile.Translate(spawnPositions[currentSpawnPosIdx]);
            StartCoroutine(MissileReadyCountdown());
            ammoLeft--;
        }
    }

    public override void StopFiring()
    {
        return;
    }

    public override void SetWeapon(WeaponData weapon)
    {
        capacity = weapon.capacity;
        ammoLeft = capacity;
        currentSpawnPosIdx = 0;
        missileReady = true;
    }

    protected IEnumerator MissileReadyCountdown()
    {
        yield return new WaitForSeconds(Constants.FireMissileWaitSeconds);
        missileReady = true;
    }
}
