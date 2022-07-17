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
        //if(Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    sceneManager.SendMessage("SetScene", GameScene.Title);
        //}
        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    sceneManager.SendMessage("SetScene", GameScene.MusicSelect);
        //}
        //if(Input.GetKeyDown(KeyCode.Return))
        //{
        //    sceneManager.SendMessage("SetScene", GameScene.Playing);
        //}
        //if(Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    sceneManager.SendMessage("SetScene", GameScene.Result);
        //}
    }
    public void ToCharaSelectScene()
    {
        sceneManager.SendMessage("SetScene", GameScene.CharaSelect);
    }


    public void ToMusicSelectScene()
    {
        sceneManager.SendMessage("SetScene", GameScene.MusicSelect);
    }

    public void ToMainScene()
    {
        sceneManager.SendMessage("SetScene", GameScene.Playing);
    }

    public void ToResult_1P_Scene()
    {
        sceneManager.SendMessage("SetScene", GameScene.Result_1P);
    }

    public void ToResult_2P_Scene()
    {
        sceneManager.SendMessage("SetScene", GameScene.Result_2P);
    }

    public void ToTitleScene()
    {
        sceneManager.SendMessage("SetScene", GameScene.Title);
    }
}


