using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHazard : MonoBehaviour
{
    public float Speed;
    float Limit;
    bool LimitReached;
    float currentPosition;

    //public GameObject Hazard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position.x;
        Limit = 2.8f;

        if (currentPosition < Limit && LimitReached)
        {
            // move right
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
        else if (currentPosition > -2.8f && !LimitReached)
        {
            //move left
            transform.Translate(Vector3.back * Time.deltaTime * Speed);
        }
        else
        {
            LimitReached = !LimitReached;
        }
    }
}
