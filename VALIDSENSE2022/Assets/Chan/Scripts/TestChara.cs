using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChara : MonoBehaviour
{
    [SerializeField]
    public GameObject[] chara1P, chara2P;
    private int count1P = 1, count2P = 1;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(count1P == 3)
            {
                count1P = 1;
                return;
            }
            count1P++;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            if(count1P == 1)
            {
                count1P = 3;
                return;
            }
            count1P--;
        }
        switch (count1P)
        {
            case 1:
                chara1P[0].SetActive(true);
                chara1P[1].SetActive(false);
                chara1P[2].SetActive(false);
                break;

            case 2:
                chara1P[0].SetActive(false);
                chara1P[1].SetActive(true);
                chara1P[2].SetActive(false);
                break;
            case 3:
                chara1P[0].SetActive(false);
                chara1P[1].SetActive(false);
                chara1P[2].SetActive(true);
                break;
            default:
                break;
        }



        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(count2P == 3)
            {
                count2P = 1;
                return;
            }
            count2P++;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(count2P == 1)
            {
                count2P = 3;
                return;
            }
            count2P--;
        }
        switch (count2P)
        {
            case 1:
                chara2P[0].SetActive(true);
                chara2P[1].SetActive(false);
                chara2P[2].SetActive(false);
                break;

            case 2:
                chara2P[0].SetActive(false);
                chara2P[1].SetActive(true);
                chara2P[2].SetActive(false);
                break;
            case 3:
                chara2P[0].SetActive(false);
                chara2P[1].SetActive(false);
                chara2P[2].SetActive(true);
                break;
            default:
                break;
        }

    }
}
