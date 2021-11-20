using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoDanioM : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("pm"))
        {
            Debug.Log("player damaged");
            //print("dacio");
            Destroy(collision.gameObject);
        }
    }
}
