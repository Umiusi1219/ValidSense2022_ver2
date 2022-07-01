using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewNotesManager : MonoBehaviour
{
    /// <summary>
    /// 表示用ノーツ格納lineごとに格納し、生成したViewノーツを管理する用
    /// 0番ライン
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotesListLine_0;

    /// <summary>
    /// 表示用ノーツ格納lineごとに格納し、生成したViewノーツを管理する用
    /// 1番ライン
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotesListLine_1;


    /// <summary>
    /// 表示用ノーツ格納lineごとに格納し、生成したViewノーツを管理する用
    /// 2番ライン
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotesListLine_2;


    /// <summary>
    /// 表示用ノーツ格納lineごとに格納し、生成したViewノーツを管理する用
    /// 3番ライン
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotesListLine_3;


    /// <summary>
    /// 各ラインが何番目のViewノーツに干渉するか、管理用
    /// </summary>
    [SerializeField]
    public int[] viewNotesLineNum;


    /// <summary>
    /// 各ラインが何番目のViewノーツを消すか、管理用
    /// </summary>
    [SerializeField]
    public int[] viewNotesDereatNum_Line;


    /// <summary>
    /// Viewノーツをどれくらいの速さで流すかの基準になる、値
    /// 主に難易度に対応
    /// </summary>
    public float viewNotesSpeed;


    /// <summary>
    /// スキルによるViewノーツSpeedの変化用の値(倍率)
    /// </summary>
    [Range(0.5f, 2.5f)]
    public float NotesSpeedLeverage;


    /// <summary>
    /// // 引数番のラインの、viewNotesDereatNum_Line番のViewNotesのフェードアウト
    /// </summary>
    /// <param name="line"> 干渉するラインの指定 </param>
    public void NowNotesFadeOut(int line)
    {
        // ラインのスイッチ
        switch (line)
        {
            case 0:
                // ライン0の、viewNotesDereatNum_Line番のViewNotesのフェードアウト
                viewNotesListLine_0[viewNotesDereatNum_Line[0]].GetComponent<ViewNotesScript>().NotesFadeOut();
                // ライン0の、ViewNotesDereatNumを次にずらす
                viewNotesDereatNum_Line[0]++;
                break;

            //上のライン違い
            case 1:
                viewNotesListLine_1[viewNotesDereatNum_Line[1]].GetComponent<ViewNotesScript>().NotesFadeOut();
                viewNotesDereatNum_Line[1]++;
                break;

            //上のライン違い
            case 2:
                viewNotesListLine_2[viewNotesDereatNum_Line[2]].GetComponent<ViewNotesScript>().NotesFadeOut();
                viewNotesDereatNum_Line[2]++;
                break;

            //上のライン違い
            case 3:
                viewNotesListLine_3[viewNotesDereatNum_Line[3]].GetComponent<ViewNotesScript>().NotesFadeOut();
                viewNotesDereatNum_Line[3]++;
                break;
        }
    }
}
