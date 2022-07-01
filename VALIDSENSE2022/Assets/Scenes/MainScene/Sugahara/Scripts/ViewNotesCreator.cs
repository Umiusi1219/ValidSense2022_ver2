using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewNotesCreator : MonoBehaviour
{
    /// <summary>
    /// Viewノーツを管理するマネージャー
    [SerializeField]
    ViewNotesManager viewNotesManager;


    /// <summary>
    /// 表示用ノーツを生成する為に、素材を格納してあるList
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotes;



    /// <summary>
    /// Viewノーツをどの高さから生成するかの、基準として使う数値
    /// </summary>
    [SerializeField]
    private float instantiatePosY;


    /// <summary>
    /// Viewノーツを各ラインに生成する時用の配列
    /// </summary>
    [SerializeField]
    private float[] instantiatePosX;


    /// <summary>
    /// Viewノーツをどの奥行で生成する時用の数値
    /// </summary>
    [SerializeField]
    private float instantiatePosZ;


    /// <summary>
    /// Viewノーツを、判定バー到達する時間より、m/s秒早く生成するかの値
    /// </summary>
    [SerializeField, Range(0, 9000)]
    long viewNotesTime = 4500;



    private void FixedUpdate()
    {
        // 配列の総数を超えて配列参照しないようにする制御
        if (NotesDataList.listNumMax[0] > viewNotesManager.viewNotesLineNum[0])
        {
            // ライン0のviewNotesLineNum[0]番のデータを参照
            // criwearの時間を基準として判定バー到達予定時間 - viewNotesTimeの時間に実行
            if ((NotesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].time - viewNotesTime) <= MusicData.Timer)
            {

                // ライン0のViewノーツを管理するListに、追加する
                viewNotesManager.viewNotesListLine_0.Add(
                    // ViewNotesを、typeで選び、生成し
                    Instantiate(viewNotes[NotesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].type],
                    // ライン0用のx軸Pos
                    new Vector3(instantiatePosX[NotesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].line],
                    //基本の値 * speed * その倍率で、高さを設定
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    // 回転は、特になし
                    new Quaternion(0, 0, 0, 0)) as GameObject);


                // 生成したViewNotesの流れるspeedを設定
                viewNotesManager.viewNotesListLine_0[viewNotesManager.viewNotesLineNum[0]].GetComponent<ViewNotesScript>().
                    // 距離（基本の値 * speed * その倍率）
                    NotesSpeedSetter((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage)
                    // 時間（m/s を　m/s^2 に変換）60fps用に設定
                    / (viewNotesTime / 1000f) / 60);

                // 干渉するノーツを次にする
                viewNotesManager.viewNotesLineNum[0]++;
            }
        }

        // 上のラインが違う番
        if (NotesDataList.listNumMax[1] > viewNotesManager.viewNotesLineNum[1])
        {
            if ((NotesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].time - viewNotesTime) <= MusicData.Timer)
            {

                viewNotesManager.viewNotesListLine_1.Add(
                    Instantiate(viewNotes[NotesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].type],
                    new Vector3(instantiatePosX[NotesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].line],
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);
                viewNotesManager.viewNotesListLine_1[viewNotesManager.viewNotesLineNum[1]].GetComponent<ViewNotesScript>().NotesSpeedSetter
                    ((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage) / (viewNotesTime / 1000f) / 60);


                viewNotesManager.viewNotesLineNum[1]++;
            }
        }

        // 上のラインが違う番
        if (NotesDataList.listNumMax[2] > viewNotesManager.viewNotesLineNum[2])
        {
            if ((NotesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].time - viewNotesTime) <= MusicData.Timer)
            {

                viewNotesManager.viewNotesListLine_2.Add(
                    Instantiate(viewNotes[NotesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].type],
                    new Vector3(instantiatePosX[NotesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].line],
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                viewNotesManager.viewNotesListLine_2[viewNotesManager.viewNotesLineNum[2]].GetComponent<ViewNotesScript>().NotesSpeedSetter
                    ((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage) / (viewNotesTime / 1000f) / 60);


                viewNotesManager.viewNotesLineNum[2]++;
            }
        }

        // 上のラインが違う番
        if (NotesDataList.listNumMax[3] > viewNotesManager.viewNotesLineNum[3])
        {
            if ((NotesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].time - viewNotesTime) <= MusicData.Timer)
            {

                viewNotesManager.viewNotesListLine_3.Add(
                    Instantiate(viewNotes[NotesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].type],
                    new Vector3(instantiatePosX[NotesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].line],
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                viewNotesManager.viewNotesListLine_3[viewNotesManager.viewNotesLineNum[3]].GetComponent<ViewNotesScript>().NotesSpeedSetter
                    ((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage) / (viewNotesTime / 1000f) / 60);


                viewNotesManager.viewNotesLineNum[3]++;
            }
        }

    }
}