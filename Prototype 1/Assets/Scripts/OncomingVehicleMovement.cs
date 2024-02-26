using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingVehicleMovement : MonoBehaviour
{
    private float vehicleSpeed = 25.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * vehicleSpeed);
    }
}
