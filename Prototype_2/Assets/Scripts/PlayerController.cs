using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject projectilePrefab;
    public float projectileOffset;

    private float xRange = 19.0f;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        //Translates the player left and right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        //Keep the player in bounds
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a hamburger/food/projectile
            //Instantiate(Prefab, Position that you want for the prefab, the rotation of the prefab)
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + projectileOffset, transform.position.z), projectilePrefab.transform.rotation);
        }
    }
}
