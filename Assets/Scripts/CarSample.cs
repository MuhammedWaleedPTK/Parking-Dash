using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSample : MonoBehaviour
{

    [SerializeField] private WheelCollider frontLeftWheel;
    [SerializeField] private WheelCollider frontRightWheel;
    [SerializeField] private WheelCollider rearLeftWheel;
    [SerializeField] private WheelCollider rearRightWheel;
    [SerializeField] private float maxSteeringAngle = 30f;
    [SerializeField] private float maxMotorTorque = 300f;
    [SerializeField] private float maxBrakeTorque = 500f;

    private void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;

        rearLeftWheel.motorTorque = motor;
        rearRightWheel.motorTorque = motor;
        Debug.Log(frontLeftWheel.rpm);

        if (Input.GetKey(KeyCode.Space))
        {
            frontLeftWheel.brakeTorque = maxBrakeTorque;
            frontRightWheel.brakeTorque = maxBrakeTorque;
            rearLeftWheel.brakeTorque = maxBrakeTorque;
            rearRightWheel.brakeTorque = maxBrakeTorque;
        }
        else
        {
            frontLeftWheel.brakeTorque = 0;
            frontRightWheel.brakeTorque = 0;
            rearLeftWheel.brakeTorque = 0;
            rearRightWheel.brakeTorque = 0;
        }
    }

}
