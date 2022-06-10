using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesJudge : MonoBehaviour
{
    /// <summary>
    /// NoteJudgeの種類
    /// </summary>
    enum JudgeType
    {
        Briliant = 0,
        Great,
        Good,
        Poor,
    }

    /*
    Briliant +- 20ms
    Great +- 40ms
    Good +- 100ms
    Poor
    */


    float x = -19.5f;
    float y = -260;
    float z = 300;
    float w = -20;


    /// <summary>
    /// Briliantの判定用の値
    /// </summary>
    private long briliantJudge = 20;
    /// <summary>
    /// Greatの判定用の値
    /// </summary>
    private long greatJudge = 40;
    /// <summary>
    /// Goodの判定用の値
    /// </summary>
    private long goodJudge = 100;

    /// <summary>
    /// スキルで判定を絞る為の値
    /// </summary>
    [SerializeField]
    public long judgeRate;

    /// <summary>
    /// ViewNoteCreaterに参照する用
    /// </summary>
    [SerializeField] 
    GameObject viewNoteCreater;

    /// <summary>
    /// エフェクト生成用のエフェクトリスト
    /// </summary>
    [SerializeField]
    List<GameObject> effectList;

    /// <summary>
    /// エフェクト生成時の、xPos指定用
    /// </summary>
    [SerializeField] 
    private float[] instancePosXs;

    /// <summary>
    /// スコア用UI参照用
    /// </summary>
    [SerializeField]
    Text scoreText;

    /// <summary>
    /// スコア記憶用の値
    /// </summary>
    [SerializeField]
    private int _playerScore;


    /// <summary>
    /// Briliantの判定時、加算されるスコアの値
    /// </summary>
    [SerializeField]
    private int _briliantScore;

    /// <summary>
    /// Greatの判定時、加算されるスコアの値
    /// </summary>
    [SerializeField]
    private int _greatScore;

    /// <summary>
    /// Goodの判定時、加算されるスコアの値
    /// </summary>
    [SerializeField]
    private int _goodScore;


    //public static NotesJudge instance;

    //private void Awake()
    //{
    //     if(instance = null)
    //     {
    //        instance = this;
    //     }
    //}


    private void Start()
    {
        // スコアの表記
        scoreText.text = "score : " + _playerScore.ToString();
    }


    /// <summary>
    /// 渡された時間をもとに、今の状況で適切な判定を計算する
    /// </summary>
    /// <param name="time">判定するノーツの時間</param>
    /// <param name="line">判定するノーツが所属しているレーン</param>
    public void NotesJudgement(long time, int line)
    {
        // Briliantの判定時間 / スキルによる倍率以下なら
        if (time <= briliantJudge / judgeRate)
        {
            //Debug.Log(JudgeType.Briliant);
            //Debug.Log("JudgeTime" + MusicData.Timer);

            // Briliantのエフェクトを引数のlineに生成
            Instantiate(effectList[(int)JudgeType.Briliant],
                new Vector3(instancePosXs[line], 3.0f,80.0f),new Quaternion(0, 0, 0, 0));


            //スコア総数に、Briliantの値をたす
            _playerScore += _briliantScore;
        }

        // Graetの判定時間 * スキルによる倍率以下なら
        else if (time <= greatJudge / judgeRate)
        {
            //Debug.Log(JudgeType.Great);
            //Debug.Log("JudgeTime" + MusicData.Timer);

            // Graetのエフェクトを引数のlineに生成
            Instantiate(effectList[(int)JudgeType.Great],
                new Vector3(instancePosXs[line], 3.0f, 80.0f), new Quaternion(0, 0, 0, 0));


            //スコア総数に、Graetの値をたす
            _playerScore += _greatScore;
        }

        // Goodの判定時間 * スキルによる倍率以下なら
        else if (time <= goodJudge / judgeRate)
        {
            //Debug.Log(JudgeType.Good);
            //Debug.Log("JudgeTime" + MusicData.Timer);

            // Goodのエフェクトを引数のlineに生成
            Instantiate(effectList[(int)JudgeType.Good],
                new Vector3(instancePosXs[line], 3.0f, 80.0f), new Quaternion(0, 0, 0, 0));


            //スコア総数に、Goodの値をたす
            _playerScore += _goodScore;
        }

        //poor判定
        else
        {
            //Debug.Log(JudgeType.Poor);
            //Debug.Log("JudgeTime" + MusicData.Timer);

            // Poorのエフェクトを引数のlineに生成
            Instantiate(effectList[(int)JudgeType.Poor],
                new Vector3(instancePosXs[line], 3.0f, 83.0f), new Quaternion(x, y, z, w));
        }


        // スコアUIの更新
        scoreText.text = "score : " + _playerScore .ToString();


        // 判定を取得したNotesのフェードアウト
        viewNoteCreater.GetComponent<ViewNoteCreater>().NowNoteFadeOut(line);
    } 
}
