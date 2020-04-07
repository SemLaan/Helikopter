using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCamera : MonoBehaviour
{

    [SerializeField] private new Transform camera = null;
    [SerializeField] private float verticalDistance = 1f;
    [SerializeField] private float horizontalDistance = 1f;
    private new Rigidbody rigidbody;



    private void Awake()
    {

        rigidbody = GetComponent<Rigidbody>();
    }



    private void Update()
    {

        // Updating camera position
        Vector3 horizontalPlayerDistance = -rigidbody.velocity;
        horizontalPlayerDistance.y = 0;
        horizontalPlayerDistance = horizontalPlayerDistance.normalized * horizontalDistance;
        camera.position = transform.position + horizontalPlayerDistance + (Vector3.up * verticalDistance);

        // Updating camera rotation
        camera.LookAt(transform);
    }
}
