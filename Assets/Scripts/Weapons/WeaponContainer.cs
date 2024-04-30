using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponContainer : MonoBehaviour
{
    [SerializeField]
    protected Transform originPoint;
    [SerializeField]
    protected Transform directionPoint;
    protected int capacity;
    protected int ammoLeft;
    public abstract float Range { get; }
    public abstract float LockingStep { get; }
    public int Ammunition => ammoLeft;

    public abstract void Fire();
    public abstract void StopFiring();
    public abstract void SetWeapon(WeaponData weapon);
}
