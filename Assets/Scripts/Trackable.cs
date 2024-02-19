using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trackable : MonoBehaviour
{
    [SerializeField]
    private bool isEnemy = false;
    [SerializeField]
    private UnityEvent stopTrackingRequest;
    [SerializeField]
    private UnityEvent<Vector3, bool> sendCoordinatesToTracker;

    private Vector2 player2Dposition;
    private Vector2 object2DPosition;
    private Transform playerTransform;
    private bool isTracked;
    public const float CoveredDistance = 40000;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        isTracked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInPlayerRange())
        {
            if(!isTracked)
            {
                isTracked = true;
            }
            sendCoordinatesToTracker.Invoke(transform.position, isEnemy);
        }
        else
        {
            isTracked = false;
            stopTrackingRequest.Invoke();
        }

        sendCoordinatesToTracker.Invoke(transform.position, isEnemy);
    }

    private bool IsInPlayerRange()
    {   // Ignoring vertical axis for radar tracking
        player2Dposition = new Vector2(playerTransform.position.x, playerTransform.position.z);
        object2DPosition = new Vector2(transform.position.x, transform.position.z);
        return Vector2.Distance(player2Dposition, object2DPosition) < CoveredDistance;
    }
}
