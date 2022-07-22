using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesJudge : MonoBehaviour
{

    /// <summary>
    /// ViewNoteManagerに参照する用
    /// </summary>
    [SerializeField]
    ViewNotesManager viewNotesManager;

    /// <summary>
    /// スキルのチャージ率を表示のするオブジェクト
    /// </summary>
    [SerializeField]
    List <SkillChargeRate> skillChargeText;


    /// <summary>
    /// コンボ数を表記してるオブジェクトに参照する用
    /// </summary>
    [SerializeField]
    List <ComboScript> ComboScript;


    /// <summary>
    /// Lineを管理してるマネージャーに参照する用
    /// </summary>
    [SerializeField]
    LinesManager linesManager;


    /// <summary>
    /// playerInputに参照する用
    /// </summary>
    [SerializeField]
    PlayerInput playerInput;


    /// <summary>
    /// レーン奪取に使用する、poor数記憶用
    /// </summary>
    [SerializeField]
    private int[] _poorCount;


    /// <summary>
    /// レーン奪取するタイミング
    /// </summary>
    [SerializeField]
    private int _lineStealTiming;



    /// <summary>
    /// エフェクト生成用のエフェクトリスト
    /// </summary>
    [SerializeField]
    List<RawImage> effectList;


    /// <summary>
    /// 生成するエフェクトの一時保存先
    /// </summary>
    [SerializeField]
    RawImage[] effect;

    /// <summary>
    /// 生成するエフェクトの親
    /// </summary>
    [SerializeField]
    Canvas effectParent;


    /// <summary>
    /// エフェクト生成時の、Pos指定用
    /// </summary>
    [SerializeField]
    private RectTransform[] instancePos;


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
    /// <summary>
    /// Briliantの判定用の値
    /// </summary>
    private long briliantJudge = 30;
    /// <summary>
    /// Greatの判定用の値
    /// </summary>
    private long greatJudge = 60;
    /// <summary>
    /// Goodの判定用の値
    /// </summary>
    private long goodJudge = 120;


    /// <summary>
    /// スキルのチャージの値増加用
    /// </summary>
    [SerializeField]
    int[] addSkillValue;


    /// <summary>
    /// スキルで判定を絞る為の値(割り算)
    /// </summary>
    [SerializeField]
    public long[] judgeLeverage;


    /// <summary>
    /// スコア用UI参照用
    /// </summary>
    [SerializeField]
    private List  <ScoreScript> scoreValue;


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



    /// <summary>
    /// 渡された時間をもとに、今の状況で適切な判定を計算する
    /// </summary>
    /// <param name="time">判定するノーツの時間</param>
    /// <param name="line">判定するノーツが所属しているレーン</param>
    public void NotesJudgement(long time, int line ,int usePlayer)
    {

        // Briliantの判定時間 / スキルによる倍率以下なら
        if (time <= briliantJudge / judgeLeverage[usePlayer])
        {
            //Briliantエフェクトを一時格納オブジェクトに生成
            effect[line] = Instantiate(effectList[(int)JudgeType.Briliant]);

            //生成したオブジェクトの親を設定
            effect[line].transform.parent = effectParent.transform;

            // エフェクトを引数のlineに対応する場所に移動
            effect[line].rectTransform.position = instancePos[line].position;



            //スコア総数に、Briliantの値をたす
            scoreValue[usePlayer].scoreValue += _briliantScore;

            //総打数記憶用変数に加算
            scoreValue[usePlayer].totalHitsNum++;

            //スキルのチャージ率の増加(Briliant)
            skillChargeText[usePlayer].AddSkillValue(addSkillValue[(int)JudgeType.Briliant]);

            //コンボ数の加算
            ComboScript[usePlayer].AddComboValue();
        }

        // Greatの判定時間 / スキルによる倍率以下なら
        else if (time <= greatJudge / judgeLeverage[usePlayer])
        {
            //Greatエフェクトを一時格納オブジェクトに生成
            effect[line] = Instantiate(effectList[(int)JudgeType.Great]);

            //生成したオブジェクトの親を設定
            effect[line].transform.parent = effectParent.transform;

            // エフェクトを引数のlineに対応する場所に移動
            effect[line].rectTransform.position = instancePos[line].position;



            //スコア総数に、Graetの値をたす
            scoreValue[usePlayer].scoreValue += _greatScore;

            //総打数記憶用変数に加算
            scoreValue[usePlayer].totalHitsNum++;

            //スキルのチャージ率の増加(Great)
            skillChargeText[usePlayer].AddSkillValue(addSkillValue[(int)JudgeType.Great]);

            //コンボ数の加算
            ComboScript[usePlayer].AddComboValue();
        }

        // Goodの判定時間 / スキルによる倍率以下なら
        else if (time <= goodJudge / judgeLeverage[usePlayer])
        {
            //Goodエフェクトを一時格納オブジェクトに生成
            effect[line] = Instantiate(effectList[(int)JudgeType.Good]);

            //生成したオブジェクトの親を設定
            effect[line].transform.parent = effectParent.transform;

            // エフェクトを引数のlineに対応する場所に移動
            effect[line].rectTransform.position = instancePos[line].position;


            //スコア総数に、Goodの値をたす
            scoreValue[usePlayer].scoreValue += _goodScore;

            //総打数記憶用変数に加算
            scoreValue[usePlayer].totalHitsNum++;

            //スキルのチャージ率の増加(Good)
            skillChargeText[usePlayer].AddSkillValue(addSkillValue[(int)JudgeType.Good]);

            //コンボ数の加算
            ComboScript[usePlayer].AddComboValue();
        }

        //poor判定
        else
        {
            //poorエフェクトを一時格納オブジェクトに生成
            effect[line] = Instantiate(effectList[(int)JudgeType.Poor]);

            //生成したオブジェクトの親を設定
            effect[line].transform.parent = effectParent.transform;

            // エフェクトを引数のlineに対応する場所に移動
            effect[line].rectTransform.position = instancePos[line].position;


            if(usePlayer == 0)
            {
                //　一番1p側のラインがとられてなかったら
                if (linesManager.haveLines_1p > 0)
                {
                    // poor判定したので加算
                    _poorCount[usePlayer]++;
                }
            }
            else
            {
                //　一番1p側のラインがとられてなかったら
                if (linesManager.haveLines_1p < 6)
                {
                    // poor判定したので加算
                    _poorCount[1]++;
                }
            }


            //コンボ数のリセット
            ComboScript[usePlayer].ComboReset();
        }


        // スコアUIの更新
        scoreValue[usePlayer].ScoreUpdate();


        // 判定を取得したNotesのフェードアウト
        viewNotesManager.NowNotesFadeOut(line);


        //　poorのカウントが一定以上になったらレーン奪取される
        if (_poorCount[usePlayer] >= _lineStealTiming)
        {
            if(usePlayer == 0)
            {
                linesManager.LineIsStolen_1p();

            }
            else
            {
                linesManager.LineIsStolen_2p();

            }

            _poorCount[usePlayer] = 0;
        }
    }





    /// <summary>
    /// 渡された時間をもとに、毒ノーツに対して適切な判定を計算する
    /// </summary>
    /// <param name="time">判定するノーツの時間</param>
    /// <param name="line">判定するノーツが所属しているレーン</param>
    public void PoisonNotesJudgement(long time, int line , int usePlayer)
    {

        // Briliantの判定時間 / スキルによる倍率以下なら(poisonなため内部処理は、poor)
        if (time <= briliantJudge / judgeLeverage[usePlayer])
        {
            //poorエフェクトを一時格納オブジェクトに生成
            effect[line] = Instantiate(effectList[(int)JudgeType.Poor]);

            //生成したオブジェクトの親を設定
            effect[line].transform.parent = effectParent.transform;

            // エフェクトを引数のlineに対応する場所に移動
            effect[line].rectTransform.position = instancePos[line].position;



            if (usePlayer == 0)
            {
                //　一番1p側のラインがとられてなかったら
                if (linesManager.haveLines_1p > 0)
                {
                    // poor判定したので加算
                    _poorCount[usePlayer]++;
                }
            }
            else
            {
                //　一番1p側のラインがとられてなかったら
                if (linesManager.haveLines_1p < 6)
                {
                    // poor判定したので加算
                    _poorCount[1]++;
                }
            }


            //コンボ数のリセット
            ComboScript[usePlayer].ComboReset();
        }

        // Graetの判定時間 / スキルによる倍率以下なら(poisonなため内部処理は、Good)
        else if (time <= greatJudge / judgeLeverage[usePlayer])
        {
            //Goodエフェクトを一時格納オブジェクトに生成
            effect[line] = Instantiate(effectList[(int)JudgeType.Good]);

            //生成したオブジェクトの親を設定
            effect[line].transform.parent = effectParent.transform;

            // エフェクトを引数のlineに対応する場所に移動
            effect[line].rectTransform.position = instancePos[line].position;


            //スコア総数に、Goodの値をたす
            scoreValue[usePlayer].scoreValue += _goodScore;

            //総打数記憶用変数に加算
            scoreValue[usePlayer].totalHitsNum++;

            //スキルのチャージ率の増加(Good)
            skillChargeText[usePlayer].AddSkillValue(addSkillValue[(int)JudgeType.Good]);


            //コンボ数の加算
            ComboScript[usePlayer].AddComboValue();
        }
        // Goodの判定時間 / スキルによる倍率以下なら(poisonなため内部処理は、Great)
        else if (time <= goodJudge / judgeLeverage[usePlayer])
        {
            //Greatエフェクトを一時格納オブジェクトに生成
            effect[line] = Instantiate(effectList[(int)JudgeType.Great]);

            //生成したオブジェクトの親を設定
            effect[line].transform.parent = effectParent.transform;

            // エフェクトを引数のlineに対応する場所に移動
            effect[line].rectTransform.position = instancePos[line].position;


            //スコア総数に、Graetの値をたす
            scoreValue[usePlayer].scoreValue += _greatScore;

            //総打数記憶用変数に加算
            scoreValue[usePlayer].totalHitsNum++;

            //スキルのチャージ率の増加(Great)
            skillChargeText[usePlayer].AddSkillValue(addSkillValue[(int)JudgeType.Great]);

            //コンボ数の加算
            ComboScript[usePlayer].AddComboValue();
        }

        //poor判定(poisonなため内部処理は、Briliant)
        else
        {
            //Briliantエフェクトを一時格納オブジェクトに生成
            effect[line] = Instantiate(effectList[(int)JudgeType.Briliant]);

            //生成したオブジェクトの親を設定
            effect[line].transform.parent = effectParent.transform;

            // エフェクトを引数のlineに対応する場所に移動
            effect[line].rectTransform.position = instancePos[line].position;


            //スコア総数に、Briliantの値をたす
            scoreValue[usePlayer].scoreValue += _briliantScore;

            //総打数記憶用変数に加算
            scoreValue[usePlayer].totalHitsNum++;

            //スキルのチャージ率の増加(Briliant)
            skillChargeText[usePlayer].AddSkillValue(addSkillValue[(int)JudgeType.Briliant]);


            //コンボ数の加算
            ComboScript[usePlayer].AddComboValue();
        }


        // スコアUIの更新
        scoreValue[usePlayer].ScoreUpdate();


        // 判定を取得したNotesのフェードアウト
        viewNotesManager.NowNotesFadeOut(line);



        //　poorのカウントが一定以上になったらレーン奪取される
        if (_poorCount[usePlayer] >= _lineStealTiming)
        {
            if (usePlayer == 0)
            {
                linesManager.LineIsStolen_1p();
            }
            else
            {
                linesManager.LineIsStolen_2p();
            }


            //カウントの初期化
            _poorCount[usePlayer] = 0;
        }
    }
}