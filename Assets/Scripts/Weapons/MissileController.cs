using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileController : MonoBehaviour
{
    private float activeTime;
    private float damage;
    private float range;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        StartCoroutine(ActiveCountdown());
    }

    // Update is called once per frame
    protected abstract void Update();

    public void ConfigureMissile(WeaponData weapon)
    {
        activeTime = weapon.activeTime;
        damage = weapon.damageAmount;
        range = weapon.range;
    }

    protected IEnumerator ActiveCountdown()
    {
        yield return new WaitForSeconds(activeTime);
        Destroy(gameObject);
    }

}
