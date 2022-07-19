using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPlayerInput : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManager;


    [SerializeField]
    private float autoToTitleTime;

    bool canToTitle;

    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");

        StartCoroutine(AutoToTitleScene());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && canToTitle)
        {
            sceneManager.GetComponent<Test>().ToTitleScene();
            ResultBGMPlayer.instance.StopPlayer();
        }
    }

    IEnumerator AutoToTitleScene()
    {
        yield return new WaitForSeconds(autoToTitleTime / 8);

        canToTitle = true;

        yield return new WaitForSeconds(autoToTitleTime);

        sceneManager.GetComponent<Test>().ToTitleScene();
    }
}
