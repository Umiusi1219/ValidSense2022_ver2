using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのスコア記憶用
    /// </summary>
    public int scoreValue;

    [SerializeField]
    private int _usePlayer;

    /// <summary>
    /// 自身のテキスト干渉用
    /// </summary>
    private Text _scoreText;


    [SerializeField]
    GameObject sceneManager;


    private void Start()
    {
        // scoreText に自身を入れる
        _scoreText = GetComponent<Text>();

        // scoreの表示の初期化
        ScoreUpdate();

        sceneManager = GameObject.Find("SceneManager");
    }


    public void ScoreUpdate()
    {
        _scoreText.text = scoreValue.ToString();
    }

    public void SetScore()
    {
        sceneManager.GetComponent<PlayerManagerScript>().score[_usePlayer] = scoreValue;
    }
}
