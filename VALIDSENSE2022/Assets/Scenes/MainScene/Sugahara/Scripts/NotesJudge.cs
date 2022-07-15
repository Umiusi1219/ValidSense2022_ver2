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
    /// �X�L���̃`���[�W����\���̂���I�u�W�F�N�g
    /// </summary>
    [SerializeField]
    SkillChargeRate skillChargeText;


    /// <summary>
    /// �R���{����\�L���Ă�I�u�W�F�N�g�ɎQ�Ƃ���p
    /// </summary>
    [SerializeField]
    ComboScript ComboScript;


    /// <summary>
    /// Line���Ǘ����Ă�}�l�[�W���[�ɎQ�Ƃ���p
    /// </summary>
    [SerializeField]
    LinesManager linesManager;


    /// <summary>
    /// playerInput�ɎQ�Ƃ���p
    /// </summary>
    [SerializeField]
    PlayerInput playerInput;


    /// <summary>
    /// ���[���D��Ɏg�p����Apoor���L���p
    /// </summary>
    [SerializeField]
    private int _poorCount;


    /// <summary>
    /// ���[���D�悷��^�C�~���O
    /// </summary>
    [SerializeField]
    private int _lineStealTiming;



    /// <summary>
    /// �G�t�F�N�g�����p�̃G�t�F�N�g���X�g
    /// </summary>
    [SerializeField]
    List<RawImage> effectList;


    /// <summary>
    /// ��������G�t�F�N�g�̈ꎞ�ۑ���
    /// </summary>
    [SerializeField]
    RawImage[] effect;

    /// <summary>
    /// ��������G�t�F�N�g�̐e
    /// </summary>
    [SerializeField]
    Canvas effectParent;


    /// <summary>
    /// �G�t�F�N�g�������́APos�w��p
    /// </summary>
    [SerializeField]
    private RectTransform[] instancePos;


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
    //[SerializeField]
    //Transform instanceTransform;



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
    /// �X�L���̃`���[�W�̒l�����p
    /// </summary>
    [SerializeField]
    int[] addSkillValue;


    /// <summary>
    /// �X�L���Ŕ�����i��ׂ̒l(����Z)
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



    /// <summary>
    /// �n���ꂽ���Ԃ����ƂɁA���̏󋵂œK�؂Ȕ�����v�Z����
    /// </summary>
    /// <param name="time">���肷��m�[�c�̎���</param>
    /// <param name="line">���肷��m�[�c���������Ă��郌�[��</param>
    public void NotesJudgement(long time, int line)
    {

        // Briliant�̔��莞�� / �X�L���ɂ��{���ȉ��Ȃ�
        if (time <= briliantJudge / judgeLeverage)
        {
            //Briliant�G�t�F�N�g���ꎞ�i�[�I�u�W�F�N�g�ɐ���
            effect[line] = Instantiate(effectList[(int)JudgeType.Briliant]);

            //���������I�u�W�F�N�g�̐e��ݒ�
            effect[line].transform.parent = effectParent.transform;

            // �G�t�F�N�g��������line�ɑΉ�����ꏊ�Ɉړ�
            effect[line].rectTransform.position = instancePos[line].position;



            //�X�R�A�����ɁABriliant�̒l������
            scoreValue.scoreValue += _briliantScore;

            //�X�L���̃`���[�W���̑���(Briliant)
            skillChargeText.AddSkillValue(addSkillValue[(int)JudgeType.Briliant]);

            //�R���{���̉��Z
            ComboScript.AddComboValue();
        }

        // Great�̔��莞�� / �X�L���ɂ��{���ȉ��Ȃ�
        else if (time <= greatJudge / judgeLeverage)
        {
            //Great�G�t�F�N�g���ꎞ�i�[�I�u�W�F�N�g�ɐ���
            effect[line] = Instantiate(effectList[(int)JudgeType.Great]);

            //���������I�u�W�F�N�g�̐e��ݒ�
            effect[line].transform.parent = effectParent.transform;

            // �G�t�F�N�g��������line�ɑΉ�����ꏊ�Ɉړ�
            effect[line].rectTransform.position = instancePos[line].position;



            //�X�R�A�����ɁAGraet�̒l������
            scoreValue.scoreValue += _greatScore;

            //�X�L���̃`���[�W���̑���(Great)
            skillChargeText.AddSkillValue(addSkillValue[(int)JudgeType.Great]);

            //�R���{���̉��Z
            ComboScript.AddComboValue();
        }

        // Good�̔��莞�� / �X�L���ɂ��{���ȉ��Ȃ�
        else if (time <= goodJudge / judgeLeverage)
        {
            //Good�G�t�F�N�g���ꎞ�i�[�I�u�W�F�N�g�ɐ���
            effect[line] = Instantiate(effectList[(int)JudgeType.Good]);

            //���������I�u�W�F�N�g�̐e��ݒ�
            effect[line].transform.parent = effectParent.transform;

            // �G�t�F�N�g��������line�ɑΉ�����ꏊ�Ɉړ�
            effect[line].rectTransform.position = instancePos[line].position;


            //�X�R�A�����ɁAGood�̒l������
            scoreValue.scoreValue += _goodScore;

            //�X�L���̃`���[�W���̑���(Good)
            skillChargeText.AddSkillValue(addSkillValue[(int)JudgeType.Good]);

            //�R���{���̉��Z
            ComboScript.AddComboValue();
        }

        //poor����
        else
        {
            //poor�G�t�F�N�g���ꎞ�i�[�I�u�W�F�N�g�ɐ���
            effect[line] = Instantiate(effectList[(int)JudgeType.Poor]);

            //���������I�u�W�F�N�g�̐e��ݒ�
            effect[line].transform.parent = effectParent.transform;

            // �G�t�F�N�g��������line�ɑΉ�����ꏊ�Ɉړ�
            effect[line].rectTransform.position = instancePos[line].position;


            // poor���肵���̂ŉ��Z
            _poorCount++;

            //�R���{���̃��Z�b�g
            ComboScript.ComboReset();
        }


        // �X�R�AUI�̍X�V
        scoreValue.ScoreUpdate();


        // ������擾����Notes�̃t�F�[�h�A�E�g
        viewNotesManager.NowNotesFadeOut(line);


        //�@poor�̃J�E���g�����ȏ�ɂȂ����烌�[���D�悳���
        if(_poorCount >= _lineStealTiming)
        {
            linesManager.LineIsStolen_1p();

            _poorCount = 0;
        }
    }





    /// <summary>
    /// �n���ꂽ���Ԃ����ƂɁA�Ńm�[�c�ɑ΂��ēK�؂Ȕ�����v�Z����
    /// </summary>
    /// <param name="time">���肷��m�[�c�̎���</param>
    /// <param name="line">���肷��m�[�c���������Ă��郌�[��</param>
    public void PoisonNotesJudgement(long time, int line)
    {

        // Briliant�̔��莞�� / �X�L���ɂ��{���ȉ��Ȃ�(poison�Ȃ��ߓ��������́Apoor)
        if (time <= briliantJudge / judgeLeverage)
        {
            //poor�G�t�F�N�g���ꎞ�i�[�I�u�W�F�N�g�ɐ���
            effect[line] = Instantiate(effectList[(int)JudgeType.Poor]);

            //���������I�u�W�F�N�g�̐e��ݒ�
            effect[line].transform.parent = effectParent.transform;

            // �G�t�F�N�g��������line�ɑΉ�����ꏊ�Ɉړ�
            effect[line].rectTransform.position = instancePos[line].position;


            // poor���肵���̂ŉ��Z
            _poorCount++;

            //�R���{���̃��Z�b�g
            ComboScript.ComboReset();
        }

        // Graet�̔��莞�� / �X�L���ɂ��{���ȉ��Ȃ�(poison�Ȃ��ߓ��������́AGood)
        else if (time <= greatJudge / judgeLeverage)
        {
            //Good�G�t�F�N�g���ꎞ�i�[�I�u�W�F�N�g�ɐ���
            effect[line] = Instantiate(effectList[(int)JudgeType.Good]);

            //���������I�u�W�F�N�g�̐e��ݒ�
            effect[line].transform.parent = effectParent.transform;

            // �G�t�F�N�g��������line�ɑΉ�����ꏊ�Ɉړ�
            effect[line].rectTransform.position = instancePos[line].position;


            //�X�R�A�����ɁAGood�̒l������
            scoreValue.scoreValue += _goodScore;

            //�X�L���̃`���[�W���̑���(Good)
            skillChargeText.AddSkillValue(addSkillValue[(int)JudgeType.Good]);


            //�R���{���̉��Z
            ComboScript.AddComboValue();
        }
        // Good�̔��莞�� / �X�L���ɂ��{���ȉ��Ȃ�(poison�Ȃ��ߓ��������́AGreat)
        else if (time <= goodJudge / judgeLeverage)
        {
            //Great�G�t�F�N�g���ꎞ�i�[�I�u�W�F�N�g�ɐ���
            effect[line] = Instantiate(effectList[(int)JudgeType.Great]);

            //���������I�u�W�F�N�g�̐e��ݒ�
            effect[line].transform.parent = effectParent.transform;

            // �G�t�F�N�g��������line�ɑΉ�����ꏊ�Ɉړ�
            effect[line].rectTransform.position = instancePos[line].position;


            //�X�R�A�����ɁAGraet�̒l������
            scoreValue.scoreValue += _greatScore;

            //�X�L���̃`���[�W���̑���(Great)
            skillChargeText.AddSkillValue(addSkillValue[(int)JudgeType.Great]);

            //�R���{���̉��Z
            ComboScript.AddComboValue();
        }

        //poor����(poison�Ȃ��ߓ��������́ABriliant)
        else
        {
            //Briliant�G�t�F�N�g���ꎞ�i�[�I�u�W�F�N�g�ɐ���
            effect[line] = Instantiate(effectList[(int)JudgeType.Briliant]);

            //���������I�u�W�F�N�g�̐e��ݒ�
            effect[line].transform.parent = effectParent.transform;

            // �G�t�F�N�g��������line�ɑΉ�����ꏊ�Ɉړ�
            effect[line].rectTransform.position = instancePos[line].position;


            //�X�R�A�����ɁABriliant�̒l������
            scoreValue.scoreValue += _briliantScore;

            //�X�L���̃`���[�W���̑���(Briliant)
            skillChargeText.AddSkillValue(addSkillValue[(int)JudgeType.Briliant]);


            //�R���{���̉��Z
            ComboScript.AddComboValue();
        }


        // �X�R�AUI�̍X�V
        scoreValue.ScoreUpdate();


        // ������擾����Notes�̃t�F�[�h�A�E�g
        viewNotesManager.NowNotesFadeOut(line);



        //�@poor�̃J�E���g�����ȏ�ɂȂ����烌�[���D�悳���
        if (_poorCount >= _lineStealTiming)
        {
            linesManager.LineIsStolen_1p();

            //�J�E���g�̏�����
            _poorCount = 0;
        }
    }
}