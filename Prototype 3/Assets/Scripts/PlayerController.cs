using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource audioSource;

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            audioSource.PlayOneShot(jumpSound, 1.0f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
