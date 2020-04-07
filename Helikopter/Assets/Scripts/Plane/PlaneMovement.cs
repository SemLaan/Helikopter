﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{

    [SerializeField] private float motorPower = 1f;
    [SerializeField] private float liftCoefficient = 1f;

    private Vector2 leftJoystick, rightJoystick;
    private Controls controls;

    private new Rigidbody rigidbody;



    private void Awake()
    {

        rigidbody = GetComponent<Rigidbody>();
        controls = new Controls();
        controls.Enable();
    }



    private void FixedUpdate()
    {
        // Collecting input
        Vector2 leftJoystick = controls.Gameplay.left.ReadValue<Vector2>();
        Vector2 rightJoystick = controls.Gameplay.right.ReadValue<Vector2>();

        // Moving if the player is pushing the left joystick
        if (leftJoystick.y > 0)
            rigidbody.AddRelativeForce(new Vector3(0, 0, motorPower * leftJoystick.y));

        // Adding lift force
        rigidbody.AddForce(new Vector3(0, Lift));


    private float Lift
    {
        get => (liftCoefficient * Mathf.Pow(rigidbody.velocity.magnitude, 2f)) / 2f; // TODO: wing area
    }
}
