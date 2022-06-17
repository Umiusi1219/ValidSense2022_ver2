using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesDataListCreator : MonoBehaviour
{

    /// <summary>
    /// �ǂݍ��ޗp�̕��ʃf�[�^�iJsonReader�j
    /// </summary>
    [SerializeField]
    private JsonReader _jsonReader;

    /// <summary>
    /// �e���[���̃m�[�c����
    /// </summary>
    public static int[] listNumMax = {0,0,0,0};
    
    /// <summary>
    /// ���[���Q�O�̃m�[�c�f�[�^���X�g
    /// </summary>
    public static List<JsonReader.NoteList> noteList_0 = new List<JsonReader.NoteList>();
    /// <summary>
    /// ���[���Q1�̃m�[�c�f�[�^���X�g
    /// </summary>
    public static List<JsonReader.NoteList> noteList_1 = new List<JsonReader.NoteList>();
    /// <summary>
    /// ���[���Q2�̃m�[�c�f�[�^���X�g
    /// </summary>
    public static List<JsonReader.NoteList> noteList_2 = new List<JsonReader.NoteList>();
    /// <summary>
    /// ���[���Q�R�̃m�[�c�f�[�^���X�g
    /// </summary>
    public static List<JsonReader.NoteList> noteList_3 = new List<JsonReader.NoteList>();
    
    void Start()
    {

        // Easy�̕��ʃf�[�^�̓ǂݍ���
       foreach(JsonReader.NoteList item in _jsonReader._songList.difflist.easy.notelist)
        {
            //�m�[�c�̃f�[�^���e���[���ɐU�蕪��
            switch(item.line)
            {
                case 0:
                    listNumMax[0]++;
                    noteList_0.Add(item);
                    break;

                case 1:
                    listNumMax[1]++;
                    noteList_1.Add(item);
                    break;

                case 2:
                    listNumMax[2]++;
                    noteList_2.Add(item);
                    break;

                case 3:
                    listNumMax[3]++;
                    noteList_3.Add(item);
                    break;

                default:
                    Debug.LogError("�z��O�Q��");
                    break;
            }

        }
    }
}
