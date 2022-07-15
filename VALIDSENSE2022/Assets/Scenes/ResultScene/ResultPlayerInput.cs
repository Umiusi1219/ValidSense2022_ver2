using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPlayerInput : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManager;


    [SerializeField]
    private float autoToTitleTime;


    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");

        StartCoroutine(AutoToTitleScene());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            sceneManager.GetComponent<Test>().ToTitleScene();
        }
    }

    IEnumerator AutoToTitleScene()
    {
        yield return new WaitForSeconds(autoToTitleTime);

        sceneManager.GetComponent<Test>().ToTitleScene();
    }
}
