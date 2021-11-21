using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoDanioM : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player damaged");          
            Destroy(collision.gameObject);
        }
    }
}
