using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileContainerController : WeaponContainer
{
    [SerializeField]
    protected Vector3 [] spawnPositions;
    protected int currentSpawnPosIdx;
    protected bool missileReady;
    protected Rigidbody aircraftBody;
    public override float Range => 0;

    [SerializeField]
    protected GameObject missileTypePrefab;

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
        aircraftBody = transform.GetComponent<Rigidbody>();
    }

    protected IEnumerator MissileReadyCountdown()
    {
        yield return new WaitForSeconds(Constants.FireMissileWaitSeconds);
        missileReady = true;
    }
}
