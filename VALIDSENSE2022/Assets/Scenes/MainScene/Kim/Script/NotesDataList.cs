using System.Collections.Generic;
using UnityEngine;

public class NotesDataList : MonoBehaviour
{

    /// <summary>
    /// 読み込む用の譜面データ（JsonReader）
    /// </summary>
    [SerializeField]
    private JsonReader _jsonReader;


    /// <summary>
    /// 読み込む用の譜面データ（JsonReader）
    /// </summary>
    [SerializeField]
    private JsonReader _jsonReader_2p;


    /// <summary>
    /// 各レーンのノーツ総数
    /// </summary>
    public int[] listNumMax;

    /// <summary>
    /// ノーツデータのリストのリスト
    /// </summary>
    public List<NotesDataClass> notesLists;


    /// <summary>
    /// レーンごとに分かれていない1Pの譜面データ
    /// </summary>
    [SerializeField]
    public List<NotesDataClass> musicNotesDate;

    /// <summary>
    /// musicNoteDataの進行度記憶
    /// </summary>
    public int[] nowNoteDataNum;


    void Start()
    {

        // 1p 譜面データの読み込み
        foreach (JsonReader.NoteList item in _jsonReader._songList.difflist.natural.notelist)
        {
            addNotesData_1P(item.line, item);
        }

        // 2p 譜面データの読み込み
        foreach (JsonReader.NoteList item in _jsonReader_2p._songList_2P.difflist.natural.notelist)
        {
            addNotesData_2P( 7 - item.line, item); ;
        }
    }

    /// <summary>
    /// ノーツのデータを各レーンに振り分け ノーツのデータをListに追加（直列）
    /// </summary>
    /// <param name="Line"></param>
    void addNotesData_1P(int Line , JsonReader.NoteList item)
    {
        listNumMax[Line]++;
        notesLists[Line].notesList.Add(item);

        musicNotesDate[0].notesList.Add
            (notesLists[Line].notesList[notesLists[Line].notesList.Count - 1]);
    }

    /// <summary>
    /// ノーツのデータを各レーンに振り分け ノーツのデータをListに追加（直列）
    /// </summary>
    /// <param name="Line"></param>
    void addNotesData_2P(int Line, JsonReader.NoteList item)
    {
        listNumMax[Line]++;
        notesLists[Line].notesList.Add(item);

        musicNotesDate[1].notesList.Add
            (notesLists[Line].notesList[notesLists[Line].notesList.Count - 1]);
    }
}
