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
    /// GameManager���Q�Ƃ���p
    /// </summary>
    [SerializeField]
    GameObject gameManager;


    /// <summary>
    /// ���Ԗڂ̃m�[�c�Ɋ����邩�̒l�̔z��
    /// </summary>
    [SerializeField]
    public int[] lineNoteNum;



    void Update()
    {
        // �@����o�[�f�o�b�N�p
        //if(MusicData.Timer >= 5000)
        //{
        //    #if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPaused = true;
        //    #endif
        //}
        


        // �z��̑����𒴂��Ĕz��Q�Ƃ��Ȃ��悤�ɂ��鐧��
        if (NoteDataListCreater.listNumMax[0]  > lineNoteNum[0])
        {
            // Q�L�[���������Ƃ�
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // criwear�̎��� - ����o�[���B�\�莞�� < judgeTime�Ȃ���s
                if (NoteDataListCreater.noteList_0[lineNoteNum[0]].time - MusicData.Timer < judgeTime)
                {
                    // ����p�֐��ŁA���̃m�[�c�̔��������
                    gameManager.GetComponent<NotesJudge>().NotesJudgement(
                        // criwear�̎��� - ����o�[���B�\�莞�� ���Βl�����Ĉ����ɐݒ�
                        (long)Mathf.Abs(NoteDataListCreater.noteList_0[lineNoteNum[0]].time - MusicData.Timer), 0);
                    
                    // ������m�[�c�����ɂ��炷
                    lineNoteNum[0]++;
                }
            }
            // poor����̎�����
            // Q�L�[�������ĂȂ��Ƃ��A����o�[���B�\�莞�� - criwear�̎��� < poorTiming�Ȃ���s
            else if (NoteDataListCreater.noteList_0[lineNoteNum[0]].time - MusicData.Timer < (long) ConstRepo.poorTiming)
            {
                // ����p�֐��ŁA���̃m�[�c�̔��������
                gameManager.GetComponent<NotesJudge>().NotesJudgement(
                    // criwear�̎��� - ����o�[���B�\�莞�� ���Βl�����Ĉ����ɐݒ�
                    (long)Mathf.Abs(NoteDataListCreater.noteList_0[lineNoteNum[0]].time - MusicData.Timer), 0);

                // ������m�[�c�����ɂ��炷
                lineNoteNum[0]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NoteDataListCreater.listNumMax[1] > lineNoteNum[1])
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (NoteDataListCreater.noteList_1[lineNoteNum[1]].time - MusicData.Timer < judgeTime)
                {
                    gameManager.GetComponent<NotesJudge>().NotesJudgement(
                        (long)(Mathf.Abs(NoteDataListCreater.noteList_1[lineNoteNum[1]].time) - MusicData.Timer), 1);
                    lineNoteNum[1]++;
                }
            }
            else if (NoteDataListCreater.noteList_1[lineNoteNum[1]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                gameManager.GetComponent<NotesJudge>().NotesJudgement(
                    (long)Mathf.Abs(NoteDataListCreater.noteList_1[lineNoteNum[1]].time - MusicData.Timer), 1);
                lineNoteNum[1]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NoteDataListCreater.listNumMax[2] > lineNoteNum[2])
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (NoteDataListCreater.noteList_2[lineNoteNum[2]].time - MusicData.Timer < judgeTime)
                {
                    gameManager.GetComponent<NotesJudge>().NotesJudgement(
                        (long)(Mathf.Abs(NoteDataListCreater.noteList_2[lineNoteNum[2]].time) - MusicData.Timer), 2);
                    lineNoteNum[2]++;
                }
            }
            else if (NoteDataListCreater.noteList_2[lineNoteNum[2]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                gameManager.GetComponent<NotesJudge>().NotesJudgement(
                    (long)Mathf.Abs(NoteDataListCreater.noteList_2[lineNoteNum[2]].time - MusicData.Timer), 2);
                lineNoteNum[2]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NoteDataListCreater.listNumMax[3] > lineNoteNum[3])
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (NoteDataListCreater.noteList_3[lineNoteNum[3]].time - MusicData.Timer < judgeTime)
                {
                    gameManager.GetComponent<NotesJudge>().NotesJudgement(
                        (long)(Mathf.Abs(NoteDataListCreater.noteList_3[lineNoteNum[3]].time) - MusicData.Timer), 3);
                    lineNoteNum[3]++;
                }
            }
            else if (NoteDataListCreater.noteList_3[lineNoteNum[3]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                gameManager.GetComponent<NotesJudge>().NotesJudgement(
                    (long)Mathf.Abs(NoteDataListCreater.noteList_3[lineNoteNum[3]].time - MusicData.Timer), 3);
                lineNoteNum[3]++;
            }
        }

    }
}
