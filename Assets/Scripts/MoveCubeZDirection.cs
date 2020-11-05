using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeZDirection : MonoBehaviour
{

    float speed;

    float zlimit = 22.0f;
    bool OnLimit;

    private float CurrentPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPos = transform.position.z;

        speed = Random.Range(2.0f, 15.0f); //Random Speed of Object

        if (CurrentPos < zlimit && OnLimit) //If OnLimit True
        {
            moveforward();
        }
        else if (CurrentPos > 1 && !OnLimit) //If OnLimit False
        {
            movebackward();
        }
        else
        {
            OnLimit = !OnLimit;
        }


    }


    void moveforward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    void movebackward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -speed);
    }
}
