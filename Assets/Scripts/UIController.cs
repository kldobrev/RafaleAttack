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
    private TextMeshProUGUI speedometer;
    [SerializeField]
    private TextMeshProUGUI autoSpeedIndicator;
    [SerializeField]
    private Slider heightMeter;
    [SerializeField]
    private TextMeshProUGUI heightNumeric;
    [SerializeField]
    private Transform crosshairUITransform;
    [SerializeField]
    private Transform crshPositionTransform;
    [SerializeField]
    private Camera mainCamera;

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
    private Vector2 crosshairUIPosition;

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
        crosshairUIPosition = Vector2.zero;
    }

    private void Update()
    {
        UpdateCrosshairTransform();
    }

    private void UpdateCrosshairTransform()
    {
        crosshairUIPosition = mainCamera.WorldToScreenPoint(crshPositionTransform.position);
        crosshairUITransform.position = crosshairUIPosition;
        crosshairUITransform.eulerAngles = Vector3.forward * crshPositionTransform.eulerAngles.z;
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
            heightNumeric.color = heightBelowAlertColor;
        }
        else if (height > HeightMeterValueAlert && heightMeter.maxValue != HeightMeterValueMax)
        {
            heightMeter.maxValue = HeightMeterValueMax;
            heightMeter.minValue = HeightMeterValueAlert;
            heightMeterBkg.color = heightAboveAlertColor;
            heightNumeric.color = heightAboveAlertColor;
        }
        heightMeter.value = height;
        heightNumeric.text = ((int) Mathf.Clamp(height, 0f, HeightMeterValueMax)).ToString().PadLeft(5, '0') + " m";
    }

}
