using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainLive2DCanvas : MonoBehaviour
{
    Canvas canvas;


    [SerializeField]
    TestChara testChara;


    /// <summary>
    /// 1P,2P��Live2D��texture�i�[�p
    /// </summary>
    [SerializeField]
    List <RawImage> live2D;

    /// <summary>
    /// �W���b�`���o���̈ړ���
    /// </summary>
    [SerializeField]
    List<RectTransform> judgeWinPos;
    [SerializeField]
    List<RectTransform> judgeLosePos;


    [SerializeField]
    RawImage[] addPosObg;

    [SerializeField]
    float live2DMoveTime;
    [SerializeField]
    float[] live2DMoveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    ///// <summary>
    ///// ���g��order in Layer �̒l����ԏ�܂ŏグ��X�N���v�g
    ///// </summary>
    //public void SortingOrderMostUP()
    //{

    //}


    public IEnumerator Live2DJudgmentPerformance( int winPlayerNum)
    {

        //�X�s�[�h�̐ݒ�
        // 1P ������
        if(winPlayerNum == 0)
        {
            live2DMoveSpeed[0] = 
                (((judgeWinPos[0].position.x + addPosObg[testChara.count[0]].rectTransform.position.x)
                - live2D[0].rectTransform.position.x )/ 60 );

            live2DMoveSpeed[1] = (((judgeLosePos[1].position.x)
                - live2D[1].rectTransform.position.x ) / 60);
        }
        // 2P ������
        else
        {
            live2DMoveSpeed[1] = 
                (((judgeWinPos[1].position.x - addPosObg[testChara.count[0]].rectTransform.position.x)
                - live2D[1].rectTransform.position.x )/ 60 );

            live2DMoveSpeed[0] = (((judgeLosePos[0].position.x )
                - live2D[0].rectTransform.position.x) / 60 );
        }



        // ���C���[���ŏ�i�i11�j�ɂ���
        //for (int i = -2; i <= 11; i++)
        //{
        //    canvas.sortingOrder = i;

        //    yield return new WaitForSeconds(0.02f);
        //}

        //yield return new WaitForSeconds(0.8f);


        canvas.sortingOrder = 11;

        yield return new WaitForSeconds(1.3f);


        if (winPlayerNum == 0)
        {
            testChara.Chara_Anim_Win(0);
            yield return new WaitForSeconds(0.02f);
            testChara.Chara_Anim_Hit(1);
        }
        else
        {
            testChara.Chara_Anim_Win(1);
            yield return new WaitForSeconds(0.02f);
            testChara.Chara_Anim_Hit(0);
        }

        yield return new WaitForSeconds(0.4f);

        //���肪���Ƃ��Ƃ����ꏊ���炢�܂ňړ�����
        if (winPlayerNum == 0)
        {
            while (live2D[0].rectTransform.position.x <= judgeWinPos[0].position.x
                + addPosObg[testChara.count[0]].rectTransform.position.x)
            {
                live2D[0].rectTransform.position += new Vector3(
                    live2DMoveSpeed[0] / live2DMoveTime, 0, 0);

                live2D[1].rectTransform.position += new Vector3(
                    live2DMoveSpeed[1] / live2DMoveTime, 0, 0);

                yield return null;
            }

        }
        else
        {
            while (live2D[1].rectTransform.position.x >= judgeWinPos[1].position.x
                - addPosObg[testChara.count[1]].rectTransform.position.x)
            {
                live2D[0].rectTransform.position += new Vector3(
                    live2DMoveSpeed[0] / live2DMoveTime, 0, 0);

                live2D[1].rectTransform.position += new Vector3(
                    live2DMoveSpeed[1] / live2DMoveTime, 0, 0);

                yield return null;
            }
        }

        if (winPlayerNum == 0)
        {
            while (live2D[1].rectTransform.position.x <= judgeLosePos[1].position.x)
            {

                live2D[1].rectTransform.position += new Vector3(
                    live2DMoveSpeed[1] / live2DMoveTime, 0, 0);

                yield return null;
            }

        }
        else
        {
            while (live2D[0].rectTransform.position.x >= judgeLosePos[0].position.x)
            {
                live2D[0].rectTransform.position += new Vector3(
                    live2DMoveSpeed[0] / live2DMoveTime, 0, 0);


                yield return null;
            }
        }
    }
}
