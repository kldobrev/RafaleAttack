using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeahawkController : MonoBehaviour
{

    [SerializeField]
    private float sideTorque = 0; 
    [SerializeField]
    private float frontTorque = 0;

    private Transform mainPropeller;
    private Transform smallPropeller;
    private Rigidbody heliBody;

    private Vector3 strartingPosition;
    private float range;


    // Start is called before the first frame update
    void Start()
    {
        mainPropeller = transform.GetChild(Constants.MainPropellerIndex);
        smallPropeller = transform.GetChild(Constants.SmallPropellerIndex);
        heliBody = transform.GetComponent<Rigidbody>();
        strartingPosition = heliBody.position;
    }

    // Update is called once per frame
    void Update()
    {
        mainPropeller.Rotate(Constants.MainPropellerSpeed * Time.deltaTime * Vector3.up);
        smallPropeller.Rotate(Constants.SmallPropellerSpeed * Time.deltaTime * Vector3.right);
    }
    private void FixedUpdate()
    {
        if(heliBody.position.y < Constants.MaxMaintainedHeight)
        {
            heliBody.AddRelativeForce(Constants.Speed * Vector3.up, ForceMode.Acceleration);
        }

        if(frontTorque != 0)
        {
            heliBody.AddRelativeTorque(frontTorque * Vector3.right);
        }
        if(sideTorque != 0)
        {
            heliBody.AddRelativeTorque(sideTorque * Vector3.forward);
        }
    }
}
