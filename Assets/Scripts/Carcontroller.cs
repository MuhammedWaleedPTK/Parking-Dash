using SimpleInputNamespace;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Carcontroller : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBrakForce;
    private bool isBraking;

    public Rigidbody rb;
    public Transform centreOfMass;

    [SerializeField] private float motorForce;
    [SerializeField] private float brakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] public static float speed;
    [SerializeField] private float speedClamped;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] public int isEngineRunning;
    [SerializeField] private GameObject brakeLight;
    [SerializeField] private GameObject reverseLight;
    [SerializeField] private GameObject steeringWheel;

    private MyButton myButton;
    private BrakePedalScript brakePedal;



    public GameObject forwardCamera;
    public GameObject reverseCamera;
    public GameObject CockpitCamera;
    public bool isCockpitOn = false;


    private void OnEnable()
    {
        GameManager.ToggleCockpitCamAction += CameraSwitch;
        

    }
    private void OnDisable()
    {
        GameManager.ToggleCockpitCamAction-= CameraSwitch;
    }
    

    private void Start()
    {
       myButton=FindObjectOfType<MyButton>();
       brakePedal=FindObjectOfType<BrakePedalScript>();

        reverseCamera.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (centreOfMass.position.y < -5)
        {
            GameManager.carFellAction?.Invoke();
        }
        rb.centerOfMass = centreOfMass.transform.localPosition;
        speed = rearLeftWheelCollider.rpm * rearLeftWheelCollider.radius * 2f * Mathf.PI / 10f;
        speedClamped=Mathf.Lerp(speedClamped,speed,Time.deltaTime);
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        CameraControlling();
        
        if (isBraking)
        {
            brakeLight.SetActive(true);
        }
        else
        {
            brakeLight.SetActive(false);
        }
        if (verticalInput < 0)
        {
            reverseLight.SetActive(true);

        }
        else
        {
            reverseLight.SetActive(false);
        }
        
    }

    

    private void HandleMotor()
    {
        if (isEngineRunning > 1)
        {


            if ( speed < maxSpeed&&speed>minSpeed)
            {


                frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
                frontRightWheelCollider.motorTorque = verticalInput * motorForce;
            }
            else
            {
                frontLeftWheelCollider.motorTorque = 0;
                frontRightWheelCollider.motorTorque = 0;
            }
        }
        currentBrakForce = isBraking ? brakForce : 0f;
        ApplyBraking();
    }

    private void ApplyBraking()
    {
        frontLeftWheelCollider.brakeTorque=currentBrakForce;
        frontRightWheelCollider.brakeTorque = currentBrakForce;
        rearLeftWheelCollider.brakeTorque = currentBrakForce;
        rearRightWheelCollider.brakeTorque = currentBrakForce;


    }

    private void GetInput()
    {
        horizontalInput = SimpleInput.GetAxis("Horizontal");
        verticalInput =Input.GetAxis("Vertical");
        if (myButton.isPressed)
        {
            verticalInput = myButton.dampenPressClone;
        }
        isBraking = Input.GetKey(KeyCode.Space);
        if (brakePedal.isPressed)
        {
            isBraking = true;
        }
        if (Mathf.Abs(verticalInput) > 0 && isEngineRunning == 0)
        {
            StartCoroutine(GetComponent<carEngineSound>().StartEngine());
        }
    }
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
        steeringWheel.transform.localRotation = Quaternion.Euler(0, currentSteerAngle*6, 0f);
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
    public float GetSpeedRatio()
    {
        var gas = Mathf.Clamp(Mathf.Abs( verticalInput), 0.5f, 1f);
        return speedClamped * gas / maxSpeed;
    }
    private void CameraControlling()
    {
        if (speed < -1)
        {
            reverseCamera.SetActive(true);
            forwardCamera.SetActive(false);
        }
        else
        {
            forwardCamera.SetActive(true);
            reverseCamera.SetActive(false);
        }
    }
    public void CameraSwitch()
    {
        isCockpitOn = !isCockpitOn;
        CockpitCamera.SetActive(isCockpitOn);

    }
}
