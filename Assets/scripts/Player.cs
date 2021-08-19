using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTrippleShot = false;
    [SerializeField]
    private float playerMoveSpeed; 
    private float horizontalInput,verticalInput;
    public GameObject laserPrefab,tripleLaserPrefab;
    public float fireRate = 0.25f;
    public float canFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (Time.time > canFire)
        {
            if (canTrippleShot == true)
            {
                Instantiate(tripleLaserPrefab, transform.position, Quaternion.identity); //centre
                
            }
            else
            {
                Instantiate(laserPrefab, transform.position, Quaternion.identity);
            }
        }
       
        canFire = Time.deltaTime * fireRate;

    }
    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * playerMoveSpeed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * playerMoveSpeed * verticalInput);


        //player Boundaries for y direction
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
        //player boundaries for x direction
        /* if (transform.position.x > 8.2)
         {
             transform.position = new Vector3(8.2f, transform.position.y, 0);
         }
         else if (transform.position.x < -8.2)
         {
             transform.position = new Vector3(-8.2f, transform.position.y, 0);
         }*/

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }
}
        

