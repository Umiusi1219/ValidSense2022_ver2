using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewNoteCreater : MonoBehaviour
{
    /// <summary>
    /// �\���p�m�[�c�𐶐�����ׂɁA�f�ނ��i�[���Ă���List
    /// </summary>
    [SerializeField] 
    List<GameObject> viewNotes;

    /// <summary>
    /// �\���p�m�[�c�i�[line���ƂɊi�[���A��������View�m�[�c���Ǘ�����p
    /// 0�ԃ��C��
    /// </summary>
    [SerializeField] 
    List<GameObject> line0ViewNoteList;

    /// <summary>
    /// �\���p�m�[�c�i�[line���ƂɊi�[���A��������View�m�[�c���Ǘ�����p
    /// 1�ԃ��C��
    /// </summary>
    [SerializeField] 
    List<GameObject> line1ViewNoteList;


    /// <summary>
    /// �\���p�m�[�c�i�[line���ƂɊi�[���A��������View�m�[�c���Ǘ�����p
    /// 2�ԃ��C��
    /// </summary>
    [SerializeField] 
    List<GameObject> line2ViewNoteList;


    /// <summary>
    /// �\���p�m�[�c�i�[line���ƂɊi�[���A��������View�m�[�c���Ǘ�����p
    /// 3�ԃ��C��
    /// </summary>
    [SerializeField] 
    List<GameObject> line3ViewNoteList;


    /// <summary>
    /// �e���C�������Ԗڂ�View�m�[�c�Ɋ����邩�A�Ǘ��p
    /// </summary>
    [SerializeField] 
    public int[] lineViewNoteNum ;


    /// <summary>
    /// �e���C�������Ԗڂ�View�m�[�c���������A�Ǘ��p
    /// </summary>
    [SerializeField] 
    public int[] lineViewNoteDereatNum;


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
    [SerializeField,Range(0,9000)] 
    long viewNoteTime = 4500;


    /// <summary>
    /// View�m�[�c���ǂꂭ�炢�̑����ŗ������̊�ɂȂ�A�l
    /// ��ɓ�Փx�ɑΉ�
    /// </summary>
    [Range(0.5f,30.0f)]
    public float viewNoteSpeed;


    /// <summary>
    /// �X�L���ɂ��View�m�[�cSpeed�̕ω��p�̒l
    /// </summary>
    public float notesSpeedLeverage;


    private void FixedUpdate()
    {
        // �z��̑����𒴂��Ĕz��Q�Ƃ��Ȃ��悤�ɂ��鐧��
        if (NoteDataListCreater.listNumMax[0] > lineViewNoteNum[0])
        {
            // ���C��0��lineViewNoteNum[0]�Ԃ̃f�[�^���Q��
            // criwear�̎��Ԃ���Ƃ��Ĕ���o�[���B�\�莞�� - viewNoteTime�̎��ԂɎ��s
            if ((NoteDataListCreater.noteList_0[lineViewNoteNum[0]].time - viewNoteTime) <= MusicData.Timer)
            {
                /* �f�o�b�N�p
                Debug.Log("noteList_0[lineViewNoteNum[0]].time - viewNoteTime");
                Debug.Log(NoteDataListCreater.noteList_0[lineViewNoteNum[0]].time - viewNoteTime);
                Debug.Log("NoteCreateTime");
                Debug.Log(MusicData.Timer);
                Debug.Log("noteList_0[lineViewNoteNum[0]].time");
                Debug.Log(NoteDataListCreater.noteList_0[lineViewNoteNum[0]].time);
                Debug.Log("noteList_0[lineViewNoteNum[0]].type");
                Debug.Log(NoteDataListCreater.noteList_0[lineViewNoteNum[0]].type);
                 */

                
                // ���C��0��View�m�[�c���Ǘ�����List�ɁA�ǉ�����
                line0ViewNoteList.Add(
                    // ViewNotes���Atype�őI�сA������
                    Instantiate(viewNotes[NoteDataListCreater.noteList_0[lineViewNoteNum[0]].type],
                    // ���C��0�p��x��Pos
                    new Vector3(instantiatePosX[NoteDataListCreater. noteList_0[lineViewNoteNum[0]].line],
                    //��{�̒l * speed * ���̔{���ŁA������ݒ�
                    instantiatePosY * viewNoteSpeed * notesSpeedLeverage , instantiatePosZ),
                    // ��]�́A���ɂȂ�
                    new Quaternion(0, 0, 0, 0)) as GameObject);


                // ��������ViewNotes�̗����speed��ݒ�
                line0ViewNoteList[lineViewNoteNum[0]].GetComponent<NoteView>().
                    // �����i��{�̒l * speed * ���̔{���j
                    NoteSpeedSetter((instantiatePosY * viewNoteSpeed * notesSpeedLeverage)
                    // ���ԁim/s ���@m/s^2 �ɕϊ��j60fps�p�ɐݒ�
                    / (viewNoteTime / 1000f) / 60);

                // ������m�[�c�����ɂ���
                lineViewNoteNum[0]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NoteDataListCreater.listNumMax[1] > lineViewNoteNum[1])
        {
            if ((NoteDataListCreater.noteList_1[lineViewNoteNum[1]].time - viewNoteTime) <= MusicData.Timer)
            {
                /*
                Debug.Log("noteList_1[line1ViewNoteNum].time - viewNoteTime");
                Debug.Log(NoteDataListCreater.noteList_1[lineViewNoteNum[1]].time - viewNoteTime);
                Debug.Log("NoteCreateTime");
                Debug.Log(MusicData.Timer);
                Debug.Log("noteList_1[line1ViewNoteNum].time");
                Debug.Log(NoteDataListCreater.noteList_1[lineViewNoteNum[1]].time);

                Debug.Log("noteList_1[line1ViewNoteNum].type");
                Debug.Log(NoteDataListCreater.noteList_1[lineViewNoteNum[1]].type);
                */

                line1ViewNoteList.Add(
                    Instantiate(viewNotes[NoteDataListCreater.noteList_1[lineViewNoteNum[1]].type],
                    new Vector3(instantiatePosX[NoteDataListCreater.noteList_1[lineViewNoteNum[1]].line], 
                    instantiatePosY * viewNoteSpeed * notesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);
                line1ViewNoteList[lineViewNoteNum[1]].GetComponent<NoteView>().NoteSpeedSetter
                    ((instantiatePosY * viewNoteSpeed * notesSpeedLeverage) / (viewNoteTime / 1000f) / 60);


                lineViewNoteNum[1]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NoteDataListCreater.listNumMax[2] > lineViewNoteNum[2])
        {
            if ((NoteDataListCreater.noteList_2[lineViewNoteNum[2]].time - viewNoteTime) <= MusicData.Timer)
            {
                /*
                Debug.Log("noteList_1[line1ViewNoteNum].time - viewNoteTime");
                Debug.Log(NoteDataListCreater.noteList_2[lineViewNoteNum[2]].time - viewNoteTime);
                Debug.Log("NoteCreateTime");
                Debug.Log(MusicData.Timer);
                Debug.Log("noteList_1[line1ViewNoteNum].time");
                Debug.Log(NoteDataListCreater.noteList_2[lineViewNoteNum[2]].time);

                Debug.Log("noteList_1[line1ViewNoteNum].type");
                Debug.Log(NoteDataListCreater.noteList_2[lineViewNoteNum[2]].type);
                */

                
                line2ViewNoteList.Add(
                    Instantiate(viewNotes[NoteDataListCreater.noteList_2[lineViewNoteNum[2]].type],
                    new Vector3(instantiatePosX[NoteDataListCreater.noteList_2[lineViewNoteNum[2]].line], 
                    instantiatePosY * viewNoteSpeed * notesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                line2ViewNoteList[lineViewNoteNum[2]].GetComponent<NoteView>().NoteSpeedSetter
                    ((instantiatePosY * viewNoteSpeed * notesSpeedLeverage) / (viewNoteTime / 1000f) / 60);


                lineViewNoteNum[2]++;
            }
        }

        // ��̃��C�����Ⴄ��
        if (NoteDataListCreater.listNumMax[3] > lineViewNoteNum[3])
        {
            if ((NoteDataListCreater.noteList_3[lineViewNoteNum[3]].time - viewNoteTime) <= MusicData.Timer)
            {
                /*
                Debug.Log("noteList_1[line1ViewNoteNum].time - viewNoteTime");
                Debug.Log(NoteDataListCreater.noteList_3[lineViewNoteNum[3]].time - viewNoteTime);
                Debug.Log("NoteCreateTime");
                Debug.Log(MusicData.Timer);
                Debug.Log("noteList_1[line1ViewNoteNum].time");
                Debug.Log(NoteDataListCreater.noteList_3[lineViewNoteNum[3]].time);

                Debug.Log("noteList_1[line1ViewNoteNum].type");
                Debug.Log(NoteDataListCreater.noteList_3[lineViewNoteNum[3]].type);
                */

                
                line3ViewNoteList.Add(
                    Instantiate(viewNotes[NoteDataListCreater.noteList_3[lineViewNoteNum[3]].type],
                    new Vector3(instantiatePosX[NoteDataListCreater.noteList_3[lineViewNoteNum[3]].line], 
                    instantiatePosY * viewNoteSpeed * notesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                line3ViewNoteList[lineViewNoteNum[3]].GetComponent<NoteView>().NoteSpeedSetter
                    ((instantiatePosY * viewNoteSpeed * notesSpeedLeverage) / (viewNoteTime / 1000f) / 60);


                lineViewNoteNum[3]++;
            }
        }

    }


    /// <summary>
    /// // �����Ԃ̃��C���́AlineViewNoteDereatNum�Ԃ�ViewNotes�̃t�F�[�h�A�E�g
    /// </summary>
    /// <param name="line"> �����郉�C���̎w�� </param>
    public void NowNoteFadeOut(int line)
    {
        // ���C���̃X�C�b�`
        switch(line)
        {
            case 0:
                // ���C��0�́AlineViewNoteDereatNum�Ԃ�ViewNotes�̃t�F�[�h�A�E�g
                line0ViewNoteList[lineViewNoteDereatNum[0]].GetComponent<NoteView>().NoteFadeOut();
                // ���C��0�́AViewNoteDereatNum�����ɂ��炷
                lineViewNoteDereatNum[0]++;
                break;

            //��̃��C���Ⴂ
            case 1:
                line1ViewNoteList[lineViewNoteDereatNum[1]].GetComponent<NoteView>().NoteFadeOut();
                lineViewNoteDereatNum[1]++;
                break;

            //��̃��C���Ⴂ
            case 2:
                line2ViewNoteList[lineViewNoteDereatNum[2]].GetComponent<NoteView>().NoteFadeOut();
                lineViewNoteDereatNum[2]++;
                break;

            //��̃��C���Ⴂ
            case 3:
                line3ViewNoteList[lineViewNoteDereatNum[3]].GetComponent<NoteView>().NoteFadeOut();
                lineViewNoteDereatNum[3]++;
                break;
        }
    }
}
