using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainLive2DCanvas : MonoBehaviour
{
    Canvas canvas;


    /// <summary>
    /// 1P,2PのLive2Dのtexture格納用
    /// </summary>
    [SerializeField]
    List <RawImage> live2D;

    /// <summary>
    /// ジャッチ演出時の移動先
    /// </summary>
    [SerializeField]
    List<RectTransform> judgeStartPos;
    [SerializeField]
    List<RectTransform> judgeEndPos;

    [SerializeField]
    float live2DMoveTime;
    [SerializeField]
    float[] live2DMoveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    /// <summary>
    /// 自身のorder in Layer の値を一番上まで上げるスクリプト
    /// </summary>
    public void SortingOrderMostUP()
    {
        canvas.sortingOrder = 50;
    }


    public IEnumerator Live2DJudgmentPerformance( int winPlayerNum)
    {

        //スピードの設定
        live2DMoveSpeed[0] = ((live2D[0].rectTransform.position.x - judgeStartPos[0].position.x)
            / 60 / live2DMoveTime);

        live2DMoveSpeed[1] = ((judgeStartPos[1].position.x - live2D[1].rectTransform.position.x)
            / 60 / live2DMoveTime);



        // 画面外にはける
        // 1P,2Pのライブ2Dが移動し終わるまで移動し続ける
        while (live2D[0].rectTransform.position.x > judgeStartPos[0].position.x ||
            live2D[1].rectTransform.position.x < judgeStartPos[1].position.x) 
        {



            live2D[0].rectTransform.position -= new Vector3(
                live2DMoveSpeed[0] / live2DMoveTime , 0, 0);

            live2D[1].rectTransform.position += new Vector3(
                live2DMoveSpeed[1] / live2DMoveTime, 0, 0);

            yield return null;
        }


        SortingOrderMostUP();


        yield return new WaitForSeconds(1f);

        //相手がもともといた場所くらいまで移動する
        if (winPlayerNum == 0)
        {
            while (live2D[0].rectTransform.position.x <= judgeEndPos[0].position.x)
            {
                live2D[0].rectTransform.position += new Vector3(
                    live2DMoveSpeed[0] * 1.2f , 0, 0);

                yield return null;
            }

        }
        else
        {
            while (live2D[1].rectTransform.position.x >= judgeEndPos[1].position.x)
            {
                live2D[1].rectTransform.position -= new Vector3(
                live2DMoveSpeed[1] * 1.2f, 0, 0);

                yield return null;
            }
        }



    }
}
