using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float smoothness = 3.6f;
    //target object
    private Transform _shipTransform;
    private Vector3 _initialOffset;
    private Vector3 _cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        _shipTransform = GameObject.Find("Cube").transform;
        _initialOffset = transform.position - _shipTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _cameraPosition = _shipTransform.position + _initialOffset;
        transform.position = Vector3.Lerp(transform.position, _cameraPosition, smoothness*Time.fixedDeltaTime);
    }
}
