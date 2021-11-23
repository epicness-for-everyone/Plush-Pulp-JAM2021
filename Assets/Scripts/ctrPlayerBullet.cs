using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrPlayerBullet : MonoBehaviour
{
    public float vel;
    private bool orientation;
    private bool direction;
    private Vector3 go= Vector3.zero;
    private Vector3 giro= Vector3.zero;
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if(orientation){
            go.x= 0f; 
            go.z= vel;
            giro.x= 170f;
        }
        else{ 
            go.x= vel;
            go.z= 0f; 
            giro.z= 170f;   
        }
        if(direction){ 
            transform.position= transform.position - go * Time.deltaTime;
            transform.Rotate( giro * Time.deltaTime);
        }else{
            transform.position= transform.position + go * Time.deltaTime;
            transform.Rotate( -giro * Time.deltaTime);
        }
    }
    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
    //Geters and Setters
    public void setOrientation(bool n){ //EjeZ
        orientation= n;
    }
    public void setDirection(bool n){ //flip del sprite
        direction= n;
    }
}
