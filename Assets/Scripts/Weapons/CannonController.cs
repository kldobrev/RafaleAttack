using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CannonController : WeaponContainer
{
    [SerializeField]
    protected int rateOfFireFrames = 3;
    [SerializeField]
    protected UnityEvent<int> giveDamage;

    protected ParticleSystem cannonFireEffect;
    protected int damage;
    protected int frameCounter;
    protected bool isFiring;
    protected float cannonRange;
    protected int enemyLayer;
    protected RaycastHit enemy;


    // Start is called before the first frame update
    public virtual void Start()
    {
        frameCounter = 0;
        isFiring = false;
        enemyLayer = LayerMask.GetMask(Constants.PlayerLayerName);
    }

    // Update is called once per frame
    void Update()
    {
        if(ammoLeft != 0 && isFiring)
        {
            frameCounter++;
            if (frameCounter == rateOfFireFrames)
            {
                if(Physics.Raycast(originPoint.position, directionPoint.TransformDirection(Vector3.forward), out enemy, cannonRange, enemyLayer))
                {
                    enemy.collider.GetComponent<Damageable>().TakeDamage(damage);
                }
                frameCounter = 0;
                ammoLeft--;
            }
        }
    }

    public override void Fire()
    {
        if (ammoLeft != 0)
        {
            isFiring = true;
            if (!cannonFireEffect.isEmitting)
            {
                cannonFireEffect.Play();
            }
        }
    }

    public override void StopFiring()
    {
        if(isFiring)
        {
            frameCounter = 0;
            isFiring = false;
            cannonFireEffect.Stop();
        }
    }

    public override void SetWeapon(WeaponData weapon)
    {
        damage = weapon.damageAmount;
        capacity = weapon.capacity;
        ammoLeft = capacity;
        cannonRange = weapon.range;
        GameObject particleEffectObj = Instantiate(Resources.Load<GameObject>(weapon.particleSystemPath), originPoint.transform);
        particleEffectObj.transform.parent = originPoint;
        cannonFireEffect = particleEffectObj.GetComponent<ParticleSystem>();
    }

}
