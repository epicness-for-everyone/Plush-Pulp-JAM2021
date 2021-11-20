using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGroundM : MonoBehaviour
{
    public static bool isGround;
    private void OnTriggerEnter(Collider collision)
    {
        isGround = true;
    }
    private void OnTriggerExit(Collider collision)
    {
        isGround = false;
    }
}