using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChara : MonoBehaviour
{
    [SerializeField]
    public GameObject[] chara1P, chara2P;
    // private から pubricに変更 初めの値を 1 から 0 に変更 by菅原　7/1
    public int[] count;
    // Update is called once per frame

    [SerializeField]
    GameObject sceneManager;

    private void Awake()
    {
        sceneManager = GameObject.Find("SceneManager");

        count[0] = sceneManager.GetComponent<PlayerManagerScript>()
            .playerCharaNum[(int)ConstRepo.Player.P1];

        count[1] = sceneManager.GetComponent<PlayerManagerScript>()
            .playerCharaNum[(int)ConstRepo.Player.P2];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (count[0] == 3)
            {
                count[0] = 0;
                return;
            }
            count[0]++;
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            if(count[0] == 0)
            {
                count[0] = 3;
                return;
            }
            count[0]--;
        }
        switch (count[0])
        {
            // caseの始まりの値を 0からに変更 by菅原　7/1
            case 0:
                chara1P[0].SetActive(true);
                chara1P[1].SetActive(false);
                chara1P[2].SetActive(false);
                chara1P[3].SetActive(false);
                break;

            case 1:
                chara1P[0].SetActive(false);
                chara1P[1].SetActive(true);
                chara1P[2].SetActive(false);
                chara1P[3].SetActive(false);
                break;
            case 2:
                chara1P[0].SetActive(false);
                chara1P[1].SetActive(false);
                chara1P[2].SetActive(true);
                chara1P[3].SetActive(false);
                break;
            case 3:
                chara1P[0].SetActive(false);
                chara1P[1].SetActive(false);
                chara1P[2].SetActive(false);
                chara1P[3].SetActive(true);
                break;
            default:
                break;
        }



        if(Input.GetKeyDown(KeyCode.C))
        {
            if(count[1] == 3)
            {
                count[1] = 0;
                return;
            }
            count[1]++;
        }
        else if(Input.GetKeyDown(KeyCode.V))
        {
            if(count[1] == 0)
            {
                count[1] = 3;
                return;
            }
            count[1]--;
        }
        switch (count[1])
        {
            case 0:
                chara2P[0].SetActive(true);
                chara2P[1].SetActive(false);
                chara2P[2].SetActive(false);
                chara2P[3].SetActive(false);
                break;

            case 1:
                chara2P[0].SetActive(false);
                chara2P[1].SetActive(true);
                chara2P[2].SetActive(false);
                chara2P[3].SetActive(false);
                break;
            case 2:
                chara2P[0].SetActive(false);
                chara2P[1].SetActive(false);
                chara2P[2].SetActive(true);
                chara2P[3].SetActive(false);
                break;
            case 3:
                chara2P[0].SetActive(false);
                chara2P[1].SetActive(false);
                chara2P[2].SetActive(false);
                chara2P[3].SetActive(true);
                break;
            default:
                break;
        }

    }
}
