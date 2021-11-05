using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrPlayerMov : MonoBehaviour
{
    [Header("Propiedades del personaje")]
    private CharacterController controller;
    public enum Estados {Normal, Freddy, Jason};
    public Estados estado;
    public float gravedad;
    public float vel;
    public float salto; //fuerza de salto
    [Header("Variables de prueba")]
    public float vm; //WS
    public float hm; //AD
    public Vector3 movPlayer;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        //estado=Estados.Normal;
        controller= GetComponent<CharacterController>();
        sr= transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //vm= Input.GetAxis("Vertical");
        hm= Input.GetAxis("Horizontal");
        Mov();
    }
    private void Mov(){ //Movimiento
        movPlayer.x= hm * vel;
        movPlayer.y-=gravedad * Time.deltaTime;
        movPlayer.z=0;
        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) movPlayer.y=salto; //Salto
        Flip(movPlayer.x);
        controller.Move(movPlayer * Time.deltaTime);
    }

    private void Flip(float x){ //Voltear sprite
        if(x>0) sr.flipX=false;
        if(x<0) sr.flipX= true;
    }
}
