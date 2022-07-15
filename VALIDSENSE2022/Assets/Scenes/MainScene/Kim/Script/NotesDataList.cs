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
    /// musicNoteDataの進行度記憶
    /// </summary>
    public int nowNoteDataNum;

    /// <summary>
    /// 各レーンのノーツ総数
    /// </summary>
    public int[] listNumMax = {0,0,0,0};
    
    /// <summary>
    /// レーン＿０のノーツデータリスト
    /// </summary>
    public  List<JsonReader.NoteList> notesList_0 = new List<JsonReader.NoteList>();
    /// <summary>
    /// レーン＿1のノーツデータリスト
    /// </summary>
    public List<JsonReader.NoteList> notesList_1 = new List<JsonReader.NoteList>();
    /// <summary>
    /// レーン＿2のノーツデータリスト
    /// </summary>
    public List<JsonReader.NoteList> notesList_2 = new List<JsonReader.NoteList>();
    /// <summary>
    /// レーン＿３のノーツデータリスト
    /// </summary>
    public List<JsonReader.NoteList> notesList_3 = new List<JsonReader.NoteList>();

    /// <summary>
    /// レーンごとに分かれていない譜面データ
    /// </summary>
    [SerializeField]
    public List<JsonReader.NoteList> musicNotesDate;





    //public List<JsonReader.NoteList> testnotesList_0;

    //public  List<JsonReader.NoteList> testnotesList_1;

    //public  List<JsonReader.NoteList> testnotesList_2;

    //public  List<JsonReader.NoteList> testnotesList_3;


    void Start()
    {

        // 譜面データの読み込み
        foreach (JsonReader.NoteList item in _jsonReader._songList.difflist.natural.notelist)
        {
            //ノーツのデータを各レーンに振り分け 
            //ノーツのデータをListに追加（直列）
            switch (item.line)
            {
                case 0:
                    listNumMax[0]++;
                    notesList_0.Add(item);

                    musicNotesDate.Add(notesList_0[notesList_0.Count -1 ]);
                    break;

                case 1:
                    listNumMax[1]++;
                    notesList_1.Add(item);

                    musicNotesDate.Add(notesList_1[notesList_1.Count - 1]);
                    break;

                case 2:
                    listNumMax[2]++;
                    notesList_2.Add(item);

                    musicNotesDate.Add(notesList_2[notesList_2.Count - 1]);
                    break;

                case 3:
                    listNumMax[3]++;
                    notesList_3.Add(item);

                    musicNotesDate.Add(notesList_3[notesList_3.Count - 1]);
                    break;

                default:
                    Debug.LogError("配列外参照");
                    break;
            }
            
        }

        //Test
        //// 作られたノーツのListの読み込み
        //foreach (JsonReader.NoteList item in _jsonReader._songList.difflist.natural.notelist)
        //{
        //    //ノーツのデータを各レーンに振り分け
        //    switch (item.line)
        //    {
        //        case 0:
        //            listNumMax[0]++;
        //            testnotesList_0.Add(item);

        //            musicNotesDate.Add(testnotesList_0[testnotesList_0.Count - 1]);
        //            break;

        //        case 1:
        //            listNumMax[1]++;
        //            testnotesList_1.Add(item);

        //            musicNotesDate.Add(testnotesList_1[testnotesList_1.Count - 1]);
        //            break;

        //        case 2:
        //            listNumMax[2]++;
        //            testnotesList_2.Add(item);

        //            musicNotesDate.Add(testnotesList_2[testnotesList_2.Count - 1]);
        //            break;

        //        case 3:
        //            listNumMax[3]++;
        //            testnotesList_3.Add(item);

        //            musicNotesDate.Add(testnotesList_3[testnotesList_3.Count - 1]);
        //            break;

        //        default:
        //            Debug.LogError("配列外参照");
        //            break;
        //    }

        //}


    }
}
