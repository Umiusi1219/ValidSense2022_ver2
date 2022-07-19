using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainLive2DCanvas : MonoBehaviour
{
    Canvas canvas;


    /// <summary>
    /// 1P,2P��Live2D��texture�i�[�p
    /// </summary>
    [SerializeField]
    List <RawImage> live2D;

    /// <summary>
    /// �W���b�`���o���̈ړ���
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
    /// ���g��order in Layer �̒l����ԏ�܂ŏグ��X�N���v�g
    /// </summary>
    public void SortingOrderMostUP()
    {
        canvas.sortingOrder = 50;
    }


    public IEnumerator Live2DJudgmentPerformance( int winPlayerNum)
    {

        //�X�s�[�h�̐ݒ�
        live2DMoveSpeed[0] = ((live2D[0].rectTransform.position.x - judgeStartPos[0].position.x)
            / 60 / live2DMoveTime);

        live2DMoveSpeed[1] = ((judgeStartPos[1].position.x - live2D[1].rectTransform.position.x)
            / 60 / live2DMoveTime);



        // ��ʊO�ɂ͂���
        // 1P,2P�̃��C�u2D���ړ����I���܂ňړ���������
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

        //���肪���Ƃ��Ƃ����ꏊ���炢�܂ňړ�����
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
