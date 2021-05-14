using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private bool isOnGround = true;
    private Animator playerAnim;
    private AudioSource audioSource;

    public float jumpForce;
    public float gravityModifier;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            explosionParticle.Play();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtParticles.Stop();
            audioSource.PlayOneShot(crashSound, 1.0f);
        }
    }
}
