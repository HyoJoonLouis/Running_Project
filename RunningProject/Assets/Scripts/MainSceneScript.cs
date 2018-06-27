using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneScript : MonoBehaviour {

    public void loadGameScene(){
        SceneManager.LoadScene(1);
    }

    public void exitApplication(){
        Debug.Log("gameExit");
        Application.Quit();
    }

}
