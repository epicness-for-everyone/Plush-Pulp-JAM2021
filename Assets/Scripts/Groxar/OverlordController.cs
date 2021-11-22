using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlordController : MonoBehaviour {

    public GameObject boss, player;

    void Start() {
        player = Instantiate(player);
        boss = Instantiate(boss);
        boss.GetComponent<PhysicsBossController>().SetPlayer(player);
    }

    void Update() {
        
    }
}