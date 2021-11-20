using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrPlayerValues : MonoBehaviour
{
    private ctrPlayerMov ctrPlayer;
    [Header("Valores Propios de la Skin")]
    [Space(2)]
    [Header("Forma normal")][Tooltip("Elemento 0: Velocidad.\nElemento 1: Impulso del salto")] 
    public float[] NormalValues;
    [Header("Forma de Jason")][Tooltip("Elemento 0: Velocidad.\nElemento 1: Impulso del salto")]
    public float[] JasonValues;
    [Header("Forma de Exterminador")][Tooltip("Elemento 0: Velocidad.\nElemento 1: Impulso del salto")]
    public float[] TerminatorValues;
    [Header("Forma de Freddy")][Tooltip("Elemento 0: Velocidad.\nElemento 1: Impulso del salto")]
    public float[] FreddyValues;
    [Header("Tiempo de transformación")] public float tiempo;

    private SpriteRenderer sp; 
    private string nombBuff;
    // Start is called before the first frame update
    void Start()
    {
        ctrPlayer= GetComponent<ctrPlayerMov>();
        ChangeSkin();
    }

    // Update is called once per frame
    //void Update(){}
    // 0.Normal 1.Jason 2.Terminator 3.Freddy
    public void ChangeSkin(){
        switch(ctrPlayer.estado){
            case ctrPlayerMov.Estados.Normal: //Forma normal
                ctrPlayer.estado= ctrPlayerMov.Estados.Normal;
                ctrPlayer.setVel(NormalValues[0]);
                ctrPlayer.setSalto(NormalValues[1]);
            break;
            case ctrPlayerMov.Estados.Jason: //Forma de Jason
                ctrPlayer.estado= ctrPlayerMov.Estados.Jason;
                ctrPlayer.setVel(JasonValues[0]);
                ctrPlayer.setSalto(JasonValues[1]);
            break;
            case ctrPlayerMov.Estados.Terminator: //Forma de Terminator
                ctrPlayer.estado= ctrPlayerMov.Estados.Terminator;
                ctrPlayer.setVel(TerminatorValues[0]);
                ctrPlayer.setSalto(TerminatorValues[1]);
            break;
            case ctrPlayerMov.Estados.Freddy: //Forma de Freddy
                ctrPlayer.estado= ctrPlayerMov.Estados.Freddy;
                ctrPlayer.setVel(FreddyValues[0]);
                ctrPlayer.setSalto(FreddyValues[1]);
            break;
            default:
                //ctrPlayer.estado= ctrPlayerMov.Estados.Normal;
                //ChangeSkin();
                print("<-<");
            break;
        }
    }
    //Colliders
    private void OnTriggerEnter(Collider obj){
        if(obj.tag=="Buff"){
            sp= obj.GetComponent<SpriteRenderer>();
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
            ChangeSkin();
        }
    }
}
