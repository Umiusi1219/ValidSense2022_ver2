using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevelSelect : MonoBehaviour
{
    /// <summary>
    /// cursorの座標
    /// </summary>
    [SerializeField]
    private Vector3[] _cursorPosY;

    /// <summary>
    /// cursor座標の配列
    /// </summary>
    [SerializeField]
    private int _cursorPosNum;

    /// <summary>
    /// 選択した曲の難易度の数
    /// </summary>
    [SerializeField]
    public int levelsMax;


    void Start()
    {
        //cursorを初期位置に移動
        MoveCursor(0);
    }


    void Update()
    {
        //Wを押したら上に移動する1番上だったら1番下に移動する
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_cursorPosNum > 0)
            {
                _cursorPosNum--;
            }
            else if (_cursorPosNum <= 0)
            {
                _cursorPosNum = (levelsMax - 1);
            }

            MoveCursor(_cursorPosNum);
        }
        //Sを押したら下に移動する1番下だったら1番上に移動する
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _cursorPosNum = (_cursorPosNum + 1) % levelsMax;

            MoveCursor(_cursorPosNum);
        }
    }


    /// <summary>
    /// カーソルを _cursorPosY[引数] の場所に移動させる関数です
    /// </summary>
    /// <param name="posNum">0 ～ levelsMaxの値のみ入れてください</param>
    private void MoveCursor(int posNum)
    {
        this.transform.position = _cursorPosY[posNum];
    }
}
