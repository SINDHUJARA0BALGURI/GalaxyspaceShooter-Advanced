using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerMoveSpeed; 
    private float horizontalInput,verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime*playerMoveSpeed*horizontalInput);
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
        if (transform.position.x > 8.2)
        {
            transform.position = new Vector3(8.2f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.2)
        {
            transform.position = new Vector3(-8.2f, transform.position.y, 0);
        }


    }
}
