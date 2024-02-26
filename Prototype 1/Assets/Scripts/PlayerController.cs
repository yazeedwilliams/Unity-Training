using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float speed = 25.0f;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 70.0f;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if (isOnGround())
        {   
            // Moves the vehicle forward/backward based on vertical input
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            // Rotates vehicle based on horizontal input
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText($"Speed: {speed} kph");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText($"RPM: {rpm}");
        }
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
