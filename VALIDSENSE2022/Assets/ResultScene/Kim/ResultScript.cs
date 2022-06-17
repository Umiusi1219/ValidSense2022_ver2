using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    [SerializeField]
    private int _playerNum;

    public Text Result_Text;
    // Start is called before the first frame update
    void Start()
    {
        Result_Text.text = "スコア :" + PlayerManagerScript.score[_playerNum] + " \n"
            + "曲名 : " + PlayerManagerScript.nowMusicNum[_playerNum] + "\n"
            + "難易度 : " + PlayerManagerScript.nowMusicLevel[_playerNum] + "\n"
            + "\n"
            + "総打数 : " + PlayerManagerScript.totalHitsNum[_playerNum] + "\n"
            + "奪ったレーン数 : " + PlayerManagerScript.stolenLane[_playerNum] + "\n"
            + "奪われたレーン数" + PlayerManagerScript.losLanes[_playerNum] + "\n"
            + "\n"
            + "Vボタンでスキップ"
            + "\n";

    }
}
