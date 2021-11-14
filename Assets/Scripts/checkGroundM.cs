using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGroundM : MonoBehaviour
{
    public static bool isGround;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
    }
}