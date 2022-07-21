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

    [SerializeField]
    private string[] CharaNameAndCV;


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

        var playerManagar = sceneManager.GetComponent<PlayerManagerScript>();

        text = gameObject.GetComponent<Text>();

        text.text =
            CharaNameAndCV[playerManagar.playerCharaNum[playerNum[0]]] + "\n" +
            "\n" +
            "スコア　" + playerManagar.score[playerNum[0]] + "\n" +
            "曲名　" + "Chartreuse Green" + "\n" +
            "作曲者名　" + "t+pazolite" + "\n" +
            "難易度　" + "6" + "\n" +
            "\n" +
            "総打数　" + playerManagar.totalHitsNum[playerNum[0]] + "\n" +
            "奪ったレーン　" + playerManagar.stolenLane[playerNum[0]] + "\n" +
            "奪われたレーン　" + playerManagar.stolenLane[playerNum[1]] + "\n" +
            "\n" +
            "ボタンを押してスキップ";
    }

}
