using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private GameObject sceneManager;
    private void Start() 
    {       
        sceneManager = GameObject.Find("SceneManager");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            sceneManager.SendMessage("SetScene", GameScene.Title);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            sceneManager.SendMessage("SetScene", GameScene.MusicSelect);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            sceneManager.SendMessage("SetScene", GameScene.Playing);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            sceneManager.SendMessage("SetScene", GameScene.Result);
        }
    }
}
