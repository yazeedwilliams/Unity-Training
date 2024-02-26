using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -8);
    public Camera firstPersonCamera;
    public Camera overHeadCamera;
    private bool isCameraActive = true;
    
    // Update is called once per frame
    void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's postiton
        transform.position = player.transform.position + offset;

        // Check if the 1 button is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // The the active camera flag
            isCameraActive = !isCameraActive;

            // If over head camera is enabled then disable first person camera and vice versa
            overHeadCamera.enabled = isCameraActive;
            firstPersonCamera.enabled = !isCameraActive;
        }
    }
}
