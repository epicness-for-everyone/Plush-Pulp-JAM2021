using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrSuelo : MonoBehaviour
{
    private Collider col;
    private ctrPlayerMov ctrPlayer;
    // Start is called before the first frame update
    void Start()
    {
        col= GetComponent<Collider>();
        ctrPlayer= GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<ctrPlayerMov>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ctrPlayer.getMovPlayerY() > 0f) col.isTrigger= true;
        else col.isTrigger= false;   
    }
}
