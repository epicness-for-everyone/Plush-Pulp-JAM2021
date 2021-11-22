using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ctrNextScene : MonoBehaviour
{
    public int LastSecene;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            SceneManager.LoadScene(LastSecene);
        }
    }
}
