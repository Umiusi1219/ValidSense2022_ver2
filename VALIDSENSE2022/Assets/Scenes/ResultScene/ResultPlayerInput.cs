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

    [SerializeField]
    int usePlayer;

    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");

        StartCoroutine(AutoToTitleScene());
    }

    // Update is called once per frame
    void Update()
    {
        if(canToTitle)
        {
            if (usePlayer == 0)
            {
                if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R) ||
                    Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    canToTitle = false;

                    SEPlayer.instance.SEOneShot(6);

                    Invoke("ToNextScene", 1f);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.U) ||
                    Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.J))
                {
                    canToTitle = false;

                    SEPlayer.instance.SEOneShot(6);

                    Invoke("ToNextScene", 1f);
                }
            }

        }
    }



    IEnumerator AutoToTitleScene()
    {
        yield return new WaitForSeconds(autoToTitleTime / 10);

        canToTitle = true;

        yield return new WaitForSeconds(autoToTitleTime);

        ToNextScene();
    }

    void ToNextScene()
    {
        ResultBGMPlayer.instance.StopPlayer();

        if (sceneManager.GetComponent<PlayerManagerScript>().resultCount == 0)
        {
            sceneManager.GetComponent<PlayerManagerScript>().resultCount++;

            if(usePlayer == 0)
            {
                sceneManager.GetComponent<Test>().ToResult_2P_Scene();
            }
            else
            {
                sceneManager.GetComponent<Test>().ToResult_1P_Scene();
            }
        }
        else
        {
            sceneManager.GetComponent<PlayerManagerScript>().resultCount = 0;

            sceneManager.GetComponent<Test>().ToLicenseScene() ;
        }
    }
}
