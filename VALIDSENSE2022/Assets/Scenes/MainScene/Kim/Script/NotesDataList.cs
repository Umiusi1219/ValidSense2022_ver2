using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesDataList : MonoBehaviour
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
    public static List<JsonReader.NoteList> notesList_0 = new List<JsonReader.NoteList>();
    /// <summary>
    /// レーン＿1のノーツデータリスト
    /// </summary>
    public static List<JsonReader.NoteList> notesList_1 = new List<JsonReader.NoteList>();
    /// <summary>
    /// レーン＿2のノーツデータリスト
    /// </summary>
    public static List<JsonReader.NoteList> notesList_2 = new List<JsonReader.NoteList>();
    /// <summary>
    /// レーン＿３のノーツデータリスト
    /// </summary>
    public static List<JsonReader.NoteList> notesList_3 = new List<JsonReader.NoteList>();
    
    void Start()
    {

        // Easyの譜面データの読み込み
       foreach(JsonReader.NoteList item in _jsonReader._songList.difflist.natural.notelist)
        {
            //ノーツのデータを各レーンに振り分け
            switch(item.line)
            {
                case 0:
                    listNumMax[0]++;
                    notesList_0.Add(item);
                    break;

                case 1:
                    listNumMax[1]++;
                    notesList_1.Add(item);
                    break;

                case 2:
                    listNumMax[2]++;
                    notesList_2.Add(item);
                    break;

                case 3:
                    listNumMax[3]++;
                    notesList_3.Add(item);
                    break;

                default:
                    Debug.LogError("配列外参照");
                    break;
            }

        }
    }
}
