using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileController : MonoBehaviour
{
    [SerializeField]
    protected Collider missileCollider;
    protected Rigidbody missileBody;
    protected Transform attacker;
    protected Transform target;

    // Update is called once per frame
    protected abstract void Update();

    protected IEnumerator ActiveCountdown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    public void ConfigureMissile(Transform source, float startVelocity)
    {
        attacker = source;
        missileBody = transform.GetComponent<Rigidbody>();
        missileBody.AddRelativeForce(startVelocity * Vector3.forward, ForceMode.VelocityChange);
        missileBody.rotation = attacker.rotation;
        //missileCollider.excludeLayers = source.gameObject.layer;
        // Todo: exclude parent layer correctly
    }

}
