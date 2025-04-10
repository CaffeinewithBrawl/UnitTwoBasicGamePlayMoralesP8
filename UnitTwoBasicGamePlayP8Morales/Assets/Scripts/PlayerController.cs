using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    public float yRange = 10.0f;
    public Transform projectileSpawnPoint;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set up to move on x axis
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // swet up to move on y axis
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(yRange, transform.position.x, transform.position.z);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(-yRange, transform.position.x, transform.position.z);
        }

        // to tell how to move horizontally
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // vertical movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // to shoot sandwich
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);

        }
    }
}
