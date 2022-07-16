using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicListControl : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManager;


    private Vector3[] musicListPosDatas;
    private Quaternion[] musicListRotationDatas;

    private GameObject[] musicList;

    private int musicListNum;
    private int nowMusicNum = 1;
    private bool isScrolling = false;
    private float scrollingSpeed = 0.5f;
    private float scrollTime = 0;
    [SerializeField]private float scrollSpeed = 0.02f;
    private GameObject jsonReader;
    void Start()
    {
        //Debug.Log(transform.childCount);
        jsonReader = GameObject.Find("Json");
        musicListNum = transform.childCount;
        musicListPosDatas = new Vector3[musicListNum];
        musicListRotationDatas = new Quaternion[musicListNum];
        musicList = new GameObject[musicListNum];

        for(int i = 0; i < musicListNum; i++)
        {
            musicList[i] = transform.GetChild(i).gameObject;
        }


        sceneManager = GameObject.Find("SceneManager");
    }

    void Update()
    {

        /*for(int i = 0; i < musicListNum; i++)
        {
            musicListPosDatas[i] = musicList[i].transform.position;
            musicListRotationDatas[i] = musicList[i].transform.rotation;
        }*/

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(ScrollUp());
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(ScrollDown());
        }


        if (Input.GetKeyDown(KeyCode.Q) && nowMusicNum == 1)
        {
            sceneManager.GetComponent<Test>().ToMainScene();
        }
    }

    private IEnumerator ScrollDown()
    {
        if(isScrolling) { yield break; }

        isScrolling = true;
        for(int i = 0; i < musicListNum; i++)
        {
            musicListPosDatas[i] = musicList[i].transform.position;
            musicListRotationDatas[i] = musicList[i].transform.rotation;
        }
        for(float t = 0; t <= 1.1f; t += 0.1f)
        {
            for(int i = musicListNum - 1; i >= 0; i--)
            {
                if(i == 0)
                {
                    musicList[i].transform.position = Vector3.Lerp(musicListPosDatas[i], musicListPosDatas[musicListNum - 1], t);
                    musicList[i].transform.rotation = Quaternion.Lerp(musicListRotationDatas[i], musicListRotationDatas[musicListNum - 1], t);
                    
                }else
                {
                    musicList[i].transform.position = Vector3.Lerp(musicListPosDatas[i], musicListPosDatas[i - 1], t);
                    musicList[i].transform.rotation = Quaternion.Lerp(musicListRotationDatas[i], musicListRotationDatas[i - 1], t);
                }
            }
            yield return new WaitForSeconds(scrollSpeed);
        }
        ScrollDownNumChange();
        jsonReader.SendMessage("ChangeJson",nowMusicNum);
        isScrolling = false;
    }
    private IEnumerator ScrollUp()
    {
        if(isScrolling) { yield break; }

        isScrolling = true;
        for(int i = musicListNum - 1; i >= 0; i--)
        {
            musicListPosDatas[i] = musicList[i].transform.position;
            musicListRotationDatas[i] = musicList[i].transform.rotation;
        }
        for(float t = 0; t <= 1.1f; t += 0.1f)
        {
            for(int i = 0; i < musicListNum ; i++)
            {
                if(i == (musicListNum - 1))
                {
                    musicList[i].transform.position = Vector3.Lerp(musicListPosDatas[i], musicListPosDatas[0], t);
                    musicList[i].transform.rotation = Quaternion.Lerp(musicListRotationDatas[i], musicListRotationDatas[0], t);
                    
                }else
                {
                    musicList[i].transform.position = Vector3.Lerp(musicListPosDatas[i], musicListPosDatas[i + 1], t);
                    musicList[i].transform.rotation = Quaternion.Lerp(musicListRotationDatas[i], musicListRotationDatas[i + 1], t);
                }
            }
            yield return new WaitForSeconds(scrollSpeed);
        }
        ScrollUpNumChange();
        jsonReader.SendMessage("ChangeJson",nowMusicNum);
        isScrolling = false;
    }

    private void ScrollUpNumChange()
    {
        if(nowMusicNum > 1)
        {
            nowMusicNum--;
        }
        else
        {
            nowMusicNum = musicListNum;
        }
    }

    private void ScrollDownNumChange()
    {
        if(nowMusicNum < musicListNum)
        {
            nowMusicNum++;
        }
        else
        {
            nowMusicNum = 1;
        }
    }

    private IEnumerator ScrollUpDelta()
    {
        if(isScrolling) { yield break; }

        isScrolling = true;
        
        for(int i = musicListNum - 1; i >= 0; i--)
        {
            musicListPosDatas[i] = musicList[i].transform.position;
            musicListRotationDatas[i] = musicList[i].transform.rotation;
        }
        float t = 0f;
        t += Time.deltaTime;
            for(int i = 0; i < musicListNum ; i++)
            {
                if(i == (musicListNum - 1))
                {
                    musicList[i].transform.position = Vector3.Lerp(musicListPosDatas[i], musicListPosDatas[0], t);
                    musicList[i].transform.rotation = Quaternion.Lerp(musicListRotationDatas[i], musicListRotationDatas[0], t);
                    
                }else
                {
                    musicList[i].transform.position = Vector3.Lerp(musicListPosDatas[i], musicListPosDatas[i + 1], t);
                    musicList[i].transform.rotation = Quaternion.Lerp(musicListRotationDatas[i], musicListRotationDatas[i + 1], t);
                }
            }
        
        ScrollUpNumChange();
        jsonReader.SendMessage("ChangeJson",nowMusicNum);
        isScrolling = false;
    }
}
