using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewNotesCreator : MonoBehaviour
{
    /// <summary>
    /// View�m�[�c���Ǘ�����}�l�[�W���[
    [SerializeField]
    ViewNotesManager viewNotesManager;


    /// <summary>
    /// �\���p�m�[�c�𐶐�����ׂɁA�f�ނ��i�[���Ă���List
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotes;



    /// <summary>
    /// View�m�[�c���ǂ̍������琶�����邩�́A��Ƃ��Ďg�����l
    /// </summary>
    [SerializeField]
    private float instantiatePosY;


    /// <summary>
    /// View�m�[�c���e���C���ɐ������鎞�p�̔z��
    /// </summary>
    [SerializeField]
    private float[] instantiatePosX;


    /// <summary>
    /// View�m�[�c���ǂ̉��s�Ő������鎞�p�̐��l
    /// </summary>
    [SerializeField]
    private float instantiatePosZ;


    /// <summary>
    /// View�m�[�c���A����o�[���B���鎞�Ԃ��Am/s�b�����������邩�̒l
    /// </summary>
    [SerializeField, Range(0, 9000)]
    long viewNotesTime = 4500;



    private void FixedUpdate()
    {
        // �z��̑����𒴂��Ĕz��Q�Ƃ��Ȃ��悤�ɂ��鐧��
        if (NotesDataList.listNumMax[0] > viewNotesManager.viewNotesLineNum[0])
        {
            // ���C��0��viewNotesLineNum[0]�Ԃ̃f�[�^���Q��
            // criwear�̎��Ԃ���Ƃ��Ĕ���o�[���B�\�莞�� - viewNotesTime�̎��ԂɎ��s
            if ((NotesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].time - viewNotesTime) <= MusicData.Timer)
            {

                // ���C��0��View�m�[�c���Ǘ�����List�ɁA�ǉ�����
                viewNotesManager.viewNotesListLine_0.Add(
                    // ViewNotes���Atype�őI�сA������
                    Instantiate(viewNotes[NotesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].type],
                    // ���C��0�p��x��Pos
                    new Vector3(instantiatePosX[NotesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].line],
                    //��{�̒l * speed * ���̔{���ŁA������ݒ�
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    // ��]�́A���ɂȂ�
                    new Quaternion(0, 0, 0, 0)) as GameObject);


                // ��������ViewNotes�̗����speed��ݒ�
                viewNotesManager.viewNotesListLine_0[viewNotesManager.viewNotesLineNum[0]].GetComponent<ViewNotesScript>().
                    // �����i��{�̒l * speed * ���̔{���j
                    NotesSpeedSetter((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage)
                    // ���ԁim/s ���@m/s^2 �ɕϊ��j60fps�p�ɐݒ�
                    / (viewNotesTime / 1000f) / 60);

                // ������m�[�c�����ɂ���
                viewNotesManager.viewNotesLineNum[0]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NotesDataList.listNumMax[1] > viewNotesManager.viewNotesLineNum[1])
        {
            if ((NotesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].time - viewNotesTime) <= MusicData.Timer)
            {

                viewNotesManager.viewNotesListLine_1.Add(
                    Instantiate(viewNotes[NotesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].type],
                    new Vector3(instantiatePosX[NotesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].line],
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);
                viewNotesManager.viewNotesListLine_1[viewNotesManager.viewNotesLineNum[1]].GetComponent<ViewNotesScript>().NotesSpeedSetter
                    ((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage) / (viewNotesTime / 1000f) / 60);


                viewNotesManager.viewNotesLineNum[1]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NotesDataList.listNumMax[2] > viewNotesManager.viewNotesLineNum[2])
        {
            if ((NotesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].time - viewNotesTime) <= MusicData.Timer)
            {

                viewNotesManager.viewNotesListLine_2.Add(
                    Instantiate(viewNotes[NotesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].type],
                    new Vector3(instantiatePosX[NotesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].line],
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                viewNotesManager.viewNotesListLine_2[viewNotesManager.viewNotesLineNum[2]].GetComponent<ViewNotesScript>().NotesSpeedSetter
                    ((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage) / (viewNotesTime / 1000f) / 60);


                viewNotesManager.viewNotesLineNum[2]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NotesDataList.listNumMax[3] > viewNotesManager.viewNotesLineNum[3])
        {
            if ((NotesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].time - viewNotesTime) <= MusicData.Timer)
            {

                viewNotesManager.viewNotesListLine_3.Add(
                    Instantiate(viewNotes[NotesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].type],
                    new Vector3(instantiatePosX[NotesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].line],
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                viewNotesManager.viewNotesListLine_3[viewNotesManager.viewNotesLineNum[3]].GetComponent<ViewNotesScript>().NotesSpeedSetter
                    ((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage) / (viewNotesTime / 1000f) / 60);


                viewNotesManager.viewNotesLineNum[3]++;
            }
        }

    }
}