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
        // 1p分のviewNote生成
        for(int i = 0; i < 4;)
        {
            CreatViewNotes(i, 0);
            i++;
        }
        // 2p分のviewNote生成
        for (int i = 0; i < 4;)
        {
            CreatViewNotes(i+4, 1);
            i++;
        }
    }


    void CreatViewNotes(int line , int playerNum)
    {
        // 配列の総数を超えて配列参照しないようにする制御
        if (notesDataList.listNumMax[line] > viewNotesManager.viewNotesLineNum[line])
        {
            // lineのviewNotesLineNum[line]番のデータを参照
            // criwearの時間を基準として判定バー到達予定時間 - viewNotesTimeの時間に実行
            if ((notesDataList.notesLists[line].notesList 
                [viewNotesManager.viewNotesLineNum[line]].time - viewNotesTime) <= MusicData.Timer)
            {

                // ラインのViewノーツを管理するListに、追加する
                viewNotesManager.viewNotesLists[line].viewNotesList.Add(
                    // ViewNotesを、typeで選び、生成し
                    Instantiate(viewNotes[notesDataList.notesLists[line].notesList[viewNotesManager.viewNotesLineNum[line]].type],
                    // ライン0用のx軸Pos
                    new Vector3(instantiatePosX[line],
                    //基本の値 * speed * その倍率で、高さを設定
                    instantiatePosY * viewNotesManager.viewNotesSpeed[playerNum] 
                    * viewNotesManager.NotesSpeedLeverage[playerNum], instantiatePosZ),
                    // 回転は、特になし
                    new Quaternion(0, 0, 0, 0)) as GameObject);


                // 生成したViewNotesの流れるspeedを設定
                viewNotesManager.viewNotesLists[line].viewNotesList[viewNotesManager.viewNotesLineNum[line]].GetComponent<ViewNotesScript>().
                    // 距離（基本の値 * speed * その倍率）
                    NotesSpeedSetter((instantiatePosY * viewNotesManager.viewNotesSpeed[playerNum]
                    * viewNotesManager.NotesSpeedLeverage[playerNum])
                    // 時間（m/s を　m/s^2 に変換）60fps用に設定
                    / (viewNotesTime / 1000f) / 60);


                // 生成したViewNotesに対応する譜面データが毒ノーツなら
                if (notesDataList.notesLists[line].notesList[viewNotesManager.viewNotesLineNum[line]].isPoison)
                {
                    // 生成したViewNotesの見た目をポイズンノーツに変更
                    viewNotesManager.viewNotesLists[line].viewNotesList[viewNotesManager.viewNotesLineNum[line]].
                        GetComponent<SpriteRenderer>().sprite = poisonNotesSprite;
                }


                //ノーツを現在のキャラと所持ラインに合わせて色を変える
                // Color型への変換成功するとcolorにColor型の赤色が代入される）outキーワードで参照渡しにする
                if(linesManager.haveLines_1p >= line)
                {
                    if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count[0]],
                        out colorCode))
                    {
                        viewNotesManager.viewNotesLists[line].viewNotesList[viewNotesManager.viewNotesLineNum[line]].
                       GetComponent<SpriteRenderer>().color = colorCode;
                    }
                }
                else
                {
                    if (ColorUtility.TryParseHtmlString(charaNotesColorCode[testChara.count[1]],
                        out colorCode))
                    {
                        viewNotesManager.viewNotesLists[line].viewNotesList[viewNotesManager.viewNotesLineNum[line]].
                       GetComponent<SpriteRenderer>().color = colorCode;
                    }
                }



                // 干渉するノーツを次にする
                viewNotesManager.viewNotesLineNum[line]++;

                // ノーツの生成が完了したため、干渉するノーツを次にする
                notesDataList.nowNoteDataNum[playerNum]++;
            }
        }
    }
}