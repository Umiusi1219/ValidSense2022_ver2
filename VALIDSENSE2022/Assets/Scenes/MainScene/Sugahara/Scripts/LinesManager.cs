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
    /// ノーツの見た目などを管理してる子に参照する用
    /// </summary>
    [SerializeField]
    ViewNotesManager viewNotesManager;


    /// <summary>
    /// 1pのスコアの数値を参照する用
    /// </summary>
    [SerializeField]
    ScoreScript scoreScript_1p;

    /// <summary>
    /// 2pのスコアの数値を参照する用
    /// </summary>
    [SerializeField]
    ScoreScript scoreScript_2p;


    /// <summary>
    /// Line参照用
    /// </summary>
    [SerializeField]
    List<GameObject> lines;


    /// <summary>
    /// レーン奪取時に加算されるスコアの値
    /// </summary>
    [SerializeField]
    private int[] _lineStealScore;


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
    public int haveLines_1p;


    /// <summary>
    /// lineの透明度を指定する
    /// </summary>
    [Range(0f, 1.0f)]
    [SerializeField]
    private float _lineAlpha;


    /// <summary>
    /// 1pHaveLineのゲッター
    /// </summary>
    /// <returns></returns>
    public int Get_1pHaveLines()
    {
        return haveLines_1p;
    }


    /// <summary>
    /// 1p所持ラインの一番2p側を相手の色に変更する
    /// </summary>
    public void LineIsStolen_1p()
    {
        //配列参照を防ぐ
        if(haveLines_1p > 0 )
        {
            // Color型への変換成功するとcolorにColor型の赤色が代入される）outキーワードで参照渡しにする
            if (ColorUtility.TryParseHtmlString(charaColorCode[testChara.count2P],
                out colorCode))
            {
                // 透明度の設定
                colorCode.a = _lineAlpha;

                // 所持ラインの一番2p側を相手の色に変更する
                lines[haveLines_1p].GetComponent<SpriteRenderer>().color = colorCode;

                // 1p所持ラインを減算
                haveLines_1p--;
            }


            //1pのラインを奪取されたので２Pのスコアを加算
            //1pの所持ラインが3以下なら元々2pのラインなので加算直が少ないほうを適応
            if(haveLines_1p <= 3)
            {
                scoreScript_2p.scoreValue += _lineStealScore[0];
            }
            else
            {
                scoreScript_2p.scoreValue += _lineStealScore[1];
            }
            //スコア表記の更新
            scoreScript_2p.ScoreUpdate();


            //奪われたラインに流れてるノーツの色を2pの色に変更
            viewNotesManager.NowActNotesColorChange(haveLines_1p +1, 2);
        }
    }


    /// <summary>
    /// 2pの所持ラインの一番1p側を自分の色に変更する
    /// </summary>
    public void LineIsStolen_2p()
    {
        //配列参照を防ぐ
        if (haveLines_1p < 6)
        {
            // Color型への変換成功すると（colorにColor型の赤色が代入される）outキーワードで参照渡しにする
            if (ColorUtility.TryParseHtmlString(charaColorCode[testChara.count1P],
                out colorCode))
            {

                // 1p所持ラインを加算
                haveLines_1p++;

                // 透明度の設定
                colorCode.a = _lineAlpha;

                // 2pの所持ラインの一番1p側を1pの色に変更する
                lines[haveLines_1p].GetComponent<SpriteRenderer>().color = colorCode;

            }

            //2pのラインを奪取されたので1pのスコアを加算
            //1pの所持ラインが3以下なら元々2pのラインなので加算直が少ないほうを適応
            if (haveLines_1p >= 4)
            {
                scoreScript_1p.scoreValue += _lineStealScore[0];
            }
            else
            {
                scoreScript_1p.scoreValue += _lineStealScore[1];
            }

            //スコア表記の更新
            scoreScript_1p.ScoreUpdate();


            //奪われたラインに流れてるノーツの色を1pの色に変更
            viewNotesManager.NowActNotesColorChange(haveLines_1p - 1, 1);
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

            LineIsStolen_1p();
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("2Pがラインとられた");

            LineIsStolen_2p();
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

            haveLines_1p = 3;
        }
    }
}
