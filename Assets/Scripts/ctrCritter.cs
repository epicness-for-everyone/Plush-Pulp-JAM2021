using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrCritter : MonoBehaviour
{
    [Header("Variables del Enemigo")]
    private CharacterController cc;
    public enum Estados {Pasivo, Pensando, Agresivo, Muerto};
    public Estados estado;
    [Range(0,10)]public float areaVision;
    [Range(0,10)][Tooltip("No debe ser menor al área de visión")]public float areaPersecucion;
    public float vel;
    [Tooltip("Fuerza del salto")]public float impulso;
    public float gravedad;
    [Header("Variables de Test")]
    //Hijo 1
    private Animator ani;
    private SpriteRenderer sr;
    //Hijo 2
    public GameObject vision;
    private float posx;
    //Variables ed uso (?)
    private int act=1;
    private float time=10;
    private float dir= -1;
    private Vector3 moveObj;
    public GameObject target;
    private bool choque= false;
    private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        cc= GetComponent<CharacterController>();
        ani= transform.GetChild(0).GetComponent<Animator>();
        sr= transform.GetChild(0).GetComponent<SpriteRenderer>();
        posx=vision.transform.position.x;
        if(areaVision > areaPersecucion) areaPersecucion=areaVision;   
    }

    // Update is called once per frame
    void Update()
    {
        if(estado == Estados.Pasivo) Actividad();
        if(estado == Estados.Agresivo) onAttack();
        if(estado == Estados.Pensando) inThink();
        if(Vector3.Distance(vision.transform.position, target.transform.position) <= areaVision){ 
            ani.SetBool("attack", true);
            estado= Estados.Agresivo;
            waitTime=0;
        }
        if(Vector3.Distance(vision.transform.position, target.transform.position) >= areaPersecucion 
            && estado== Estados.Agresivo)  estado=Estados.Pensando;            
    }
    private void Actividad(){
        time+= 1 * Time.deltaTime;
        if(time >=5f){
            act=Random.Range(1,3);
            time=0;
            if(act==1) time=2;
        }
        switch(act){
            case 1:
                ani.SetBool("walk", false);
                cc.Move(Vector3.zero);
                break;
            case 2:
                ani.SetBool("walk", true);
                moveObj.x= dir * vel;
                moveObj.y-= gravedad * Time.deltaTime;
                cc.Move(moveObj * Time.deltaTime);
                break;
            default:
                print("xD no deberías de ver esto");
                break;
        }
    }
    private void inThink(){
        waitTime+= 1 * Time.deltaTime;
        moveObj.x=dir;
        moveObj.y-= gravedad * Time.deltaTime;
        if(cc.isGrounded) moveObj= Vector3.zero;
        cc.Move(moveObj * Time.deltaTime);
        if(waitTime >= 4f && cc.isGrounded){
            ani.SetBool("attack", false);
            ani.SetBool("walk", false);
            estado= Estados.Pasivo;
            waitTime= 0;
        }
    }
    private void onAttack(){
        moveObj.x= dir * vel;
        moveObj.y-= gravedad * Time.deltaTime;
        if(cc.isGrounded){
            moveObj.y=0;
            dir= obternerDir();
            Flip(dir);
        }
        if(choque){
            moveObj.y= impulso * 2f;
            choque = false;
        }
        cc.Move(moveObj * Time.deltaTime);
    }
    private void onDeath(){
        cc.Move(Vector3.zero);
        ani.SetBool("live", true);
    }
    private void Flip(float x){
        if(x>0) transform.localRotation= new Quaternion(0f,180f,0f,0f);
        if(x<0) transform.localRotation= new Quaternion(0f,0f,0f,0f);
    }
    private float obternerDir(){
        float n;
        if((target.transform.position.x - transform.position.x)> 0 ) n= 1f;
        else n= -1f;
        return n;
    }
    private void OnTriggerEnter(Collider obj) {
        if(obj.tag == "ctrMuro" && estado== Estados.Pasivo){
            dir=dir*-1;
            Flip(dir);
        }
        if(obj.tag == "ctrMuro" && estado == Estados.Agresivo){
            dir= dir*-1;
            choque= true;
            Flip(dir);
        }
        //if(obj.tag == "Player") print("D:! enemigo visto");    
    }
    private void OnDrawGizmos() {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(vision.transform.position, areaVision);
        Gizmos.DrawWireSphere(vision.transform.position, areaPersecucion);    
    }
}
