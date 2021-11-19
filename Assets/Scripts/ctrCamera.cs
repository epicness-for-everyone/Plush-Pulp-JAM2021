using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrCamera : MonoBehaviour
{
    [Range(0f,2f)]public float smooth;
    public GameObject follow;
    public GameObject Angulos;
    public Transform[] pos;
    private Vector3 posAct;
    private Vector3 posDest;
    private ctrPlayerMov datosPlayer;
    public int m=0;
    // Start is called before the first frame update
    void Start()
    {
        datosPlayer= follow.GetComponent<ctrPlayerMov>();
    }

    // Update is called once per frame
    void Update()
    {
        posAct= transform.position;
        posDest= pos[0].position;
        if(Input.GetKeyDown(KeyCode.P)) Camb();
    }
    private void FixedUpdate() {
        transform.rotation= follow.transform.localRotation;
        transform.position= Vector3.Lerp(posAct, posDest, smooth);    
    }
    private void Camb(){
        m++;
        if(m> pos.Length) m=0;
    }
}
