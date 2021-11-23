using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrPlayerMov : MonoBehaviour
{
    [Header("Propiedades del personaje")]
    private CharacterController cc;
    public enum Estados {Normal, Jason, Terminator, Freddy};
    public Estados estado;
    public float gravedad;
    public bool vivo;
    public float vida;
    private float vel;
    private float salto; //fuerza de salto
    [Header("Variables de prueba")]
    public bool ejeZ; //mov por el eje z
    public bool flipDir; //invertir controles
    public float dir;
    private float vm; //WS
    private float hm; //AD
    public Vector3 movPlayer;
    private SpriteRenderer sr;
    private Animator ani;
    
    private bool cambio;
    private Transform lugarCambio;
    private ctrChange ctrChange;
    /// efectos
    private GameObject efecto;
    private bool firstTime;
    // Start is called before the first frame update
    void Start()
    {
        //estado=Estados.Normal;
        cc= GetComponent<CharacterController>();
        sr= transform.GetChild(0).GetComponent<SpriteRenderer>();
        ani= transform.GetChild(0).GetComponent<Animator>();

        /// Reset animación
        ani.SetBool("walk", false);
        ani.SetBool("jump", false);
        ani.SetBool("death", false);
        ani.SetFloat("character", 0f);
        vivo=true;
        firstTime=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(vivo){
            ani.SetBool("death", false);
            Skin();
            if(cambio) Girar();
            else{ 
                //vm= Input.GetAxis("Vertical");
                hm= Input.GetAxis("Horizontal");
                Mov();
                if(Input.GetKeyDown(KeyCode.R)) Attack();
            }
        }else Death();
    }
    private void Mov(){ //Movimiento
        Direction();
        if(Input.GetKeyDown(KeyCode.W) && cc.isGrounded){ 
            movPlayer.y=salto; //Salto
            ani.SetBool("jump", true);
        }
        cc.Move(movPlayer * Time.deltaTime);
    }
    private void Direction(){
        dir= hm * vel;
        Flip(dir);
        if(flipDir) dir= dir *-1;
        if(dir!= 0) ani.SetBool("walk", true);
        else ani.SetBool("walk", false);
        movPlayer.y-= gravedad * Time.deltaTime;
        if(ejeZ){
            //transform.localRotation= new Quaternion(0f,-90f,0f,90f);
            movPlayer.z= dir;
            movPlayer.x= 0;
        }else{
            //transform.localRotation= new Quaternion(0f,0f,0f,90f);
            movPlayer.x= dir;
            movPlayer.z= 0;
        }
        if(cc.isGrounded){ 
            movPlayer.y=0;
            ani.SetBool("jump", false);
        }
    }
    private void Flip(float x){ //Voltear sprite
        if(x>0){ 
            sr.flipX=false;
        }
        if(x<0){ 
            sr.flipX= true;
        }
    }
    private void Girar(){
        if(!ejeZ && !flipDir) //frente 
            transform.rotation= Quaternion.LookRotation(Vector3.RotateTowards(
                transform.forward, Vector3.forward, 3f * Time.deltaTime, 0.0f));
        if(ejeZ && flipDir) //izquierda
            transform.rotation= Quaternion.LookRotation(Vector3.RotateTowards(
                transform.forward, Vector3.right, 3f * Time.deltaTime, 0.0f));
        if(!ejeZ && flipDir) //atras
            transform.rotation= Quaternion.LookRotation(Vector3.RotateTowards(
                transform.forward, Vector3.back, 3f * Time.deltaTime, 0.0f));
        if(ejeZ && !flipDir) //derecha
            transform.rotation= Quaternion.LookRotation(Vector3.RotateTowards(
                transform.forward, Vector3.left, 3f * Time.deltaTime, 0.0f));
        
        movPlayer.x= lugarCambio.position.x - transform.position.x;
        movPlayer.y= 0;
        movPlayer.z= lugarCambio.position.z - transform.position.z;
        cc.Move(movPlayer.normalized * (vel*0.1f) * Time.deltaTime);
        //transform.position= Vector3.MoveTowards(transform.position, lugarCambio.position, (vel/5) * Time.deltaTime);
        if(Vector3.Distance(
            new Vector3(transform.position.x, 0f, transform.position.z),
            new Vector3(lugarCambio.position.x, 0f, lugarCambio.position.z)) <= 0.5f){ 
                cambio=false;
                lugarCambio= null;
        }        
    }
    private void Skin(){
        if(estado== Estados.Normal)     ani.SetFloat("character", 0f);
        if(estado== Estados.Jason)      ani.SetFloat("character", 0.3f);
        if(estado== Estados.Terminator) ani.SetFloat("character", 0.6f);
        if(estado== Estados.Freddy)     ani.SetFloat("character", 1f);
    }
    public void Attack(){
        if(estado!= Estados.Normal){
            ani.SetTrigger("attack");
        }
    }
    public void Death(){
        ani.SetBool("death", true);
        if(firstTime){
            movPlayer.y= salto*2;
            firstTime= false;
        }else movPlayer.y-= gravedad;
        if(movPlayer.y <= -200f) cc.Move(Vector3.zero);
        else if(dir!= 0){
                cc.Move(new Vector3(-movPlayer.x, movPlayer.y, -movPlayer.z) * Time.deltaTime);
            }else cc.Move(movPlayer * 1.5f * Time.deltaTime);
    }
    public void OnDeath(){
        vivo= false;
    }
    //Colliders
    private void OnTriggerEnter(Collider obj){
        if(obj.tag=="Change" && !cambio){
            cambio= true;
            ctrChange= obj.GetComponent<ctrChange>();
            lugarCambio= ctrChange.getDestino();
            setEjeZ(ctrChange.getEjeZ());
            setFlipDir(ctrChange.getInv());
        }
    }
    //geters and seters
    public float getDir(){
        return dir;
    }
    public void setEjeZ(bool n){
        ejeZ= n;
    }
    public bool getEjeZ(){
        return ejeZ;
    }
    public void setFlipDir(bool n){
        flipDir= n;
    }
    public bool getFlipDir(){
        return flipDir;
    }
    public void setVel(float n){
        vel= n;
    }
    public void setSalto(float n){
        salto= n;
    }
    public void setVida(float n){
        vida= n;
    }
    public float getMovPlayerY(){
        return movPlayer.y;
    }
}
