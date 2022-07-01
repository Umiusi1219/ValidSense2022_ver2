using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesManager : MonoBehaviour
{
    /// <summary>
    /// キャラをいじってる子に参照用
    /// </summary>
    [SerializeField]
    TestChara testChara;

    /// <summary>
    /// Line参照用
    /// </summary>
    [SerializeField]
    List<GameObject> lines;


    /// <summary>
    /// Lineの色変更時使用するカラーコードの、配列
    /// </summary>
    public string[] charaColorCode;


    /// <summary>
    ///string型のカラーコードをColor変換した時の受け取り先
    /// </summary>
    Color colorCode;


    /// <summary>
    /// 現在所持しているラインの本数(配列用に0から計算)
    /// </summary>
    [Range(1, 6)]
    [SerializeField]
    private int _1pHaveLines;


    /// <summary>
    /// lineの透明度を指定する
    /// </summary>
    [Range(0f, 1.0f)]
    [SerializeField]
    private float _lineAlpha;


    /// <summary>
    /// 所持ラインの一番相手側を相手の色に変更する
    /// </summary>
    /// <param name="opponentChara">対戦相手のキャラ番号</param>
    void LineIsStolen_1p(int opponentCharaNum)
    {
        //配列参照を防ぐ
        if(_1pHaveLines > 0 )
        {
            // Color型への変換成功するとcolorにColor型の赤色が代入される）outキーワードで参照渡しにする
            if (ColorUtility.TryParseHtmlString(charaColorCode[opponentCharaNum],
                out colorCode))
            {
                // 透明度の設定
                colorCode.a = _lineAlpha;

                // 所持ラインの一番相手側を相手の色に変更する
                lines[_1pHaveLines].GetComponent<SpriteRenderer>().color = colorCode;

                // 所持ラインを減算
                _1pHaveLines--;
            }
        }
    }


    /// <summary>
    /// 相手の所持ラインの一番自分側を自分の色に変更する
    /// </summary>
    /// <param name="opponentChara">自分のキャラ番号</param>
    void LineIsStolen_2p(int myCharaNum)
    {
        //配列参照を防ぐ
        if (_1pHaveLines < 6)
        {
            // Color型への変換成功すると（colorにColor型の赤色が代入される）outキーワードで参照渡しにする
            if (ColorUtility.TryParseHtmlString(charaColorCode[myCharaNum],
                out colorCode))
            {

                // 所持ラインを加算
                _1pHaveLines++;

                // 透明度の設定
                colorCode.a = _lineAlpha;

                // 相手の所持ラインの一番1p側を1pの色に変更する
                lines[_1pHaveLines].GetComponent<SpriteRenderer>().color = colorCode;

            }
        }
    }

    /// <summary>
    /// 全ラインを灰色化する
    /// </summary>
    void OllLineColorChange()
    {
        // 全ラインに参照
        foreach (GameObject line in lines)
        {
            //灰色に指定
            if (ColorUtility.TryParseHtmlString(charaColorCode[4],
                out colorCode))
            {
                // 透明度の設定
                colorCode.a = _lineAlpha;

                // 所持ラインを灰色に変更する
                line.GetComponent<SpriteRenderer>().color = colorCode;
            }
        }
    }


    /// <summary>
    /// 1p2pのラインを各キャラカラーに変更する
    /// </summary>
    void SetLineColor_1p2p()
    {
        //レーン数分繰り返す
        for(int i = 0; i < lines.Count; i++)
        {
            if(i <4)
            {
                //1PのカラーコードをcolorCodeに入れる
                ColorUtility.TryParseHtmlString(charaColorCode[testChara.count1P], out colorCode);

                // 透明度の設定
                colorCode.a = _lineAlpha;

                // ラインの色を変更する
                lines[i].GetComponent<SpriteRenderer>().color = colorCode;

            }
            else
            {
                //2PのカラーコードをcolorCodeに入れる
                ColorUtility.TryParseHtmlString(charaColorCode[testChara.count2P], out colorCode);

                // 透明度の設定
                colorCode.a = _lineAlpha;

                // ラインの色を変更する
                lines[i].GetComponent<SpriteRenderer>().color = colorCode;
            }
        }
    }


    private void Start()
    {
        // 1p2pのキャラに合わせてLineの色を変える
        SetLineColor_1p2p();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("1Pがラインとられた");

            LineIsStolen_1p(testChara.count2P);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("2Pがラインとられた");

            LineIsStolen_2p(testChara.count1P);
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("全ラインを灰色化");

            OllLineColorChange();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("ラインをリセット");
            SetLineColor_1p2p();

            _1pHaveLines = 3;
        }
    }
}
