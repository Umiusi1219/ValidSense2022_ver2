using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    /// <summary>
    /// ����o�[���B�̂ǂꂭ�炢�O���画����邩�̒l
    /// </summary>
    [SerializeField]
    private double judgeTime;


    /// <summary>
    /// �m�[�c�̃f�[�^�X�N���v�g���Q�Ƃ���p
    /// </summary>
    [SerializeField]
    NotesDataList notesDataList;


    /// <summary>
    /// �m�[�c�̔���p�X�N���v�g���Q�Ƃ���p
    /// </summary>
    [SerializeField]
    NotesJudge notesJudge;


    /// <summary>
    /// ���Ԗڂ̃m�[�c�Ɋ����邩�̒l�̔z��
    /// </summary>
    [SerializeField]
    public int[] lineNotesNum;



    void Update()
    {
        //����o�[�f�o�b�N�p
        //if (MusicData.Timer >= NotesDataList.notesList_0[lineNotesNum[0]].time)
        //{
        //    Debug.Log("Timer" + MusicData.Timer);
        //    Debug.Log("Judge" + NotesDataList.notesList_0[lineNotesNum[0]].time);
        //
        //#if UNITY_EDITOR
        //    UnityEditor.EditorApplication.isPaused = true;
        //#endif
        //}



        // �z��̑����𒴂��Ĕz��Q�Ƃ��Ȃ��悤�ɂ��鐧��
        if (NotesDataList.listNumMax[0] > lineNotesNum[0])
        {
            // Q�L�[���������Ƃ�
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // criwear�̎��� - ����o�[���B�\�莞�� < judgeTime�Ȃ���s
                if (NotesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer < judgeTime)
                {
                    // ����p�֐��ŁA���̃m�[�c�̔��������
                    notesJudge.NotesJudgement(
                        // criwear�̎��� - ����o�[���B�\�莞�� ���Βl�����Ĉ����ɐݒ�
                        (long)Mathf.Abs(NotesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer), 0);

                    // ������m�[�c�����ɂ��炷
                    lineNotesNum[0]++;
                }
            }
            // poor����̎�����
            // Q�L�[�������ĂȂ��Ƃ��A����o�[���B�\�莞�� - criwear�̎��� < poorTiming�Ȃ���s
            else if (NotesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                // ����p�֐��ŁA���̃m�[�c�̔��������
                notesJudge.NotesJudgement(
                    // criwear�̎��� - ����o�[���B�\�莞�� ���Βl�����Ĉ����ɐݒ�
                    (long)Mathf.Abs(NotesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer), 0);

                // ������m�[�c�����ɂ��炷
                lineNotesNum[0]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NotesDataList.listNumMax[1] > lineNotesNum[1])
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (NotesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer < judgeTime)
                {
                    notesJudge.NotesJudgement(
                        (long)(Mathf.Abs(NotesDataList.notesList_1[lineNotesNum[1]].time) - MusicData.Timer), 1);
                    lineNotesNum[1]++;
                }
            }
            else if (NotesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                notesJudge.NotesJudgement(
                    (long)Mathf.Abs(NotesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer), 1);
                lineNotesNum[1]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NotesDataList.listNumMax[2] > lineNotesNum[2])
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (NotesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer < judgeTime)
                {
                    notesJudge.NotesJudgement(
                        (long)(Mathf.Abs(NotesDataList.notesList_2[lineNotesNum[2]].time) - MusicData.Timer), 2);
                    lineNotesNum[2]++;
                }
            }
            else if (NotesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                notesJudge.NotesJudgement(
                    (long)Mathf.Abs(NotesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer), 2);
                lineNotesNum[2]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NotesDataList.listNumMax[3] > lineNotesNum[3])
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (NotesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer < judgeTime)
                {
                    notesJudge.NotesJudgement(
                        (long)(Mathf.Abs(NotesDataList.notesList_3[lineNotesNum[3]].time) - MusicData.Timer), 3);
                    lineNotesNum[3]++;
                }
            }
            else if (NotesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                notesJudge.NotesJudgement(
                    (long)Mathf.Abs(NotesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer), 3);
                lineNotesNum[3]++;
            }
        }

    }
}
