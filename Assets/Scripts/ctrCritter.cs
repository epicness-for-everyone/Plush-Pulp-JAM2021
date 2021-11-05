using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrCritter : MonoBehaviour
{
    [Header("Propiedades")]
    private CharacterController cc;
    public enum Estados {Pasivo, Agresivo};
    public Estados estado;
    public Transform target;
    public float vel;
    public float gravedad;
    public float salto;
    [Range(0,10)]public float vision;
    private SpriteRenderer sr;
    private Animator ani;
    [Header("Variables de prueba")]
    public Vector3 dir;
    private Vector3 moveObj;
    private bool choque;
    private float time=10f;
    private int comp=1;
    // Start is called before the first frame update
    void Start()
    {
        cc= GetComponent<CharacterController>();
        sr= transform.GetChild(0).GetComponent<SpriteRenderer>();
        ani= transform.GetChild(0).GetComponent<Animator>();
        estado= Estados.Pasivo;
        comp=1;
        Go();
        target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(estado == Estados.Pasivo) Move();
        if(estado == Estados.Agresivo){ 
            Atack();
            if(Vector3.Distance(transform.position, target.position) > vision) StartCoroutine("offAtack");
        }
        if(Vector3.Distance(transform.position, target.position) <= vision) estado= Estados.Agresivo;
    }
    public void Move(){
        time+= 1 * Time.deltaTime;
        if(time >= 5f){
            time=0;
            comp=Random.Range(1,3);
            if(comp==1) time=2;
        }
        switch(comp){
            case 1: //idle
                ani.SetBool("walk", false);
                moveObj.x= 0f;
                moveObj.y-= gravedad * Time.deltaTime; 
                cc.Move(moveObj * Time.deltaTime);
                break;
            case 2: // walk
                Flip(dir.x);
                moveObj.x= dir.x * vel;
                moveObj.y-= gravedad * Time.deltaTime;
                ani.SetBool("walk", true);
                cc.Move( moveObj * Time.deltaTime);
                break;
            default:
                print("xD");
                break;
        }
    }
    public void Atack(){
        ani.SetBool("atack", true);
        Flip(dir.x);
        moveObj.x= dir.x * (vel * 3f);
        moveObj.y-= gravedad * Time.deltaTime;
        if(choque){
            moveObj.y= salto * 2f;
            choque= false;
        }
        cc.Move(moveObj * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider obj){
        if(obj.tag=="ctrMuro" && estado == Estados.Pasivo){
            dir.x= dir.x*-1; 
        }
        if(obj.tag=="ctrMuro" && estado == Estados.Agresivo){
            dir.x= dir.x*-1;
            choque= true;
        }
    }
    IEnumerator offAtack(){
        yield return new WaitForSeconds(3f);
        estado= Estados.Pasivo;
        ani.SetBool("atack", false);
    }
    private void OnDrawGizmos() {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position, vision);    
    }
    private void Flip(float x){
        if(x>0) sr.flipX= true;
        if(x<0) sr.flipX=false;
    }
    private void Go(){
        int m=Random.Range(-1,2);
        if(m==0) Go();
        else dir.x=m;
    }
}
