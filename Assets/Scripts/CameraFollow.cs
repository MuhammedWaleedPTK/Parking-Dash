using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;


    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleRotation()
    {
       var direction=target.position - transform.position;
        var rotaiton =Quaternion.LookRotation(direction,Vector3.up);
        transform.rotation=Quaternion.Lerp(transform.rotation, rotaiton, rotationSpeed*Time.deltaTime);
    }

    private void HandleTranslation()
    {
        var targetPositon = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPositon, translateSpeed*Time.deltaTime);
    }
}
