using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangoEnemigoM2 : MonoBehaviour
{
    public Animator ani;
    public enemigoM2 enemigo;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("pm"))
        {
            ani.SetBool("walk", false);
            //ani.SetBool("run", false);
            ani.SetBool("atack", true);
            enemigo.atacando = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void Start()
    {

    }
    void Update()
    {

    }
}