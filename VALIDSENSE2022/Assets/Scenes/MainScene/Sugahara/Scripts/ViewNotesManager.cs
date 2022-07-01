using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewNotesManager : MonoBehaviour
{
    /// <summary>
    /// �\���p�m�[�c�i�[line���ƂɊi�[���A��������View�m�[�c���Ǘ�����p
    /// 0�ԃ��C��
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotesListLine_0;

    /// <summary>
    /// �\���p�m�[�c�i�[line���ƂɊi�[���A��������View�m�[�c���Ǘ�����p
    /// 1�ԃ��C��
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotesListLine_1;


    /// <summary>
    /// �\���p�m�[�c�i�[line���ƂɊi�[���A��������View�m�[�c���Ǘ�����p
    /// 2�ԃ��C��
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotesListLine_2;


    /// <summary>
    /// �\���p�m�[�c�i�[line���ƂɊi�[���A��������View�m�[�c���Ǘ�����p
    /// 3�ԃ��C��
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotesListLine_3;


    /// <summary>
    /// �e���C�������Ԗڂ�View�m�[�c�Ɋ����邩�A�Ǘ��p
    /// </summary>
    [SerializeField]
    public int[] viewNotesLineNum;


    /// <summary>
    /// �e���C�������Ԗڂ�View�m�[�c���������A�Ǘ��p
    /// </summary>
    [SerializeField]
    public int[] viewNotesDereatNum_Line;


    /// <summary>
    /// View�m�[�c���ǂꂭ�炢�̑����ŗ������̊�ɂȂ�A�l
    /// ��ɓ�Փx�ɑΉ�
    /// </summary>
    public float viewNotesSpeed;


    /// <summary>
    /// �X�L���ɂ��View�m�[�cSpeed�̕ω��p�̒l(�{��)
    /// </summary>
    [Range(0.5f, 2.5f)]
    public float NotesSpeedLeverage;


    /// <summary>
    /// // �����Ԃ̃��C���́AviewNotesDereatNum_Line�Ԃ�ViewNotes�̃t�F�[�h�A�E�g
    /// </summary>
    /// <param name="line"> �����郉�C���̎w�� </param>
    public void NowNotesFadeOut(int line)
    {
        // ���C���̃X�C�b�`
        switch (line)
        {
            case 0:
                // ���C��0�́AviewNotesDereatNum_Line�Ԃ�ViewNotes�̃t�F�[�h�A�E�g
                viewNotesListLine_0[viewNotesDereatNum_Line[0]].GetComponent<ViewNotesScript>().NotesFadeOut();
                // ���C��0�́AViewNotesDereatNum�����ɂ��炷
                viewNotesDereatNum_Line[0]++;
                break;

            //��̃��C���Ⴂ
            case 1:
                viewNotesListLine_1[viewNotesDereatNum_Line[1]].GetComponent<ViewNotesScript>().NotesFadeOut();
                viewNotesDereatNum_Line[1]++;
                break;

            //��̃��C���Ⴂ
            case 2:
                viewNotesListLine_2[viewNotesDereatNum_Line[2]].GetComponent<ViewNotesScript>().NotesFadeOut();
                viewNotesDereatNum_Line[2]++;
                break;

            //��̃��C���Ⴂ
            case 3:
                viewNotesListLine_3[viewNotesDereatNum_Line[3]].GetComponent<ViewNotesScript>().NotesFadeOut();
                viewNotesDereatNum_Line[3]++;
                break;
        }
    }
}
