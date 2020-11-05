using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody playerRb;

    public GameObject MoveCube;

    int oncol = 0;
    float jump = 10.0f;
    float gravity = 2.0f;
    float speed = 6.0f;

    private float CurrentPosZ;
    private float CurrentPosY;

    int spacePressed = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * horizontal * speed);

        if (oncol == 1) //Touching MoveCube
        {
            followObject();
        }
        JumpPlayer();
    }

    void followObject()
    { 
         transform.position = new Vector3(transform.position.x, transform.position.y, MoveCube.transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MoveCube"))
        {
            oncol = 1;
            spacePressed = 0;
            Zforward();
        }
        if (collision.gameObject.CompareTag("StartCube"))
        {
            oncol = 0;
            spacePressed = 0;
        }
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spacePressed < 2)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            spacePressed++;
        }
    }

    void Zforward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
