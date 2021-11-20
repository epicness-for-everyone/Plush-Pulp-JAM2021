using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrChange : MonoBehaviour
{
    private Transform destino;
    public bool ejez;
    public bool inv;
    // Start is called before the first frame update
    void Start()
    {
        destino= transform.GetChild(0).GetComponent<Transform>();
    }

    // Update is called once per frame
    //void Update(){}
    //Getters and Setters
    public bool getEjeZ(){
        return ejez;
    }
    public bool getInv(){
        return inv;
    }
    public Transform getDestino(){
        return destino;
    }
}
