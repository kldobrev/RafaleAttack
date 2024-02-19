using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private TextMeshProUGUI speedometer;
    [SerializeField]
    private TextMeshProUGUI autoSpeedIndicator;
    [SerializeField]
    private Slider heightMeter;
    [SerializeField]
    private GameObject [] trackerArrows;
    [SerializeField]
    private Transform trackerPointer;


    private int speedDisplayed;
    private const string DefaultSpeedValue = "Speed: 0000 km/h";
    private const string DefaultAutoSpeedValue = "Auto speed: 0000 km/h";
    private const float HeightMeterValueMin = 0f;
    private const float HeightMeterValueAlert = 1000f;
    private const float HeightMeterValueMax = 15230f;
    private Color32 heightAboveAlertColor;
    private Color32 heightBelowAlertColor;
    private Color32 autoSpeedColorOff;
    private Color32 autoSpeedColorOn;
    private Image heightMeterBkg;
    private Vector3 objectViewPosition;
    private Vector2 trackerPointerPosition;
    private GameObject trackerPointerObject;
    private TextMeshProUGUI trackerDistance;

    // Start is called before the first frame update
    void Start()
    {
        speedometer.text = DefaultSpeedValue;
        autoSpeedIndicator.text = DefaultAutoSpeedValue;
        speedDisplayed = 0;
        autoSpeedColorOff = new Color32(130, 130, 130, 190);
        autoSpeedColorOn = new Color32(53, 255, 0, 255);
        heightAboveAlertColor = new Color32(80, 255, 0, 255);
        heightBelowAlertColor = new Color32(255, 141, 0, 255);
        autoSpeedIndicator.color = autoSpeedColorOff;
        heightMeter.value = 0f;
        heightMeter.minValue = HeightMeterValueMin;
        heightMeter.maxValue = HeightMeterValueMax;
        heightMeterBkg = heightMeter.GetComponentInChildren<Image>();
        heightMeterBkg.color = heightBelowAlertColor;
        trackerPointerObject = trackerPointer.gameObject;
        trackerDistance = trackerPointer.GetComponentInChildren<TextMeshProUGUI>();
        trackerDistance.text = "999999";
    }


    private void SetActiveAndColour(GameObject obj, bool activate, bool isEnemy)
    {
        if(obj.activeSelf != activate)
        {
            if(activate)
            {
                obj.GetComponent<RawImage>().color = isEnemy ? Color.red : Color.green;
            }
            obj.SetActive(activate);
        }
    }

    public void UpdateSpeedometer(int newSpeed)
    {
        if(newSpeed != speedDisplayed)
        {
            speedDisplayed = newSpeed;
            speedometer.text = "Speed: " + newSpeed.ToString().PadLeft(4, '0') + " km/h";
        }
    }

    public void ToggleAutoSpeed(bool isTurnedOn, int newAutoSpeed)
    {
        if(isTurnedOn)
        {
            autoSpeedIndicator.text = "Auto speed: " + newAutoSpeed.ToString().PadLeft(4, '0') + " km/h";
            autoSpeedIndicator.color = autoSpeedColorOn;
        }
        else
        {
            autoSpeedIndicator.color = autoSpeedColorOff;
        }
    }

    public void UpdateHeightMeter(float height)
    {
        if (height <= HeightMeterValueAlert && heightMeter.maxValue != HeightMeterValueAlert)
        {
            heightMeter.maxValue = HeightMeterValueAlert;
            heightMeter.minValue = 0f;
            heightMeterBkg.color = heightBelowAlertColor;
        }
        else if (height > HeightMeterValueAlert && heightMeter.maxValue != HeightMeterValueMax)
        {
            heightMeter.maxValue = HeightMeterValueMax;
            heightMeter.minValue = HeightMeterValueAlert;
            heightMeterBkg.color = heightAboveAlertColor;
        }
        heightMeter.value = height;
    }

    public void UpdateTracker(Vector3 objectPosition, bool isEnemy)
    {
        objectViewPosition = mainCamera.WorldToViewportPoint(objectPosition);
        if(objectViewPosition.y > 1)    // Object is to the top of the screen
        {
            SetActiveAndColour(trackerArrows[0], true, isEnemy);
            SetActiveAndColour(trackerArrows[1], false, isEnemy);
        }
        else if(objectViewPosition.y < -1)    // Object is to the bottom of the screen
        {
            SetActiveAndColour(trackerArrows[1], true, isEnemy);
            SetActiveAndColour(trackerArrows[0], false, isEnemy);
        }
        else
        {
            SetActiveAndColour(trackerArrows[0], false, isEnemy);
            SetActiveAndColour(trackerArrows[1], false, isEnemy);
        }

        if (objectViewPosition.x > 1)    // Object is to the right of the screen
        {
            SetActiveAndColour(trackerArrows[3], true, isEnemy);
            SetActiveAndColour(trackerArrows[2], false, isEnemy);
        }
        else if (objectViewPosition.x < -1)    // Object is to the left of the screen
        {
            SetActiveAndColour(trackerArrows[2], true, isEnemy);
            SetActiveAndColour(trackerArrows[3], false, isEnemy);
        }
        else
        {
            SetActiveAndColour(trackerArrows[2], false, isEnemy);
            SetActiveAndColour(trackerArrows[3], false, isEnemy);
        }

        if(objectViewPosition.y >- 1 && objectViewPosition.y < 1 && objectViewPosition.x > -1 && objectViewPosition.x < 1)
        {
            if(objectViewPosition.z > 0)    // Object is in viewing range
            {
                SetActiveAndColour(trackerPointerObject, true, isEnemy);
                trackerPointerPosition = mainCamera.ViewportToScreenPoint(objectViewPosition);
                trackerPointer.position = trackerPointerPosition;
                trackerDistance.text = Mathf.Round(objectViewPosition.z).ToString();
            }
        }
        else
        {
            SetActiveAndColour(trackerPointerObject, false, isEnemy);
        }

    }

}
