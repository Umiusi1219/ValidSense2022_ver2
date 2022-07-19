using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPlayerInput : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManager;

    [SerializeField]
    int usePlayer;



    /// <summary>
    /// Ž©“®‚Å‘JˆÚ‚·‚é‚Ü‚Å‚ÌŽžŠÔ
    /// </summary>
    [SerializeField]
    private float autoToTitleTime;

    /// <summary>
    /// ‘JˆÚ•s‰Â‚ÌŽžŠÔ
    /// </summary>
    [SerializeField]
    private float notToTitleTime;

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
            ToNextScene();
        }
    }

    IEnumerator AutoToTitleScene()
    {
        yield return new WaitForSeconds(notToTitleTime);

        canToTitle = true;

        yield return new WaitForSeconds(autoToTitleTime - notToTitleTime );

        ToNextScene();
    }

    void ToNextScene()
    {
        if(sceneManager.GetComponent<PlayerManagerScript>().resultCount == 0)
        {

            sceneManager.GetComponent<PlayerManagerScript>().resultCount++;

            if (usePlayer == 0)
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

            sceneManager.GetComponent<Test>().ToTitleScene();
        }

    }
}
