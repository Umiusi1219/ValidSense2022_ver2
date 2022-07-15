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
    /// 譜面データを管理するスクリプト
    [SerializeField]
    NotesDataList notesDataList;


    /// <summary>
    /// 表示用ノーツを生成する為に、素材を格納してあるList
    /// </summary>
    [SerializeField]
    public List<GameObject> viewNotes;

    /// <summary>
    /// poisonNotesの画像保存用
    /// </summary>
    [SerializeField]
    Sprite poisonNotesSprite;


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


    /// <summary>
    /// キャラをいじってる子に参照用
    /// </summary>
    [SerializeField]
    TestChara testChara;


    /// <summary>
    /// ラインを管理してる子に参照する用
    /// </summary>
    [SerializeField]
    LinesManager linesManager;


    /// <summary>
    /// Lineの色変更時使用するカラーコードの、配列
    /// </summary>
    public string[] charaNotesColorCode;


    /// <summary>
    ///string型のカラーコードをColor変換した時の受け取り先
    /// </summary>
    Color colorCode;


    private void FixedUpdate()
    {
        // 配列の総数を超えて配列参照しないようにする制御
        if (notesDataList.listNumMax[0] > viewNotesManager.viewNotesLineNum[0])
        {
            // ライン0のviewNotesLineNum[0]番のデータを参照
            // criwearの時間を基準として判定バー到達予定時間 - viewNotesTimeの時間に実行
            if ((notesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].time - viewNotesTime) <= MusicData.Timer)
            {

                // ライン0のViewノーツを管理するListに、追加する
                viewNotesManager.viewNotesListLine_0.Add(
                    // ViewNotesを、typeで選び、生成し
                    Instantiate(viewNotes[notesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].type],
                    // ライン0用のx軸Pos
                    new Vector3(instantiatePosX[notesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].line],
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


                // 生成したViewNotesに対応する譜面データが毒ノーツなら
                if (notesDataList.notesList_0[viewNotesManager.viewNotesLineNum[0]].isPoison)
                {
                    // 生成したViewNotesの見た目をポイズンノーツに変更
                    viewNotesManager.viewNotesListLine_0[viewNotesManager.viewNotesLineNum[0]].
                        GetComponent<SpriteRenderer>().sprite = poisonNotesSprite;
                }


                //ノーツを現在のキャラと所持ラインに合わせて色を変える
                // Color型への変換成功するとcolorにColor型の赤色が代入される）outキーワードで参照渡しにする
                if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count1P],
                    out colorCode))
                {
                    viewNotesManager.viewNotesListLine_0[viewNotesManager.viewNotesLineNum[0]].
                   GetComponent<SpriteRenderer>().color = colorCode;
                }


                // 干渉するノーツを次にする
                viewNotesManager.viewNotesLineNum[0]++;

                // ノーツの生成が完了したため、干渉するノーツを次にする
                notesDataList.nowNoteDataNum++;
            }
        }

        // 上のラインが違う番
        if (notesDataList.listNumMax[1] > viewNotesManager.viewNotesLineNum[1])
        {
            if ((notesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].time - viewNotesTime) <= MusicData.Timer)
            {

                viewNotesManager.viewNotesListLine_1.Add(
                    Instantiate(viewNotes[notesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].type],
                    new Vector3(instantiatePosX[notesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].line],
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);
                viewNotesManager.viewNotesListLine_1[viewNotesManager.viewNotesLineNum[1]].GetComponent<ViewNotesScript>().NotesSpeedSetter
                    ((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage) / (viewNotesTime / 1000f) / 60);


                if (notesDataList.notesList_1[viewNotesManager.viewNotesLineNum[1]].isPoison)
                {
                    viewNotesManager.viewNotesListLine_1[viewNotesManager.viewNotesLineNum[1]].
                        GetComponent<SpriteRenderer>().sprite = poisonNotesSprite;
                }


                //ノーツを現在のキャラと所持ラインに合わせて色を変える
                if (linesManager.haveLines_1p >=1)
                {
                    // Color型への変換成功するとcolorにColor型の赤色が代入される）outキーワードで参照渡しにする
                    if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count1P],
                        out colorCode))
                    {
                        //1pのカラー変更
                        viewNotesManager.viewNotesListLine_1[viewNotesManager.viewNotesLineNum[1]].
                       GetComponent<SpriteRenderer>().color = colorCode;
                    }
                }
                else
                {
                    // Color型への変換成功するとcolorにColor型の赤色が代入される）outキーワードで参照渡しにする
                    if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count2P],
                        out colorCode))
                    {
                        //2pのカラー変更
                        viewNotesManager.viewNotesListLine_1[viewNotesManager.viewNotesLineNum[1]].
                       GetComponent<SpriteRenderer>().color = colorCode;
                    }
                }


                viewNotesManager.viewNotesLineNum[1]++;

                notesDataList.nowNoteDataNum++;
            }
        }

        // 上のラインが違う番
        if (notesDataList.listNumMax[2] > viewNotesManager.viewNotesLineNum[2])
        {
            if ((notesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].time - viewNotesTime) <= MusicData.Timer)
            {

                viewNotesManager.viewNotesListLine_2.Add(
                    Instantiate(viewNotes[notesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].type],
                    new Vector3(instantiatePosX[notesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].line],
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                viewNotesManager.viewNotesListLine_2[viewNotesManager.viewNotesLineNum[2]].GetComponent<ViewNotesScript>().NotesSpeedSetter
                    ((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage) / (viewNotesTime / 1000f) / 60);


                if (notesDataList.notesList_2[viewNotesManager.viewNotesLineNum[2]].isPoison)
                {
                    viewNotesManager.viewNotesListLine_2[viewNotesManager.viewNotesLineNum[2]].
                        GetComponent<SpriteRenderer>().sprite = poisonNotesSprite;
                }


                if (linesManager.haveLines_1p >= 2)
                {
                    if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count1P],
                        out colorCode))
                    {
                        viewNotesManager.viewNotesListLine_2[viewNotesManager.viewNotesLineNum[2]].
                       GetComponent<SpriteRenderer>().color = colorCode;
                    }
                }
                else
                {
                    if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count2P],
                        out colorCode))
                    {
                        viewNotesManager.viewNotesListLine_2[viewNotesManager.viewNotesLineNum[2]].
                       GetComponent<SpriteRenderer>().color = colorCode;
                    }
                }


                viewNotesManager.viewNotesLineNum[2]++;

                notesDataList.nowNoteDataNum++;
            }
        }

        // 上のラインが違う番
        if (notesDataList.listNumMax[3] > viewNotesManager.viewNotesLineNum[3])
        {
            if ((notesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].time - viewNotesTime) <= MusicData.Timer)
            {

                viewNotesManager.viewNotesListLine_3.Add(
                    Instantiate(viewNotes[notesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].type],
                    new Vector3(instantiatePosX[notesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].line],
                    instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage, instantiatePosZ),
                    new Quaternion(0, 0, 0, 0)) as GameObject);

                viewNotesManager.viewNotesListLine_3[viewNotesManager.viewNotesLineNum[3]].GetComponent<ViewNotesScript>().NotesSpeedSetter
                    ((instantiatePosY * viewNotesManager.viewNotesSpeed * viewNotesManager.NotesSpeedLeverage) / (viewNotesTime / 1000f) / 60);


                if (notesDataList.notesList_3[viewNotesManager.viewNotesLineNum[3]].isPoison)
                {
                    viewNotesManager.viewNotesListLine_3[viewNotesManager.viewNotesLineNum[3]].
                        GetComponent<SpriteRenderer>().sprite = poisonNotesSprite;
                }


                if (linesManager.haveLines_1p >= 3)
                {
                    if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count1P],
                        out colorCode))
                    {
                        viewNotesManager.viewNotesListLine_3[viewNotesManager.viewNotesLineNum[3]].
                       GetComponent<SpriteRenderer>().color = colorCode;
                    }
                }
                else
                {
                    if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count2P],
                        out colorCode))
                    {
                        viewNotesManager.viewNotesListLine_3[viewNotesManager.viewNotesLineNum[3]].
                       GetComponent<SpriteRenderer>().color = colorCode;
                    }
                }


                viewNotesManager.viewNotesLineNum[3]++;

                notesDataList.nowNoteDataNum++;
            }
        }

    }
}