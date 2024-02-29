using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerControls.IGameplayActions
{

    private PlayerControls controls;
    [SerializeField]
    private Rigidbody rafaleBody;
    [SerializeField]
    private Transform cannonTransform;
    [SerializeField]
    private Transform crosshairTransform;
    [SerializeField]
    private float throttleAcceleration;
    [SerializeField]
    private float pitchFactor;
    [SerializeField]
    private float yawFactor;
    [SerializeField]
    private float rollFactor;
    [SerializeField]
    private UnityEvent<int> setSpeedometerSpeed;
    [SerializeField]
    private UnityEvent<bool, int> updateAutoSpeedIndicator;
    [SerializeField]
    private UnityEvent<float> updateHeightMeter;
    [SerializeField]
    private UnityEvent<Vector2, float> updateRadarCamera;
    [SerializeField]
    private UnityEvent trackTarget;
    [SerializeField]
    private UnityEvent stopTrackingTarget;

    private float accelerateValue;
    private float throttleInput;
    private float brakeInput;
    private Vector2 torqueInput;
    private float rollInput;
    private Animator playerAnimator;
    private float autoSpeed;
    private bool isAirbourne;
    private bool areGearsRetracted;
    private bool isAutoSpeedOn;
    private float airbourneThresholdY;
    private float planeDrag;
    private int planeMagnitudeRounded;
    private int sendHeightFrameCount;
    private int sendCoordsFrameCount;
    private int sendSpeedFrameCount;


    private const string RetractGearsAnimParamName = "RetractLandingGears";
    private const float DefaultPlaneDrag = 0.1f;
    private const float GearsDrag = 0.1f;
    private const float BrakeDrag = 1f;
    private const float AngularDragDefault = 1f;
    private const float AngularDragModifier = 0.1f;
    private const float MinSpeedAir = 100f;
    private const int SendHeightFramerule = 2;
    private const int SendCoordsFramerule = 1;
    private const int SendSpeedFramerule = 5;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.gameplay.turn.performed += OnTurn;
        controls.gameplay.turn.canceled += context => torqueInput = Vector2.zero;
        controls.gameplay.roll.performed += OnRoll;
        controls.gameplay.roll.canceled += context => rollInput = 0;
        controls.gameplay.accelerate.performed += OnAccelerate;
        controls.gameplay.accelerate.canceled += context => throttleInput = 0f;
        controls.gameplay.brake.performed += OnBrake;
        controls.gameplay.brake.canceled += context => brakeInput = 0f;
        controls.gameplay.fireweapon.performed += OnFireweapon;
        controls.gameplay.nextweapon.performed += OnNextweapon;
        controls.gameplay.previousweapon.performed += OnPreviousweapon;
        controls.gameplay.togglelandinggear.performed += OnTogglelandinggear;
        controls.gameplay.toggleautospeed.performed += OnToggleautospeed;
        controls.gameplay.tracktarget.performed += OnTracktarget;
        controls.gameplay.stoptrackingtarget.performed += OnStoptrackingtarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = transform.GetComponent<Animator>();
        isAirbourne = false;
        areGearsRetracted = false;
        isAutoSpeedOn = false;
        airbourneThresholdY = transform.position.y + 10;
        autoSpeed = 0;
        planeMagnitudeRounded = 0;
        planeDrag = DefaultPlaneDrag;
        sendHeightFrameCount = sendCoordsFrameCount = sendSpeedFrameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAirbourne && transform.position.y > airbourneThresholdY)
        {
            isAirbourne = true;
        }

        if(sendHeightFrameCount == SendHeightFramerule)
        {
            sendHeightFrameCount = 0;
            updateHeightMeter.Invoke(transform.position.y);
        }
        else
        {
            sendHeightFrameCount++;
        }
        
        if(sendCoordsFrameCount == SendCoordsFramerule)
        {
            sendCoordsFrameCount = 0;
            updateRadarCamera.Invoke(new Vector2(transform.position.x, transform.position.z), transform.rotation.eulerAngles.y);
        }
        else
        {
            sendCoordsFrameCount++;
        }

        if (sendSpeedFrameCount == SendSpeedFramerule)
        {
            sendSpeedFrameCount = 0;
            planeMagnitudeRounded = Mathf.RoundToInt(rafaleBody.velocity.magnitude);
            setSpeedometerSpeed.Invoke(planeMagnitudeRounded);
        }
        else
        {
            sendSpeedFrameCount++;
        }
    }

    void FixedUpdate()
    {
        accelerateValue = 0;
        if (throttleInput != 0)  // Accelerate using player input ignoring auto speed value
        {
            accelerateValue = throttleInput * throttleAcceleration;
            rafaleBody.angularDrag += AngularDragModifier;
        }
        else
        {
            ResetAngularDrag();
            if (isAirbourne && isAutoSpeedOn) // Maintain constant speed if enabled
            {
                accelerateValue = rafaleBody.velocity.magnitude < autoSpeed ? throttleAcceleration : 0;
            }   
        }
        
        planeDrag = DefaultPlaneDrag;
        if (brakeInput != 0)    // Brake engaged
        {
            if(rafaleBody.velocity.magnitude >= MinSpeedAir)
            {
                planeDrag += BrakeDrag * brakeInput;
            }
            rafaleBody.angularDrag += AngularDragModifier;
        }
        else
        {
            ResetAngularDrag();
            rafaleBody.AddRelativeForce(Vector3.forward * accelerateValue, ForceMode.Acceleration);
        }

        if (!areGearsRetracted) // Flying with gears deployed adds drag
        {
            planeDrag += GearsDrag;
        }
        rafaleBody.drag = planeDrag;

        if (rafaleBody.velocity.magnitude > 1)
        {
            rafaleBody.AddRelativeTorque(torqueInput.y * pitchFactor * Vector3.right, ForceMode.Acceleration);
            rafaleBody.AddRelativeTorque(torqueInput.x * yawFactor * Vector3.up, ForceMode.Acceleration);
        }

        if (isAirbourne && rollInput != 0f)
        {
            rafaleBody.AddRelativeTorque(rollInput * rollFactor * Vector3.forward, ForceMode.Acceleration);
        }
        
    }

    private void ResetAngularDrag()
    {
        if (rafaleBody.angularDrag != AngularDragDefault)
        {
            rafaleBody.angularDrag = AngularDragDefault;
        }
    }

    private void SetAutoSpeed()
    {
        isAutoSpeedOn = !isAutoSpeedOn;
        if(isAutoSpeedOn)
        {
            autoSpeed = (float)planeMagnitudeRounded;
        }
    }

    // Controls section

    private void OnEnable()
    {
        controls.gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.gameplay.Disable();
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        torqueInput = context.ReadValue<Vector2>();
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        rollInput = context.ReadValue<float>();
    }
    public void OnAccelerate(InputAction.CallbackContext context)
    {
        throttleInput = context.ReadValue<float>();
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        brakeInput = context.ReadValue<float>();
    }

    public void OnFireweapon(InputAction.CallbackContext context)
    {
        Debug.Log("Fire weapon");
    }
    public void OnNextweapon(InputAction.CallbackContext context)
    {
        Debug.Log("Next weapon");
    }
    public void OnPreviousweapon(InputAction.CallbackContext context)
    {
        Debug.Log("Previous weapon");
    }
    public void OnTogglelandinggear(InputAction.CallbackContext context)
    {
        areGearsRetracted = !areGearsRetracted;
        playerAnimator.SetBool(RetractGearsAnimParamName, areGearsRetracted);
    }
    public void OnToggleautospeed(InputAction.CallbackContext context)
    {
        SetAutoSpeed();
        updateAutoSpeedIndicator.Invoke(isAutoSpeedOn, planeMagnitudeRounded);
    }
    public void OnTracktarget(InputAction.CallbackContext context)
    {
        trackTarget.Invoke();
    }
    public void OnStoptrackingtarget(InputAction.CallbackContext context)
    {
        stopTrackingTarget.Invoke();
    }

}
