using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(horizontalInput);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
