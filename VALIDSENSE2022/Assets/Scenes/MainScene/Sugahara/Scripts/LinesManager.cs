using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesManager : MonoBehaviour
{
    /// <summary>
    /// キャラをいじってるObjに参照用
    /// </summary>
    [SerializeField]
    TestChara testChara;

    /// <summary>
    /// live2DをいじってるObjに参照する用
    /// </summary>
    [SerializeField]
    GameObject live2D_Canvas;


    /// <summary>
    /// ノーツの見た目などを管理してる子に参照する用
    /// </summary>
    [SerializeField]
    ViewNotesManager viewNotesManager;


    /// <summary>
    /// 1pのスコアの数値を参照する用
    /// </summary>
    [SerializeField]
    List <ScoreScript> scoreScript;


    /// <summary>
    /// 1pのスコアの数値を参照する用
    /// </summary>
    [SerializeField]
    List<GameObject> skillUI;


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
    [Range(0, 6)]
    [SerializeField]
    public int haveLines_1p;


    /// <summary>
    /// lineの透明度を指定する
    /// </summary>
    [Range(0f, 1.0f)]
    [SerializeField]
    private float _lineAlpha;

    /// <summary>
    /// ジャッチ演出で使う、ジャッチ開始までの時間
    /// </summary>
    [SerializeField]
    private float judgeStandbyTime;


    /// <summary>
    /// ジャッチ演出で使う、レーンの色を何秒おきに変えるか設定用
    /// </summary>
    [SerializeField]
    private float judgeColourChangeStandbyTime;


    /// <summary>
    /// 勝った方のプレイヤー番号
    /// </summary>
    private int winPlayerNum;


    private void Start()
    {
        // 1p2pのキャラに合わせてLineの色を変える
        SetLineColor_1p2p();


        //StartCoroutine(LineJudgmentPerformance());
    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("1Pがラインとられた");

            LineIsStolen_1p();
        }


        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("2Pがラインとられた");

            LineIsStolen_2p();
        }


        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    Debug.Log("全ラインを灰色化");

        //    OllLineColorChange();
        //}

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Debug.Log("ラインをリセット");
        //    SetLineColor_1p2p();

        //    haveLines_1p = 3;
        //}



        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine( LineJudgmentPerformance());
        }
    }





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
        if (haveLines_1p > 0)
        {
            // レーン奪取SE
            SEPlayer.instance.SEOneShot(8);


            // Color型への変換成功するとcolorにColor型の2pキャラのカラーコードが代入される）outキーワードで参照渡しにする
            if (ColorUtility.TryParseHtmlString(charaColorCode[testChara.count[1]],
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
            if (haveLines_1p <= 3)
            {
                scoreScript[1].scoreValue += _lineStealScore[0];
            }
            else
            {
                scoreScript[1].scoreValue += _lineStealScore[1];
            }
            //スコア表記の更新
            scoreScript[1].ScoreUpdate();


            //奪われたラインに流れてるノーツの色を2pの色に変更
            viewNotesManager.ActiveViewNotesColourChange(haveLines_1p + 1, 1);



            testChara.Chara_Anim_Att(1);

            testChara.Chara_Anim_Hit(0);
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
            // レーン奪取SE
            SEPlayer.instance.SEOneShot(8);



            // Color型への変換成功すると（colorにColor型の赤色が代入される）outキーワードで参照渡しにする
            if (ColorUtility.TryParseHtmlString(charaColorCode[testChara.count[0]],
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
                scoreScript[0].scoreValue += _lineStealScore[0];
            }
            else
            {
                scoreScript[0].scoreValue += _lineStealScore[1];
            }

            //スコア表記の更新
            scoreScript[0].ScoreUpdate();


            //奪われたラインに流れてるノーツの色を1pの色に変更
            viewNotesManager.ActiveViewNotesColourChange(haveLines_1p, 0);



            testChara.Chara_Anim_Att(0);

            testChara.Chara_Anim_Hit(1);
        }
    }


    /// <summary>
    /// 全ラインをカラーコード配列の任意の色に変える
    /// </summary>
    /// <param name="colourNum">カラーコード指定用（0～4）</param>
    void OllLineColorChange(int colourNum)
    {
        // 全ラインに参照
        foreach (GameObject line in lines)
        {
            //カラーコードを指定
            if (ColorUtility.TryParseHtmlString(charaColorCode[colourNum],
                out colorCode))
            {
                // 透明度の設定
                colorCode.a = _lineAlpha;

                // 所持ラインを指定の色に変更する
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
        for (int i = 0; i < lines.Count; i++)
        {
            if (i < 4)
            {
                //1PのカラーコードをcolorCodeに入れる
                ColorUtility.TryParseHtmlString(charaColorCode[testChara.count[0]], out colorCode);

                // 透明度の設定
                colorCode.a = _lineAlpha;

                // ラインの色を変更する
                lines[i].GetComponent<SpriteRenderer>().color = colorCode;

            }
            else
            {
                //2PのカラーコードをcolorCodeに入れる
                ColorUtility.TryParseHtmlString(charaColorCode[testChara.count[1]], out colorCode);

                // 透明度の設定
                colorCode.a = _lineAlpha;

                // ラインの色を変更する
                lines[i].GetComponent<SpriteRenderer>().color = colorCode;
            }
        }
    }


    public IEnumerator LineJudgmentPerformance()
    {
        if (scoreScript[0].scoreValue >= scoreScript[1].scoreValue)
        {
            winPlayerNum = 0;
        }
        else
        {
            winPlayerNum = 1;
        }
            yield return new WaitForSeconds(1f);

        // 全ラインを灰色にする
        OllLineColorChange(4);

        //スキルUIを消す
        skillUI[0].SetActive(false);
        skillUI[1].SetActive(false);

        yield return new WaitForSeconds(1f);
        

        StartCoroutine( 
            live2D_Canvas.GetComponent<MainLive2DCanvas>().Live2DJudgmentPerformance(winPlayerNum));


        yield return new WaitForSeconds(judgeStandbyTime);




        if (winPlayerNum == 0)
        {
            for (int i = 0; i < 8;)
            {
                // レーン奪取SE
                SEPlayer.instance.SEOneShot(8);


                //1PのカラーコードをcolorCodeに入れる
                ColorUtility.TryParseHtmlString(charaColorCode[testChara.count[0]], out colorCode);

                // 透明度の設定
                colorCode.a = _lineAlpha;

                // ラインの色を変更する
                lines[i].GetComponent<SpriteRenderer>().color = colorCode;

                i++;

                yield return new WaitForSeconds(judgeColourChangeStandbyTime);
            }
        }
        else
        {
            for (int i = 0; i < 8;)
            {
                // レーン奪取SE
                SEPlayer.instance.SEOneShot(8);


                //2PのカラーコードをcolorCodeに入れる
                ColorUtility.TryParseHtmlString(charaColorCode[testChara.count[1]], out colorCode);

                // 透明度の設定
                colorCode.a = _lineAlpha;

                // ラインの色を変更する
                lines[7 - i].GetComponent<SpriteRenderer>().color = colorCode;

                i++;

                yield return new WaitForSeconds(judgeColourChangeStandbyTime);
            }
        }

    }
}
