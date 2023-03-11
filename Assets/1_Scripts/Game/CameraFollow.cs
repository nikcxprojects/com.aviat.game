using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offset;
    [SerializeField] private float _smoothTime;

    void FixedUpdate()
    {
        if(!_target) return;
        var smoothPos = Vector3.Lerp(transform.position, _target.position, _smoothTime * Time.fixedDeltaTime);
        smoothPos = new Vector3(smoothPos.x + _offset, transform.position.y, transform.position.z);
        transform.position = smoothPos;
    }
}
