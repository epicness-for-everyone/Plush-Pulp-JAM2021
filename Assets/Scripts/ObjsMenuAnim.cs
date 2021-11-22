using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjsMenuAnim : MonoBehaviour
{
    //inicio:-110 /-\ fin:680
    [Range(50f,200f)]public float vel;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector3(transform.position.x+vel*Time.deltaTime, 
                                        transform.position.y, transform.position.z);
        if(transform.position.x>=2030) transform.position= new Vector3(-110f,transform.position.y,transform.position.z);   
    }
    public void PlayGame(){
        vel=0f;
        anim.SetBool("oir", true);
    }
}
