using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    private float _speed = .3f;

    private Vector2 _moveInput;

    private Rigidbody _rb;

    private GameObject _ship;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _ship = GameObject.Find("Ship");
    }
    void Update()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.y = Input.GetAxis("Vertical");
        _moveInput.Normalize();

        //_rb.velocity = 
        Vector3 _position = new Vector3(_moveInput.x * _speed, _rb.velocity.y, _moveInput.y * _speed);
        
        transform.position += _position;
    }
}
