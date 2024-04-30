using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MissileController : MonoBehaviour
{
    [SerializeField]
    protected float rotationSpeed;
    [SerializeField]
    protected float moveSpeed;

    protected Rigidbody missileBody;
    protected Transform attacker;
    protected Transform target;
    protected string targetTag;
    protected Transform tgtHeatSignTransform;
    protected Vector3 deltaDirection;
    protected Vector2 angleToTarget;
    protected Vector2 maintainAngle;
    protected float startingSpeed;
    protected float currentSpeed;


    protected virtual void FixedUpdate()
    {
        if (target != null)
        {
            transform.forward = Vector3.Slerp(transform.forward, deltaDirection, rotationSpeed * Time.fixedDeltaTime);
            Physics.SyncTransforms();
        }

        currentSpeed = Mathf.Clamp(currentSpeed + moveSpeed, startingSpeed, Constants.MaxMissileSpeed);
        missileBody.MovePosition(transform.position + (currentSpeed * Time.fixedDeltaTime * transform.forward));
    }

    protected IEnumerator ActiveCountdown(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Missile timeout");
        Destroy(gameObject);
    }

    public void ConfigureMissile(Transform source, float startVelocity, Transform enemy)
    {
        attacker = source;
        missileBody = transform.GetComponent<Rigidbody>();
        startingSpeed = Mathf.Clamp(startVelocity + Constants.MissileSpeedPush, startVelocity, Constants.MaxMissileSpeed);
        currentSpeed = startingSpeed;
        missileBody.rotation = attacker.rotation;
        gameObject.layer = attacker.gameObject.layer;
        if(enemy != null)
        {
            target = enemy;
            SetDeltaDirection();
        }
    }

    protected void SetDeltaDirection()
    {
        deltaDirection = (target.position - transform.position).normalized;
    }

    protected void UnassignTargetIfNotVisible()
    {
        SetDeltaDirection();
        float unsignedAngle = Vector3.Angle(transform.forward, deltaDirection);
        if (unsignedAngle <= 0 || unsignedAngle > 60)
        {
            target = null;
            tgtHeatSignTransform = null;
        }
    }

}
