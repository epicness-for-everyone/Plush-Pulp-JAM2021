using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaManager : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start(){}

    // Update is called once per frame
    // void Update(){}
    public void Manager (string data){
        SceneManager.LoadScene(data);
    }

    public void Exit (){
        Application.Quit();
    }
}
