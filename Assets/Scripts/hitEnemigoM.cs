using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemigoM : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("pm"))
        {
            print("danio");
        }
    }
    void Start()
    {

    }
    void Update()
    {

    }
}