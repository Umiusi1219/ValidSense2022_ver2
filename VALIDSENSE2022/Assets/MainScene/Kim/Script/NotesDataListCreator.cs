using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesDataListCreator : MonoBehaviour
{

    /// <summary>
    /// 読み込む用の譜面データ（JsonReader）
    /// </summary>
    [SerializeField]
    private JsonReader _jsonReader;

    /// <summary>
    /// 各レーンのノーツ総数
    /// </summary>
    public static int[] listNumMax = {0,0,0,0};
    
    /// <summary>
    /// レーン＿０のノーツデータリスト
    /// </summary>
    public static List<JsonReader.NoteList> noteList_0 = new List<JsonReader.NoteList>();
    /// <summary>
    /// レーン＿1のノーツデータリスト
    /// </summary>
    public static List<JsonReader.NoteList> noteList_1 = new List<JsonReader.NoteList>();
    /// <summary>
    /// レーン＿2のノーツデータリスト
    /// </summary>
    public static List<JsonReader.NoteList> noteList_2 = new List<JsonReader.NoteList>();
    /// <summary>
    /// レーン＿３のノーツデータリスト
    /// </summary>
    public static List<JsonReader.NoteList> noteList_3 = new List<JsonReader.NoteList>();
    
    void Start()
    {

        // Easyの譜面データの読み込み
       foreach(JsonReader.NoteList item in _jsonReader._songList.difflist.easy.notelist)
        {
            //ノーツのデータを各レーンに振り分け
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
                    Debug.LogError("配列外参照");
                    break;
            }

        }
    }
}
