using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeatseekerMissileController : MissileController
{

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(ActiveCountdown(Constants.HeatseekerMissile.activeTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform colliderTransform = other.transform;
        if (colliderTransform.CompareTag(Constants.HeatSignatureTag))   // Detected heat signature of foreign aircraft
        {
            tgtHeatSignTransform = colliderTransform;
            if (colliderTransform.parent.CompareTag(Constants.PlayerTagName))
            {
                target = PlayerController.PlayerBodyTransform;
            }
            else
            {
                target = colliderTransform.parent;
            }
            UnassignTargetIfNotVisible();
        }
        else if (GameObject.ReferenceEquals(colliderTransform, target)) // Hit aircraft body
        {
            Debug.Log("Hit " + colliderTransform.name);
            //colliderTransform.GetComponent<Damageable>().TakeDamage(Constants.HeatseekerMissile.damageAmount);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameObject.ReferenceEquals(other.transform, tgtHeatSignTransform))
        {
            Debug.Log("Leaving " + other.transform.name);
            target = null;
            tgtHeatSignTransform = null;
        }
    }

}
