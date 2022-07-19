using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_PlayerInput : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManagerTest;


    [SerializeField]
    private float _toNextScene;

    bool _canGetKey = true;


    private void Start()
    {
        sceneManagerTest = GameObject.Find("SceneManager");


        //MainBGMPlayer.instance.MusicPlay(0);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !Input.GetMouseButtonDown(0) && _canGetKey)
        {
            _canGetKey = false;

            SEPlayer.instance.SEOneShot(6);
            MainBGMPlayer.instance.StopPlayer();
            Invoke("ToNextScene", _toNextScene);
        }
    }


    void ToNextScene()
    {
        

        sceneManagerTest.GetComponent<Test>().ToCharaSelectScene();
    }
}
