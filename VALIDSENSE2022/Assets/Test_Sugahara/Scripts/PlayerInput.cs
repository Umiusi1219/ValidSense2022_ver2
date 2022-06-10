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
    /// GameManagerを参照する用
    /// </summary>
    [SerializeField]
    GameObject gameManager;


    /// <summary>
    /// 何番目のノーツに干渉するかの値の配列
    /// </summary>
    [SerializeField]
    public int[] lineNoteNum;



    void Update()
    {
        // 　判定バーデバック用
        //if(MusicData.Timer >= 5000)
        //{
        //    #if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPaused = true;
        //    #endif
        //}
        


        // 配列の総数を超えて配列参照しないようにする制御
        if (NoteDataListCreater.listNumMax[0]  > lineNoteNum[0])
        {
            // Qキーを押したとき
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // criwearの時間 - 判定バー到達予定時間 < judgeTimeなら実行
                if (NoteDataListCreater.noteList_0[lineNoteNum[0]].time - MusicData.Timer < judgeTime)
                {
                    // 判定用関数で、今のノーツの判定をする
                    gameManager.GetComponent<NotesJudge>().NotesJudgement(
                        // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                        (long)Mathf.Abs(NoteDataListCreater.noteList_0[lineNoteNum[0]].time - MusicData.Timer), 0);
                    
                    // 干渉するノーツを次にずらす
                    lineNoteNum[0]++;
                }
            }
            // poor判定の自動化
            // Qキーを押してないとき、判定バー到達予定時間 - criwearの時間 < poorTimingなら実行
            else if (NoteDataListCreater.noteList_0[lineNoteNum[0]].time - MusicData.Timer < (long) ConstRepo.poorTiming)
            {
                // 判定用関数で、今のノーツの判定をする
                gameManager.GetComponent<NotesJudge>().NotesJudgement(
                    // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                    (long)Mathf.Abs(NoteDataListCreater.noteList_0[lineNoteNum[0]].time - MusicData.Timer), 0);

                // 干渉するノーツを次にずらす
                lineNoteNum[0]++;
            }
        }

        // 上のラインが違う番
        if (NoteDataListCreater.listNumMax[1] > lineNoteNum[1])
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (NoteDataListCreater.noteList_1[lineNoteNum[1]].time - MusicData.Timer < judgeTime)
                {
                    gameManager.GetComponent<NotesJudge>().NotesJudgement(
                        (long)(Mathf.Abs(NoteDataListCreater.noteList_1[lineNoteNum[1]].time) - MusicData.Timer), 1);
                    lineNoteNum[1]++;
                }
            }
            else if (NoteDataListCreater.noteList_1[lineNoteNum[1]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                gameManager.GetComponent<NotesJudge>().NotesJudgement(
                    (long)Mathf.Abs(NoteDataListCreater.noteList_1[lineNoteNum[1]].time - MusicData.Timer), 1);
                lineNoteNum[1]++;
            }
        }

        // 上のラインが違う番
        if (NoteDataListCreater.listNumMax[2] > lineNoteNum[2])
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (NoteDataListCreater.noteList_2[lineNoteNum[2]].time - MusicData.Timer < judgeTime)
                {
                    gameManager.GetComponent<NotesJudge>().NotesJudgement(
                        (long)(Mathf.Abs(NoteDataListCreater.noteList_2[lineNoteNum[2]].time) - MusicData.Timer), 2);
                    lineNoteNum[2]++;
                }
            }
            else if (NoteDataListCreater.noteList_2[lineNoteNum[2]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                gameManager.GetComponent<NotesJudge>().NotesJudgement(
                    (long)Mathf.Abs(NoteDataListCreater.noteList_2[lineNoteNum[2]].time - MusicData.Timer), 2);
                lineNoteNum[2]++;
            }
        }

        // 上のラインが違う番
        if (NoteDataListCreater.listNumMax[3] > lineNoteNum[3])
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (NoteDataListCreater.noteList_3[lineNoteNum[3]].time - MusicData.Timer < judgeTime)
                {
                    gameManager.GetComponent<NotesJudge>().NotesJudgement(
                        (long)(Mathf.Abs(NoteDataListCreater.noteList_3[lineNoteNum[3]].time) - MusicData.Timer), 3);
                    lineNoteNum[3]++;
                }
            }
            else if (NoteDataListCreater.noteList_3[lineNoteNum[3]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                gameManager.GetComponent<NotesJudge>().NotesJudgement(
                    (long)Mathf.Abs(NoteDataListCreater.noteList_3[lineNoteNum[3]].time - MusicData.Timer), 3);
                lineNoteNum[3]++;
            }
        }

    }
}
