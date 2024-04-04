using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatseekerMissileController : MissileController
{
    private Transform aimTransform;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(ActiveCountdown(Constants.HeatseekerMissile.activeTime));
    }

    // Update is called once per frame
    protected override void Update()
    {
        //missileBody.transform.LookAt(target);
    }

    private void FixedUpdate()
    {
        missileBody.AddRelativeForce(Constants.MissileSpeed * Vector3.forward, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.HeatSignatureTag))
        {
            Debug.Log("Detected " + other.transform.parent.name);
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.HeatSignatureTag))
        {
            Debug.Log("Leaving " + other.transform.parent.name);
            target = null;
        }
    }

}
