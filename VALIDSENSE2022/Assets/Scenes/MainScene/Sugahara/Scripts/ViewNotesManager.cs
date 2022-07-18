using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewNotesManager : MonoBehaviour
{
    /// <summary>
    /// キャラをいじってる子に参照用
    /// </summary>
    [SerializeField]
    TestChara testChara;

    /// <summary>
    /// Lineの色変更時使用するカラーコードの、配列
    /// </summary>
    public string[] charaNotesColorCode;

    /// <summary>
    ///string型のカラーコードをColor変換した時の受け取り先
    /// </summary>
    Color colorCode;

    /// <summary>
    /// 表示用ノーツ格納lineごとに格納し、生成したViewノーツを管理する用
    /// </summary>
    [SerializeField]
    public List<ViewNotesListClass> viewNotesLists;


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
    public float[] viewNotesSpeed;


    /// <summary>
    /// スキルによるViewノーツSpeedの変化用の値(倍率)
    /// </summary>
    [Range(0.5f, 2.5f)]
    public float[] NotesSpeedLeverage;


    /// <summary>
    /// // 引数番のラインの、viewNotesDereatNum_Line番のViewNotesのフェードアウト
    /// </summary>
    /// <param name="line"> 干渉するラインの指定 </param>
    public void NowNotesFadeOut(int line)
    {
        //viewNotesDereatNum_Line番のViewNotesのフェードアウト
        viewNotesLists[line].viewNotesList[viewNotesDereatNum_Line[line]]
            .GetComponent<ViewNotesScript>().NotesFadeOut();

        // viewNotesDereatNum_Line[0]++;
        viewNotesDereatNum_Line[line]++;
    }


    /// <summary>
    /// 引数のラインの流れているノーツの色引数のキャラの色にすべて変える
    /// </summary>
    /// <param name="line">ノーツの色を変えるライン</param>
    /// <param name="playerNum">どっちのプレイヤーか判定用</param>
    public void ActiveViewNotesColourChange(int line ,int playerNum)
    {
        for (int i = 0; i < viewNotesLists[line].viewNotesList.Count - viewNotesDereatNum_Line[line];)
        {
            if (playerNum == 0)
            {
                if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count[0]],
                    out colorCode))
                {
                    viewNotesLists[line].viewNotesList[viewNotesDereatNum_Line[line] + i].
                   GetComponent<SpriteRenderer>().color = colorCode;
                }
            }
            else
            {
                if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count[1]],
                    out colorCode))
                {
                    viewNotesLists[line].viewNotesList[viewNotesDereatNum_Line[line] + i].
                   GetComponent<SpriteRenderer>().color = colorCode;
                }
            }


            // 次にする
            i++;
        }
    }
}
