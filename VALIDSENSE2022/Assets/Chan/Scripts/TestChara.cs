using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChara : MonoBehaviour
{
    [SerializeField]
    public GameObject[] chara1P, chara2P;
    // private から pubricに変更 初めの値を 1 から 0 に変更 by菅原　7/1
    public int count1P = 0, count2P = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(count1P == 3)
            {
                count1P = 0;
                return;
            }
            count1P++;
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            if(count1P == 0)
            {
                count1P = 3;
                return;
            }
            count1P--;
        }
        switch (count1P)
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
            if(count2P == 3)
            {
                count2P = 0;
                return;
            }
            count2P++;
        }
        else if(Input.GetKeyDown(KeyCode.V))
        {
            if(count2P == 0)
            {
                count2P = 3;
                return;
            }
            count2P--;
        }
        switch (count2P)
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
