using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed=10;
    public float lookSpeed=10;

    void LookAtTarget()
    {
        Vector3 _lookDirection=target.position-transform.position;
        Quaternion _rot=Quaternion.LookRotation(_lookDirection,Vector3.up);
        transform.rotation=Quaternion.Lerp(transform.rotation, _rot, lookSpeed*Time.deltaTime);
    }
    void MoveToTarget()
    {
        Vector3 _targetPos = target.position +
            target.forward * offset.z +
            target.right * offset.x +
            target.up * offset.y;
        transform.position=Vector3.Lerp(transform.position,_targetPos,followSpeed*Time.deltaTime);
    }
    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
