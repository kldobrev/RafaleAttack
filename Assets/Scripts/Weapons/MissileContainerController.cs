using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileContainerController : WeaponContainer
{
    [SerializeField]
    protected Transform playerBodyTransform;
    [SerializeField]
    protected Vector3 [] spawnPositions;
    [SerializeField]
    protected GameObject missileTypePrefab;
    [SerializeField]
    protected Transform [] launchPoints;

    protected int currentSpawnPosIdx;
    protected bool missileReady;
    protected float missileRange;
    protected Rigidbody aircraftBody;
    protected float missileLockingStep;
    public override float Range => missileRange;
    public override float LockingStep => missileLockingStep;


    public override void Fire()
    {
        if (missileReady && ammoLeft != 0)
        {
            missileReady = false;
            currentSpawnPosIdx = currentSpawnPosIdx == 0 ? 1 : 0;
            Transform missile = Instantiate(missileTypePrefab, originPoint).transform;
            missile.SetParent(SharedInstances.ProjectilesParent);
            missile.Translate(spawnPositions[currentSpawnPosIdx]);
            missile.GetComponent<MissileController>().ConfigureMissile(transform, aircraftBody.velocity.magnitude, null);
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
        missileRange = weapon.range;
        currentSpawnPosIdx = 0;
        missileReady = true;
        aircraftBody = transform.GetComponent<Rigidbody>();
        missileLockingStep = weapon.lockingStep;
    }

    protected IEnumerator MissileReadyCountdown()
    {
        yield return new WaitForSeconds(Constants.FireMissileWaitSeconds);
        missileReady = true;
    }
}
