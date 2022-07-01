using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    /// <summary>
    /// 判定バー到達のどれくらい前から判定可するかの値
    /// </summary>
    [SerializeField]
    private double judgeTime;


    /// <summary>
    /// ノーツのデータスクリプトを参照する用
    /// </summary>
    [SerializeField]
    NotesDataList notesDataList;


    /// <summary>
    /// ノーツの判定用スクリプトを参照する用
    /// </summary>
    [SerializeField]
    NotesJudge notesJudge;


    /// <summary>
    /// 何番目のノーツに干渉するかの値の配列
    /// </summary>
    [SerializeField]
    public int[] lineNotesNum;



    void Update()
    {
        //判定バーデバック用
        //if (MusicData.Timer >= NotesDataList.notesList_0[lineNotesNum[0]].time)
        //{
        //    Debug.Log("Timer" + MusicData.Timer);
        //    Debug.Log("Judge" + NotesDataList.notesList_0[lineNotesNum[0]].time);
        //
        //#if UNITY_EDITOR
        //    UnityEditor.EditorApplication.isPaused = true;
        //#endif
        //}



        // 配列の総数を超えて配列参照しないようにする制御
        if (NotesDataList.listNumMax[0] > lineNotesNum[0])
        {
            // Qキーを押したとき
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // criwearの時間 - 判定バー到達予定時間 < judgeTimeなら実行
                if (NotesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer < judgeTime)
                {
                    // 判定用関数で、今のノーツの判定をする
                    notesJudge.NotesJudgement(
                        // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                        (long)Mathf.Abs(NotesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer), 0);

                    // 干渉するノーツを次にずらす
                    lineNotesNum[0]++;
                }
            }
            // poor判定の自動化
            // Qキーを押してないとき、判定バー到達予定時間 - criwearの時間 < poorTimingなら実行
            else if (NotesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                // 判定用関数で、今のノーツの判定をする
                notesJudge.NotesJudgement(
                    // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                    (long)Mathf.Abs(NotesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer), 0);

                // 干渉するノーツを次にずらす
                lineNotesNum[0]++;
            }
        }

        // 上のラインが違う番
        if (NotesDataList.listNumMax[1] > lineNotesNum[1])
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (NotesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer < judgeTime)
                {
                    notesJudge.NotesJudgement(
                        (long)(Mathf.Abs(NotesDataList.notesList_1[lineNotesNum[1]].time) - MusicData.Timer), 1);
                    lineNotesNum[1]++;
                }
            }
            else if (NotesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                notesJudge.NotesJudgement(
                    (long)Mathf.Abs(NotesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer), 1);
                lineNotesNum[1]++;
            }
        }

        // 上のラインが違う番
        if (NotesDataList.listNumMax[2] > lineNotesNum[2])
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (NotesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer < judgeTime)
                {
                    notesJudge.NotesJudgement(
                        (long)(Mathf.Abs(NotesDataList.notesList_2[lineNotesNum[2]].time) - MusicData.Timer), 2);
                    lineNotesNum[2]++;
                }
            }
            else if (NotesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                notesJudge.NotesJudgement(
                    (long)Mathf.Abs(NotesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer), 2);
                lineNotesNum[2]++;
            }
        }

        // 上のラインが違う番
        if (NotesDataList.listNumMax[3] > lineNotesNum[3])
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (NotesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer < judgeTime)
                {
                    notesJudge.NotesJudgement(
                        (long)(Mathf.Abs(NotesDataList.notesList_3[lineNotesNum[3]].time) - MusicData.Timer), 3);
                    lineNotesNum[3]++;
                }
            }
            else if (NotesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                notesJudge.NotesJudgement(
                    (long)Mathf.Abs(NotesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer), 3);
                lineNotesNum[3]++;
            }
        }

    }
}
