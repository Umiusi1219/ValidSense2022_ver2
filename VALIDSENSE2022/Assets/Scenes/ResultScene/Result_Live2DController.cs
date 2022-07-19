using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_Live2DController : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManager;

    [SerializeField]
    List<GameObject> live2D;

    [SerializeField]
    int usePlayer;


    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");


        ShowLive2D(sceneManager.GetComponent<PlayerManagerScript>().playerCharaNum[usePlayer]);



    }



    void ShowLive2D(int charaNum)
    {
        for (int i = 0; i < live2D.Count;) 
        {
            if(i == charaNum)
            {
                live2D[i].SetActive(true);


            }
            else
            {
                live2D[i].SetActive(false);
            }
            
            i++;
        }

        StartCoroutine(WinPlayerAnim());
    }

    IEnumerator WinPlayerAnim()
    {
        yield return new WaitForSeconds(1);

        if (sceneManager.GetComponent<PlayerManagerScript>().resultCount == 0)
        {

            live2D[sceneManager.GetComponent<PlayerManagerScript>().playerCharaNum[usePlayer]]
                .GetComponent<Live2D_AnimController>().Anim_Win();

        }
    }
}
