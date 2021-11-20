using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoM : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    float speedWalk = 2.5f;
    float speedRun = 3;
    public GameObject target;
    public bool atacando;

    public float rango_vision = 2;
    public float rango_ataque = 0.3f;
    public GameObject rango;
    public GameObject hit;

    public GameObject obj;

    int sw;
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("knight_attack_0");    //nombre del jugador

        obj = GameObject.FindGameObjectWithTag("tDragon");
    }
    void Update()
    {
        comportamientos();
    }
    public void final_ani()
    {
        ani.SetBool("atack", false);
        atacando = false;
        rango.GetComponent<BoxCollider>().enabled = true;
    }
    public void colliderWeaponTrue()
    {
        hit.GetComponent<BoxCollider>().enabled = true;
    }
    public void colliderWeaponFalse()
    {
        hit.GetComponent<BoxCollider>().enabled = false;
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("limIni"))
        {
            sw = 1;
        }
        if (coll.CompareTag("limFin"))
        {
            sw = 2;
        }
    }
    public void comportamientos()
    {
        if ((Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando) || (Mathf.Abs(transform.position.y - target.transform.position.y) > rango_vision && !atacando))
        {
            //ani.SetBool("run", false);
            ani.SetBool("walk", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 3)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;
                case 2:
                    switch (direccion)
                    {
                        case 0:
                            if (sw == 2)
                            {
                                transform.rotation = Quaternion.Euler(0, 180, 0);
                                print("coll1");
                            }
                            else
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                print("coll1");
                            }
                            transform.Translate(Vector3.right * speedWalk * Time.deltaTime);
                            break;
                        case 1:
                            if (sw == 1)
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                print("coll1");
                            }
                            else
                            {
                                transform.rotation = Quaternion.Euler(0, 180, 0);
                                print("coll1");
                            }
                            transform.Translate(Vector3.right * speedWalk * Time.deltaTime);
                            break;
                    }
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacando)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("walk", true);  //aqui va animacion de correr, pero no tango los sprites del personaje corriendo :'v
                    transform.Translate(Vector3.right * speedRun * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    ani.SetBool("atack", false);
                }
                else
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("walk", true);  //aqui va animacion de correr, pero no tango los sprites del personaje corriendo :'v
                    transform.Translate(Vector3.right * speedRun * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    ani.SetBool("atack", false);
                }
            }
            else
            {
                if (!atacando)
                {
                    if (transform.position.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ani.SetBool("walk", false);
                    //ani.SetBool("run", false);                   
                }
            }
        }
    }
}