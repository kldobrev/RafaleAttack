using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int shield;

    public void TakeDamage(int amount)
    {
        shield -= amount;
        if(shield <= 0)
        {
            Destroy(gameObject);
        }
    }
}
