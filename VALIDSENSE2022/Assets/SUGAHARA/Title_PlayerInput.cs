using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_PlayerInput : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManagerTest;


    private void Start()
    {
        sceneManagerTest = GameObject.Find("SceneManager");
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            sceneManagerTest.GetComponent<Test>().ToMusicSelectScene();
        }
    }
}
