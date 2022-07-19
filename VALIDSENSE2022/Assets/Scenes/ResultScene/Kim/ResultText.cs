using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManager;

    [SerializeField]
    int[] playerNum;

    private Text text;


    /*
スコア
曲名
作曲者名
難易度

総打数
奪ったレーン
奪われたレーン

ボタンを押してスキップ
     */


    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");

        text = gameObject.GetComponent<Text>();

        text.text =
            "スコア　" + sceneManager.GetComponent<PlayerManagerScript>().score[playerNum[0]] + "\n" +
            "曲名　" + "Chartreuse Green" + "\n" +
            "作曲者名　" + "t+pazolite" + "\n" +
            "難易度　" + "6" + "\n" +
            "\n" +
            "総打数　" + sceneManager.GetComponent<PlayerManagerScript>().totalHitsNum[playerNum[0]] + "\n" +
            "奪ったレーン　" + sceneManager.GetComponent<PlayerManagerScript>().stolenLane[playerNum[0]] + "\n" +
            "奪われたレーン　" + sceneManager.GetComponent<PlayerManagerScript>().stolenLane[playerNum[1]] + "\n" +
            "\n" +
            "ボタンを押してスキップ";
    }

}
