using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TrackerController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject[] trackerArrows;
    [SerializeField]
    private Transform trackerPointer;
    [SerializeField]
    private Transform playerPoint;

    private Vector2 trackerPointerPosition;
    private GameObject trackerPointerObject;
    private TextMeshProUGUI trackerDistance;
    private Vector3 objectViewPosition;
    private Color32 enemyColour;
    private Color32 allyColour;
    private float trackableDistanceMax;
    private int radarObjectsLayer;
    private bool trackerActivated;
    private bool isTargetEnemy;
    private Transform targetPoint;
    RaycastHit [] targetsHits;
    Ray targetsRay;

    private const string EnemyPointTagName = "RadarPointEnemy";
    public const float CoveredDistance = 30000;

    // Start is called before the first frame update
    void Start()
    {
        trackerPointerObject = trackerPointer.gameObject;
        trackerDistance = trackerPointer.GetComponentInChildren<TextMeshProUGUI>();
        trackerDistance.text = "999999";
        enemyColour = new Color32(255, 66, 0, 255);
        allyColour = new Color32(0, 255, 7, 255);
        trackableDistanceMax = CoveredDistance / 2;
        trackerActivated = false;
        isTargetEnemy = false;
        radarObjectsLayer = LayerMask.GetMask("RadarTracked");
        targetsHits = new RaycastHit[2];
    }

    // Update is called once per frame
    void Update()
    {
        if(trackerActivated)
        {
            DisplayPointOnTracker();
            if (!IsInPlayerRange())
            {
                StopTracking();
            }
        }
        
    }
    private void SetActiveAndColour(GameObject obj, bool activate)
    {
        if (obj.activeSelf != activate)
        {
            if (activate)
            {
                obj.GetComponent<RawImage>().color = isTargetEnemy ? enemyColour : allyColour;
            }
            obj.SetActive(activate);
        }
    }
    private bool IsInPlayerRange()
    {   
        return objectViewPosition.z < CoveredDistance;
    }
    private void DisplayPointOnTracker()
    {
        objectViewPosition = mainCamera.WorldToViewportPoint(targetPoint.position);
        if (objectViewPosition.y > 1)    // Object is to the top of the screen
        {
            SetActiveAndColour(trackerArrows[0], true);
            SetActiveAndColour(trackerArrows[1], false);
        }
        else if (objectViewPosition.y < -1)    // Object is to the bottom of the screen
        {
            SetActiveAndColour(trackerArrows[1], true);
            SetActiveAndColour(trackerArrows[0], false);
        }
        else
        {
            SetActiveAndColour(trackerArrows[0], false);
            SetActiveAndColour(trackerArrows[1], false);
        }

        if (objectViewPosition.x > 1)    // Object is to the right of the screen
        {
            SetActiveAndColour(trackerArrows[3], true);
            SetActiveAndColour(trackerArrows[2], false);
        }
        else if (objectViewPosition.x < -1)    // Object is to the left of the screen
        {
            SetActiveAndColour(trackerArrows[2], true);
            SetActiveAndColour(trackerArrows[3], false);
        }
        else
        {
            SetActiveAndColour(trackerArrows[2], false);
            SetActiveAndColour(trackerArrows[3], false);
        }

        if (objectViewPosition.y > -1 && objectViewPosition.y < 1 && objectViewPosition.x > -1 && objectViewPosition.x < 1)
        {
            if (objectViewPosition.z > 0)    // Object is in viewing range
            {
                SetActiveAndColour(trackerPointerObject, true);
                trackerPointerPosition = mainCamera.ViewportToScreenPoint(objectViewPosition);
                trackerPointer.position = trackerPointerPosition;
                trackerDistance.text = Mathf.Round(objectViewPosition.z).ToString();
            }
        }
        else
        {
            SetActiveAndColour(trackerPointerObject, false);
        }

    }
    public void TrackTarget()
    {
        targetsRay = new Ray(playerPoint.position, playerPoint.TransformDirection(Vector3.forward));
        int numDetected = Physics.RaycastNonAlloc(targetsRay, targetsHits, trackableDistanceMax, radarObjectsLayer);
        if (numDetected != 0)
        {
            for (int i = 0; i != targetsHits.Count(); i++)
            {
                if (!trackerActivated  || (targetsHits[i].collider != null && 
                    !GameObject.ReferenceEquals(targetPoint, targetsHits[i].collider.transform)))
                {
                    targetPoint = targetsHits[i].collider.transform;
                    trackerActivated = true;
                    isTargetEnemy = targetPoint.CompareTag(EnemyPointTagName);
                    break;
                }
            }
        }
    }
    public void StopTracking()
    {
        foreach (GameObject arrow in trackerArrows)
        {
            arrow.SetActive(false);
        }
        trackerPointerObject.SetActive(false);
        trackerActivated = false;
    }

}
