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
    protected Transform cannonEffectPoint;
    [SerializeField]
    protected int rateOfFireFrames = 3;

    protected ParticleSystem cannonFireEffect;
    protected int damage;
    protected int frameCounter;
    protected bool isFiring;
    protected float cannonRange;
    protected int enemyLayer;
    protected RaycastHit[] hits;
    protected RaycastHit enemy;
    protected int hitsDetected;
    public override float Range => cannonRange;
    public override float LockingStep => 0;


    // Start is called before the first frame update
    public virtual void Start()
    {
        frameCounter = 0;
        isFiring = false;
        enemyLayer = LayerMask.GetMask(Constants.PlayerLayerName);
        hits = new RaycastHit[6];
    }

    // Update is called once per frame
    void Update()
    {
        if(ammoLeft != 0 && isFiring)
        {
            frameCounter++;
            if (frameCounter == rateOfFireFrames)
            {
                ShootCannon(Constants.PlayerTagName);
            }
        }
    }
    protected void ShootCannon(string targetTag)
    {
        hitsDetected = Physics.RaycastNonAlloc(originPoint.position, directionPoint.TransformDirection(Vector3.forward),
                    hits, cannonRange, enemyLayer);
        frameCounter = 0;
        ammoLeft--;
        if (hitsDetected != 0)
        {
            for (int i = 0; i != hitsDetected; i++)
            {
                if (hits[i].collider != null && hits[i].collider.CompareTag(targetTag))
                {
                    hits[i].collider.GetComponent<Damageable>().TakeDamage(damage);
                }
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
        GameObject particleEffectObj = Instantiate(Resources.Load<GameObject>(weapon.particleSystemPath), cannonEffectPoint.transform);
        particleEffectObj.transform.parent = cannonEffectPoint;
        cannonFireEffect = particleEffectObj.GetComponent<ParticleSystem>();
    }

}
