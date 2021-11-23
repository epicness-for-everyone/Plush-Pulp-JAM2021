using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrPlayerAttack : MonoBehaviour
{
    private ctrPlayerMov ctrPlayer;
    public GameObject hit;
    public GameObject Bullet;
    private GameObject bullet;
    private ctrPlayerBullet ctrBullet;
    private SpriteRenderer sp;
    private Collider ataque;
    // Start is called before the first frame update
    void Start()
    {
        ctrPlayer= transform.parent.GetComponent<ctrPlayerMov>();
        sp= GetComponent<SpriteRenderer>();
        ataque= hit.GetComponent<Collider>();
        ataque.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(sp.flipX) hit.transform.localPosition= new Vector3(-2f,0f,0f);
        else hit.transform.localPosition= new Vector3(2f, 0f, 0f);
    }
    public void OnAttack(){
        ataque.enabled= true;
    }
    public void OffAttack(){
        ataque.enabled= false;
    }
    public void Shoot(){
        bullet= Instantiate(Bullet, 
                new Vector3(hit.transform.position.x, hit.transform.position.y+2.3f, hit.transform.position.z), 
                transform.rotation);
        ctrBullet= bullet.GetComponent<ctrPlayerBullet>();
        ctrBullet.setOrientation(ctrPlayer.getEjeZ());
        if(ctrPlayer.getFlipDir()) ctrBullet.setDirection(!sp.flipX);
        else ctrBullet.setDirection(sp.flipX);
    }
}
