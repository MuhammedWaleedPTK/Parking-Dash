using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCarContrller : MonoBehaviour
{
    //input variables
    private float hInput;
    private float vInput;

    //wheel collider reference

    public WheelCollider frontRightW, frontLeftW;
    public WheelCollider rearRightW, rearLeftW;

    // wheel transform reference
    
    public Transform frontRightT, frontLeftT;
    public Transform rearRightT, rearLeftT;

    // steer and speed 

    public float maxSteerAngle = 30;
    private float steerAngle;

    public float motorForce = 1000f;





    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPose();

    }


    void GetInput()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

    }
    void Steer()
    {
        steerAngle = hInput * maxSteerAngle;
        frontRightW.steerAngle= steerAngle;
        frontLeftW.steerAngle= steerAngle;
    }
    void Accelerate()
    {
        frontRightW.motorTorque= vInput*motorForce;
        frontLeftW.motorTorque= vInput*motorForce;
    }
    void UpdateWheelPose()
    {
        UpdateWheelPose(frontLeftW, frontLeftT);
        UpdateWheelPose(frontRightW, frontRightT);
        UpdateWheelPose(rearLeftW, rearLeftT);
        UpdateWheelPose(rearRightW, rearRightT);

    }
    void UpdateWheelPose(WheelCollider _collider,Transform _transform)
    {
        Vector3 _pos= _transform.position;
        Quaternion _quat=_transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);
        _transform.position=_pos;
        _transform.rotation=_quat;
    }
}
