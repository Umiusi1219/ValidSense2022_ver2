using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewNoteCreater : MonoBehaviour
{
    /// <summary>
    /// 表示用ノーツを生成する為に、素材を格納してあるList
    /// </summary>
    [SerializeField] 
    List<GameObject> viewNotes;

    /// <summary>
    /// 表示用ノーツ格納lineごとに格納し、生成したViewノーツを管理する用
    /// 0番ライン
    /// </summary>
    [SerializeField] 
    List<GameObject> line0ViewNoteList;

    /// <summary>
    /// 表示用ノーツ格納lineごとに格納し、生成したViewノーツを管理する用
    /// 1番ライン
    /// </summary>
    [SerializeField] 
    List<GameObject> line1ViewNoteList;


    /// <summary>
    /// 表示用ノーツ格納lineごとに格納し、生成したViewノーツを管理する用
    /// 2番ライン
    /// </summary>
    [SerializeField] 
    List<GameObject> line2ViewNoteList;


    /// <summary>
    /// 表示用ノーツ格納lineごとに格納し、生成したViewノーツを管理する用
    /// 3番ライン
    /// </summary>
    [SerializeField] 
    List<GameObject> line3ViewNoteList;


    /// <summary>
    /// 各ラインが何番目のViewノーツに干渉するか、管理用
    /// </summary>
    [SerializeField] 
    public int[] lineViewNoteNum ;


    /// <summary>
    /// 各ラインが何番目のViewノーツを消すか、管理用
    /// </summary>
    [SerializeField] 
    public int[] lineViewNoteDereatNum;


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
    [SerializeField,Range(0,9000)] 
    long viewNoteTime = 4500;


    /// <summary>
    /// Viewノーツをどれくらいの速さで流すかの基準になる、値
    /// 主に難易度に対応
    /// </summary>
    [Range(0.5f,30.0f)]
    public float viewNoteSpeed;


    /// <summary>
    /// スキルによるViewノーツSpeedの変化用の値
    /// </summary>
    public float notesSpeedLeverage;


    private void FixedUpdate()
    {
        // 配列の総数を超えて配列参照しないようにする制御
        if (NoteDataListCreater.listNumMax[0] > lineViewNoteNum[0])
        {
            // ライン0のlineViewNoteNum[0]番のデータを参照
            // criwearの時間を基準として判定バー到達予定時間 - viewNoteTimeの時間に実行
            if ((NoteDataListCreater.noteList_0[lineViewNoteNum[0]].time - viewNoteTime) <= MusicData.Timer)
            {
                /* デバック用
                Debug.Log("noteList_0[lineViewNoteNum[0]].time - viewNoteTime");
                Debug.Log(NoteDataListCreater.noteList_0[lineViewNoteNum[0]].time - viewNoteTime);
                Debug.Log("NoteCreateTime");
                Debug.Log(MusicData.Timer);
                Debug.Log("noteList_0[lineViewNoteNum[0]].time");
                Debug.Log(NoteDataListCreater.noteList_0[lineViewNoteNum[0]].time);
                Debug.Log("noteList_0[lineViewNoteNum[0]].type");
                Debug.Log(NoteDataListCreater.noteList_0[lineViewNoteNum[0]].type);
                 */

                
                // ライン0のViewノーツを管理するListに、追加する
                line0ViewNoteList.Add(
                    // ViewNotesを、typeで選び、生成し
                    Instantiate(viewNotes[NoteDataListCreater.noteList_0[lineViewNoteNum[0]].type],
                    // ライン0用のx軸Pos
                    new Vector3(instantiatePosX[NoteDataListCreater. noteList_0[lineViewNoteNum[0]].line],
                    //基本の値 * speed * その倍率で、高さを設定
                    instantiatePosY * viewNoteSpeed * notesSpeedLeverage , instantiatePosZ),
                    // 回転は、特になし
                    new Quaternion(0, 0, 0, 0)) as GameObject);


                // 生成したViewNotesの流れるspeedを設定
                line0ViewNoteList[lineViewNoteNum[0]].GetComponent<NoteView>().
                    // 距離（基本の値 * speed * その倍率）
                    NoteSpeedSetter((instantiatePosY * viewNoteSpeed * notesSpeedLeverage)
                    // 時間（m/s を　m/s^2 に変換）60fps用に設定
                    / (viewNoteTime / 1000f) / 60);

                // 干渉するノーツを次にする
                lineViewNoteNum[0]++;
            }
        }

        // 上のラインが違う番
        if (NoteDataListCreater.listNumMax[1] > lineViewNoteNum[1])
        {
            if ((NoteDataListCreater.noteList_1[lineViewNoteNum[1]].time - viewNoteTime) <= MusicData.Timer)
            {
                /*
                Debug.Log("noteList_1[line1ViewNoteNum].time - viewNoteTime");
                Debug.Log(NoteDataListCreater.noteList_1[lineViewNoteNum[1]].time - viewNoteTime);
                Debug.Log("NoteCreateTime");
                Debug.Log(MusicData.Timer);
                Debug.Log("noteList_1[line1ViewNoteNum].time");
                Debug.Log(NoteDataListCreater.noteList_1[lineViewNoteNum[1]].time);

                Debug.Log("noteList_1[line1ViewNoteNum].type");
                Debug.Log(NoteDataListCreater.noteList_1[lineViewNoteNum[1]].type);
                */

                line1ViewNoteList.Add(
                    Instantiate(viewNotes[NoteDataListCreater.noteList_1[lineViewNoteNum[1]].type],
                    new Vector3(instantiatePosX[NoteDataListCreater.noteList_1[lineViewNoteNum[1]].line], 
                    instantiatePosY * viewNoteSpeed * notesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);
                line1ViewNoteList[lineViewNoteNum[1]].GetComponent<NoteView>().NoteSpeedSetter
                    ((instantiatePosY * viewNoteSpeed * notesSpeedLeverage) / (viewNoteTime / 1000f) / 60);


                lineViewNoteNum[1]++;
            }
        }

        // 上のラインが違う番
        if (NoteDataListCreater.listNumMax[2] > lineViewNoteNum[2])
        {
            if ((NoteDataListCreater.noteList_2[lineViewNoteNum[2]].time - viewNoteTime) <= MusicData.Timer)
            {
                /*
                Debug.Log("noteList_1[line1ViewNoteNum].time - viewNoteTime");
                Debug.Log(NoteDataListCreater.noteList_2[lineViewNoteNum[2]].time - viewNoteTime);
                Debug.Log("NoteCreateTime");
                Debug.Log(MusicData.Timer);
                Debug.Log("noteList_1[line1ViewNoteNum].time");
                Debug.Log(NoteDataListCreater.noteList_2[lineViewNoteNum[2]].time);

                Debug.Log("noteList_1[line1ViewNoteNum].type");
                Debug.Log(NoteDataListCreater.noteList_2[lineViewNoteNum[2]].type);
                */

                
                line2ViewNoteList.Add(
                    Instantiate(viewNotes[NoteDataListCreater.noteList_2[lineViewNoteNum[2]].type],
                    new Vector3(instantiatePosX[NoteDataListCreater.noteList_2[lineViewNoteNum[2]].line], 
                    instantiatePosY * viewNoteSpeed * notesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                line2ViewNoteList[lineViewNoteNum[2]].GetComponent<NoteView>().NoteSpeedSetter
                    ((instantiatePosY * viewNoteSpeed * notesSpeedLeverage) / (viewNoteTime / 1000f) / 60);


                lineViewNoteNum[2]++;
            }
        }

        // 上のラインが違う番
        if (NoteDataListCreater.listNumMax[3] > lineViewNoteNum[3])
        {
            if ((NoteDataListCreater.noteList_3[lineViewNoteNum[3]].time - viewNoteTime) <= MusicData.Timer)
            {
                /*
                Debug.Log("noteList_1[line1ViewNoteNum].time - viewNoteTime");
                Debug.Log(NoteDataListCreater.noteList_3[lineViewNoteNum[3]].time - viewNoteTime);
                Debug.Log("NoteCreateTime");
                Debug.Log(MusicData.Timer);
                Debug.Log("noteList_1[line1ViewNoteNum].time");
                Debug.Log(NoteDataListCreater.noteList_3[lineViewNoteNum[3]].time);

                Debug.Log("noteList_1[line1ViewNoteNum].type");
                Debug.Log(NoteDataListCreater.noteList_3[lineViewNoteNum[3]].type);
                */

                
                line3ViewNoteList.Add(
                    Instantiate(viewNotes[NoteDataListCreater.noteList_3[lineViewNoteNum[3]].type],
                    new Vector3(instantiatePosX[NoteDataListCreater.noteList_3[lineViewNoteNum[3]].line], 
                    instantiatePosY * viewNoteSpeed * notesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                line3ViewNoteList[lineViewNoteNum[3]].GetComponent<NoteView>().NoteSpeedSetter
                    ((instantiatePosY * viewNoteSpeed * notesSpeedLeverage) / (viewNoteTime / 1000f) / 60);


                lineViewNoteNum[3]++;
            }
        }

    }


    /// <summary>
    /// // 引数番のラインの、lineViewNoteDereatNum番のViewNotesのフェードアウト
    /// </summary>
    /// <param name="line"> 干渉するラインの指定 </param>
    public void NowNoteFadeOut(int line)
    {
        // ラインのスイッチ
        switch(line)
        {
            case 0:
                // ライン0の、lineViewNoteDereatNum番のViewNotesのフェードアウト
                line0ViewNoteList[lineViewNoteDereatNum[0]].GetComponent<NoteView>().NoteFadeOut();
                // ライン0の、ViewNoteDereatNumを次にずらす
                lineViewNoteDereatNum[0]++;
                break;

            //上のライン違い
            case 1:
                line1ViewNoteList[lineViewNoteDereatNum[1]].GetComponent<NoteView>().NoteFadeOut();
                lineViewNoteDereatNum[1]++;
                break;

            //上のライン違い
            case 2:
                line2ViewNoteList[lineViewNoteDereatNum[2]].GetComponent<NoteView>().NoteFadeOut();
                lineViewNoteDereatNum[2]++;
                break;

            //上のライン違い
            case 3:
                line3ViewNoteList[lineViewNoteDereatNum[3]].GetComponent<NoteView>().NoteFadeOut();
                lineViewNoteDereatNum[3]++;
                break;
        }
    }
}
