using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerUpStrength = 30.0f;

    public float speed = 5.0f;
    public bool hasPowerup;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    private void Update()
    {
        powerUpIndicator.transform.position = transform.position + new Vector3(0.0f, -0.5f, 0.0f);
    }

    private void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerUpIndicator.SetActive(false);
    }
}
