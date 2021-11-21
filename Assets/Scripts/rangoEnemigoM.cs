using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangoEnemigoM : MonoBehaviour
{
    public Animator ani;
    public enemigoM enemigo;
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            ani.SetBool("walk", false);
            //ani.SetBool("run", false);
            ani.SetBool("atack", true);
            enemigo.atacando = true;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    void Start()
    {

    }
    void Update()
    {

    }
}