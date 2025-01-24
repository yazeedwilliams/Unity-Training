using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30.0f;
    private float leftBound = -15.0f;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
