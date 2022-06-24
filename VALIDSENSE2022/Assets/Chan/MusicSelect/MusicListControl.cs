using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicListControl : MonoBehaviour
{
    private Vector3[] musicListPosDatas;
    private Quaternion[] musicListRotationDatas;

    private GameObject[] musicList;

    private int musicListNum;
    private int nowMusicNum = 1;
    public JsonReader jsonReader;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.childCount);
        musicListNum = transform.childCount;
        musicListPosDatas = new Vector3[musicListNum];
        musicListRotationDatas = new Quaternion[musicListNum];
        musicList = new GameObject[musicListNum];

        for(int i = 0; i < musicListNum; i++)
        {
            musicList[i] = transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < musicListNum; i++)
        {
            musicListPosDatas[i] = musicList[i].transform.position;
            musicListRotationDatas[i] = musicList[i].transform.rotation;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            for(int i = 0; i < musicListNum ; i++)
            {
                if(i == (musicListNum - 1))
                {
                    musicList[i].transform.position = musicListPosDatas[0];
                    musicList[i].transform.rotation = musicListRotationDatas[0];
                    
                }else
                {
                    musicList[i].transform.position = musicListPosDatas[i + 1];
                    musicList[i].transform.rotation = musicListRotationDatas[i + 1];
                }
            }
            if(nowMusicNum < musicListNum)
            {
                nowMusicNum++;
            }
            else
            {
                nowMusicNum = 1;
            }
            jsonReader.ChangeJson(nowMusicNum);
        }

        else if(Input.GetKeyDown(KeyCode.W))
        {
            for(int i = musicListNum - 1; i > -1; i--)
            {
                if(i == 0)
                {
                    musicList[i].transform.position = musicListPosDatas[musicListNum - 1];
                    musicList[i].transform.rotation = musicListRotationDatas[musicListNum - 1];
                }else
                {
                    musicList[i].transform.position = musicListPosDatas[i - 1];
                    musicList[i].transform.rotation = musicListRotationDatas[i - 1];
                }
            }
            if(nowMusicNum > 1)
            {
                nowMusicNum--;
            }
            else
            {
                nowMusicNum = musicListNum;
            }
            jsonReader.ChangeJson(nowMusicNum);
        }
    }
}
