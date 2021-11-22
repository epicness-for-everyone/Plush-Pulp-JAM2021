using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrPlayerValues : MonoBehaviour
{
    private ctrPlayerMov ctrPlayer;
    [Header("Valores Propios de la Skin")]
    [Space(2)]
    [Header("Forma normal")][Tooltip("Elemento 0: Velocidad.\nElemento 1: Impulso del salto.\nElemento 2: Vida.")] 
    public float[] NormalValues;
    [Header("Forma de Jason")][Tooltip("Elemento 0: Velocidad.\nElemento 1: Impulso del salto.\nElemento 2: Vida.")]
    public float[] JasonValues;
    [Header("Forma de Exterminador")][Tooltip("Elemento 0: Velocidad.\nElemento 1: Impulso del salto.\nElemento 2: Vida.")]
    public float[] TerminatorValues;
    [Header("Forma de Freddy")][Tooltip("Elemento 0: Velocidad.\nElemento 1: Impulso del salto.\nElemento 2: Vida.")]
    public float[] FreddyValues;
    [Header("Tiempo de transformación")] public float tiempo;
    public Text change;
    private float time;

    private SpriteRenderer sp; 
    private string nombBuff;
    // Start is called before the first frame update
    void Start()
    {
        ctrPlayer= GetComponent<ctrPlayerMov>();
        ChangeSkin();
        time=0f;
    }

    // Update is called once per frame
    void Update(){
        if(ctrPlayer.estado!= ctrPlayerMov.Estados.Normal){
            time+= 1*Time.deltaTime;
            change.text=(tiempo-time).ToString("f0");
            if(time>= tiempo){
                ctrPlayer.estado= ctrPlayerMov.Estados.Normal;
            }
        }
        if(ctrPlayer.estado == ctrPlayerMov.Estados.Normal) time=0f;
    }
    // 0.Normal 1.Jason 2.Terminator 3.Freddy
    public void ChangeSkin(){
        switch(ctrPlayer.estado){
            case ctrPlayerMov.Estados.Normal: //Forma normal
                ctrPlayer.estado= ctrPlayerMov.Estados.Normal;
                ctrPlayer.setVel(NormalValues[0]);
                ctrPlayer.setSalto(NormalValues[1]);
                ctrPlayer.setVida(NormalValues[2]);
            break;
            case ctrPlayerMov.Estados.Jason: //Forma de Jason
                ctrPlayer.estado= ctrPlayerMov.Estados.Jason;
                ctrPlayer.setVel(JasonValues[0]);
                ctrPlayer.setSalto(JasonValues[1]);
                ctrPlayer.setVida(JasonValues[2]);
            break;
            case ctrPlayerMov.Estados.Terminator: //Forma de Terminator
                ctrPlayer.estado= ctrPlayerMov.Estados.Terminator;
                ctrPlayer.setVel(TerminatorValues[0]);
                ctrPlayer.setSalto(TerminatorValues[1]);
                ctrPlayer.setVida(TerminatorValues[2]);
            break;
            case ctrPlayerMov.Estados.Freddy: //Forma de Freddy
                ctrPlayer.estado= ctrPlayerMov.Estados.Freddy;
                ctrPlayer.setVel(FreddyValues[0]);
                ctrPlayer.setSalto(FreddyValues[1]);
                ctrPlayer.setVida(FreddyValues[2]);
            break;
            default:
                ctrPlayer.estado= ctrPlayerMov.Estados.Normal;
                ChangeSkin();
                print("<-<");
            break;
        }
    }
    //Colliders
    private void OnTriggerEnter(Collider obj){
        if(obj.tag=="Buff"){
            sp= obj.GetComponent<SpriteRenderer>();
            if(ctrPlayer.estado == ctrPlayerMov.Estados.Normal){
                nombBuff= sp.sprite.name;
                switch(nombBuff){
                    case "buffs_0": //Jason
                        ctrPlayer.estado= ctrPlayerMov.Estados.Jason;
                    break;
                    case "buffs_1": //Terminator
                        ctrPlayer.estado= ctrPlayerMov.Estados.Terminator;
                    break;
                    case "buffs_2": //Freddy
                        ctrPlayer.estado= ctrPlayerMov.Estados.Freddy;
                    break;
                    default:
                        print("xD"+sp.sprite);
                    break;
                }
            }
            ChangeSkin();
        }
    }
}
