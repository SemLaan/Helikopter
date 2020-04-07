using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{

    [SerializeField] private float motorPower = 1f;

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

        Vector2 leftJoystick = controls.Gameplay.left.ReadValue<Vector2>();
        Vector2 rightJoystick = controls.Gameplay.right.ReadValue<Vector2>();

        if (leftJoystick.y > 0)
            rigidbody.AddRelativeForce(new Vector3(0, 0, motorPower * leftJoystick.y));
    }
}
