using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemigoM : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
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