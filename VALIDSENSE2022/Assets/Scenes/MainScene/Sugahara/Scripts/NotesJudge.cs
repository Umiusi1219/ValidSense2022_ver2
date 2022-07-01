using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesJudge : MonoBehaviour
{

    /// <summary>
    /// ViewNoteManager�ɎQ�Ƃ���p
    /// </summary>
    [SerializeField]
    ViewNotesManager viewNotesManager;

    /// <summary>
    /// �G�t�F�N�g�����p�̃G�t�F�N�g���X�g
    /// </summary>
    [SerializeField]
    List<GameObject> effectList;

    /// <summary>
    /// �G�t�F�N�g�������́AxPos�w��p
    /// </summary>
    [SerializeField]
    private float[] instancePosXs;

    /// <summary>
    /// �G�t�F�N�g�������́AxPos�w��p
    /// </summary>
    [SerializeField]
    private float instancePosY;

    /// <summary>
    /// �G�t�F�N�g�������́AxPos�w��p
    /// </summary>
    [SerializeField]
    private float instancePosZ;


    /// <summary>
    /// NoteJudge�̎��
    /// </summary>
    enum JudgeType
    {
        Briliant = 0,
        Great,
        Good,
        Poor,
    }

    /*
    Briliant +- 20ms
    Great +- 40ms
    Good +- 100ms
    Poor
    */


    ////Poor�����mp4�����p
    //float x = -19.5f;
    //float y = -260;
    //float z = 300;
    //float w = -20;
    [SerializeField]
    Transform instanceTransform;



    /// <summary>
    /// Briliant�̔���p�̒l
    /// </summary>
    private long briliantJudge = 20;
    /// <summary>
    /// Great�̔���p�̒l
    /// </summary>
    private long greatJudge = 40;
    /// <summary>
    /// Good�̔���p�̒l
    /// </summary>
    private long goodJudge = 100;

    /// <summary>
    /// �X�L���Ŕ�����i��ׂ̒l
    /// </summary>
    [SerializeField]
    public long judgeLeverage;


    /// <summary>
    /// �X�R�A�pUI�Q�Ɨp
    /// </summary>
    [SerializeField]
    private ScoreScript scoreValue;


    /// <summary>
    /// Briliant�̔��莞�A���Z�����X�R�A�̒l
    /// </summary>
    [SerializeField]
    private int _briliantScore;

    /// <summary>
    /// Great�̔��莞�A���Z�����X�R�A�̒l
    /// </summary>
    [SerializeField]
    private int _greatScore;

    /// <summary>
    /// Good�̔��莞�A���Z�����X�R�A�̒l
    /// </summary>
    [SerializeField]
    private int _goodScore;


    //public static NotesJudge instance;

    //private void Awake()
    //{
    //     if(instance = null)
    //     {
    //        instance = this;
    //     }
    //}


    private void Start()
    {

    }


    /// <summary>
    /// �n���ꂽ���Ԃ����ƂɁA���̏󋵂œK�؂Ȕ�����v�Z����
    /// </summary>
    /// <param name="time">���肷��m�[�c�̎���</param>
    /// <param name="line">���肷��m�[�c���������Ă��郌�[��</param>
    public void NotesJudgement(long time, int line)
    {
        // Briliant�̔��莞�� / �X�L���ɂ��{���ȉ��Ȃ�
        if (time <= briliantJudge * judgeLeverage)
        {
            //Debug.Log(JudgeType.Briliant);
            //Debug.Log("JudgeTime" + MusicData.Timer);

            // Briliant�̃G�t�F�N�g��������line�ɐ���
            Instantiate(effectList[(int)JudgeType.Briliant],
                new Vector3(instancePosXs[line], instancePosY, instancePosZ), new Quaternion(0, 0, 0, 0));


            //�X�R�A�����ɁABriliant�̒l������
            scoreValue.scoreValue += _briliantScore;
        }

        // Graet�̔��莞�� * �X�L���ɂ��{���ȉ��Ȃ�
        else if (time <= greatJudge * judgeLeverage)
        {
            //Debug.Log(JudgeType.Great);
            //Debug.Log("JudgeTime" + MusicData.Timer);

            // Graet�̃G�t�F�N�g��������line�ɐ���
            Instantiate(effectList[(int)JudgeType.Great],
                new Vector3(instancePosXs[line], instancePosY, instancePosZ), new Quaternion(0, 0, 0, 0));


            //�X�R�A�����ɁAGraet�̒l������
            scoreValue.scoreValue += _greatScore;
        }

        // Good�̔��莞�� * �X�L���ɂ��{���ȉ��Ȃ�
        else if (time <= goodJudge * judgeLeverage)
        {
            //Debug.Log(JudgeType.Good);
            //Debug.Log("JudgeTime" + MusicData.Timer);

            // Good�̃G�t�F�N�g��������line�ɐ���
            Instantiate(effectList[(int)JudgeType.Good],
                new Vector3(instancePosXs[line], instancePosY, instancePosZ), new Quaternion(0, 0, 0, 0));


            //�X�R�A�����ɁAGood�̒l������
            scoreValue.scoreValue += _goodScore;
        }
        //poor����
        else
        {
            //Debug.Log(JudgeType.Poor);
            //Debug.Log("JudgeTime" + MusicData.Timer);

            // Poor�̃G�t�F�N�g��������line�ɐ���
            Instantiate(effectList[(int)JudgeType.Poor],
                new Vector3(instancePosXs[line], instancePosY, instancePosZ), 
                instanceTransform.rotation);
        }


        // �X�R�AUI�̍X�V
        scoreValue.ScoreUpdate();


        // ������擾����Notes�̃t�F�[�h�A�E�g
        viewNotesManager.NowNotesFadeOut(line);
    }
}