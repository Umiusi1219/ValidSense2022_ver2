using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SkillManager : MonoBehaviour
{
    /// <summary>
    /// notesJudgeの参照
    /// </summary>
    [SerializeField]
    NotesJudge notesJudge;

    /// <summary>
    /// ViewNotesManagerの参照
    /// </summary>
    [SerializeField]
    ViewNotesManager viewNotesManager;

    /// <summary>
    /// NoteDataListの参照
    /// </summary>
    [SerializeField]
    NotesDataList notesDataList;


    /// <summary>
    /// キャラをいじってる子に参照用
    /// </summary>
    [SerializeField]
    TestChara testChara;


    /// <summary>
    /// 1P,2PのbarLineTop
    /// </summary>
    [SerializeField]
    GameObject[] barLine;


    /// <summary>
    /// barLineの動く量
    /// </summary>
    [SerializeField]
    float barDecreaseValue;



    /// <summary>
    /// スキル再発動可能になるまでの時間
    /// </summary>
    [SerializeField]
    private float skillCoolTime;

    [SerializeField]
    private bool canSightSkill;

    /// <summary>
    /// サイトスキルの速度
    /// </summary>
    [SerializeField]
    private float sightSkillSpeed;

    /// <summary>
    /// サイトスキルのイメージ
    /// </summary>
    [SerializeField]
    private RawImage[] sightSkillUI;

    /// <summary>
    /// サイトスキルの持続時間
    /// </summary>
    [SerializeField]
    private float sightSkilltime;

    /// <summary>
    /// タクタイルスキルの持続時間
    /// </summary>
    [SerializeField]
    private float tactileSkillTime;

    /// <summary>
    /// スキル発動可能かどうか
    /// </summary>
    [SerializeField]
    private bool canTactileSkill;

    [SerializeField]
    private bool canSmaillTasteSkill;

    
    /// <summary>
    /// スメイル、テイストスキルのノーツの数割り出しの値
    /// </summary>
    [SerializeField]
    private int smaillSkillDivValue;

    /// <summary>
    /// 毒ノーツにした数
    /// </summary>
    [SerializeField]
    private int notesCheckedCount;


    /// <summary>
    /// ヒアスキルの持続時間
    /// </summary>
    [SerializeField]
    private float hearSkillTime;
    
    [SerializeField]
    private bool canHearSkill;

    /// <summary>
    /// ヒアがスキルを使った時の判定の値
    /// </summary>
    [SerializeField]
    private long hearSkillValue;

    /// <summary>
    /// タクタイルがスキルを使った時加速の値
    /// </summary>
    [SerializeField]
    private float[] tactile_accel;

    /// <summary>
    /// タクタイルがスキルを使った時減速の値
    /// </summary>
    [SerializeField]
    private float tactile_deceleration;

    [SerializeField]
    GameObject musicDataObj;

    [SerializeField]
    private float bpm;


    void Start()
    {
        //曲データからbpmを呼び出す
        bpm = musicDataObj.GetComponent<JsonReader>()._songList.songdata.bpm;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(SightSkill(0));
            Debug.Log("サイトスキル発動");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(TactileSkill(0));
            Debug.Log("タクタイル発動");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(SmaillTasteSkill(0));
            Debug.Log("スメル発動");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(HearSkill(0));
            Debug.Log("ヒア発動");
        }


        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            StartCoroutine(SightSkill(1));
            Debug.Log("サイトスキル発動");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            StartCoroutine(TactileSkill(1));
            Debug.Log("タクタイル発動");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            StartCoroutine(SmaillTasteSkill(1));
            Debug.Log("スメル発動");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            StartCoroutine(HearSkill(1));
            Debug.Log("ヒア発動");
        }
    }



    /// <summary>
    /// 現在のキャラにあったスキルの発動
    /// </summary>
    public void UseSkill_Logic(int usePlayer)
    {
        switch (testChara.count[usePlayer])
        {
            case (int)ConstRepo.Chara.Sight:
                StartCoroutine(SightSkill(usePlayer));
                Debug.Log("サイトスキル発動");
                break;

            case (int)ConstRepo.Chara.Tactile:
                StartCoroutine(TactileSkill(usePlayer));
                Debug.Log("タクタイルスキル発動");
                break;

            case (int)ConstRepo.Chara.Smell_Taste:
                StartCoroutine(SmaillTasteSkill(usePlayer));
                Debug.Log("スメルスキル発動");
                break;

            case (int)ConstRepo.Chara.Hear:
                StartCoroutine(HearSkill(usePlayer));
                Debug.Log("ヒアスキル発動");
                break;
        }
    }


    /// <summary>
    /// 現在のキャラにあったスキルの発動が可能かどうか
    /// </summary>
    public bool IsCanUseSkill()
    {
        switch (testChara.count[0])
        {
            case 0:
                return canSightSkill;

            case 1:
                return canTactileSkill;
            case 2:
                return  canSmaillTasteSkill;
            case 3:
                return canHearSkill;

            default:
                return false;
        }
    }




    /// <summary>
    /// サイトのスキル
    /// </summary>
    /// <param name="usePlayerNum">プレイヤーの番号を入れる（０からカウント）</param>
    /// <returns></returns>
    IEnumerator SightSkill(int usePlayerNum)
    {
        canSightSkill = false;

        // 下に移動
        while (sightSkillUI[usePlayerNum].transform.position.y
            >= 0 + 1080 / 60 / sightSkillSpeed)
        {
            sightSkillUI[usePlayerNum].transform.position -=
                new Vector3(0, 1080 / 60 / sightSkillSpeed, 0);

            // 1フレームまつ
            yield return null;
        }

        //　ｙのずれ防止
        sightSkillUI[usePlayerNum].transform.position =
            new Vector3(sightSkillUI[usePlayerNum].transform.position.x,
            0, sightSkillUI[usePlayerNum].transform.position.z);

        // タクタイルのスキル時間だけ待つ
        yield return new WaitForSeconds(sightSkilltime);

        //　上に移動
        while (sightSkillUI[usePlayerNum].transform.position.y <= 1080)
        {
            sightSkillUI[usePlayerNum].transform.position +=
                new Vector3(0, 1080 / 60 / sightSkillSpeed, 0);

            // 1フレームまつ
            yield return null;
        }

        // ｙのずれ防止
        sightSkillUI[usePlayerNum].transform.position =
            new Vector3(sightSkillUI[usePlayerNum].transform.position.x,
            1080, sightSkillUI[usePlayerNum].transform.position.z);

        // スキルが終わってcooltimeがかかる
        yield return new WaitForSeconds(skillCoolTime);

        // cooltimeが終わったらスキル使用可能
        canSightSkill = true;
    }


    IEnumerator TactileSkill(int usePlayer)
    {
        if (usePlayer == 0)
        {
            usePlayer = 1;
        }
        else
        {
            usePlayer = 0;
        }

        //　スキル使用不可にする
        canTactileSkill = false;

        //　減速と加速をswitchで分ける
        switch (Random.Range(0, 2))
        {
            // 加速をbpmが200以上と未満で２つに分ける
            case 0:
                if (bpm <= 200)
                {
                    viewNotesManager.NotesSpeedLeverage[usePlayer] = tactile_accel[0];
                }
                else
                {
                    viewNotesManager.NotesSpeedLeverage[usePlayer] = tactile_accel[1];
                }
                break;
            // 減速
            case 1:
                viewNotesManager.NotesSpeedLeverage[usePlayer] = tactile_deceleration;
                break;

        }
        // タクタイルのスキル時間だけ待つ
        yield return new WaitForSeconds(tactileSkillTime);

        // スキル用変数を初期値に変更
        viewNotesManager.NotesSpeedLeverage[usePlayer] = 1;

        // スキルが終わってcooltimeがかかる
        yield return new WaitForSeconds(skillCoolTime);

        // cooltimeが終わったらスキル使用可能
        canTactileSkill = true;
    }


    /// <summary>
    /// スメル＆テイストのスキル
    /// </summary>
    /// <returns></returns>
    IEnumerator SmaillTasteSkill(int usePlayer)
    {
        if (usePlayer == 0)
        {
            usePlayer = 1;
        }
        else
        {
            usePlayer = 0;
        }

        //　スキル使用不可にする
        canSmaillTasteSkill = false;


        // 総ノーツ ÷ 毒ノーツに変える数を割り出し用の値分繰り返す
        for (int i = 0; i < notesDataList.musicNotesDate[usePlayer].notesList. Count / smaillSkillDivValue;)
        {
            Debug.Log(notesDataList.musicNotesDate[usePlayer].notesList.Count / smaillSkillDivValue);


            // 総ノーツ数が、現在の譜面進行度 + 干渉した数より大きければ
            if (notesDataList.musicNotesDate[usePlayer].notesList.Count > notesDataList.nowNoteDataNum[usePlayer] + notesCheckedCount)
            {
                if (notesDataList.musicNotesDate[usePlayer].notesList
                    [notesDataList.nowNoteDataNum[usePlayer] + notesCheckedCount].type == 0)
                    //|| notesDataList.musicNotesDate[usePlayer].notesList
                    //[notesDataList.nowNoteDataNum[usePlayer] + notesCheckedCount].type == 1)
                {
                    // 現在の譜面進行度 + 干渉した数を足した所のノーツを毒ノーツ判定にする
                    notesDataList.musicNotesDate[usePlayer].notesList
                        [notesDataList.nowNoteDataNum[usePlayer] + notesCheckedCount].isPoison = true;

                    i++;
                }
                // ノーツチェックカウントを加算する
                notesCheckedCount++;
            }

            // 総ノーツに数が、現在の譜面進行度 + 干渉した数以下なら
            if (notesDataList.musicNotesDate[usePlayer].notesList.Count <= notesDataList.nowNoteDataNum[usePlayer] + notesCheckedCount)
            {
                i++;
            }
        }


        // 総ノーツに数が、現在の譜面進行度 + 干渉した数より大きければ
        if (notesDataList.musicNotesDate[usePlayer].notesList.Count > notesDataList.nowNoteDataNum[usePlayer] + notesCheckedCount)
        {
            // 最後に干渉したノーツの判定時間までまつ
            yield return new WaitForSeconds((notesDataList.musicNotesDate[usePlayer].notesList
                [notesDataList.nowNoteDataNum[usePlayer] + notesCheckedCount]
                .time - MusicData.Timer) / 1000);

        }


        // 総ノーツに数が、現在の譜面進行度 + 干渉した数以下なら
        if (notesDataList.musicNotesDate[usePlayer].notesList.Count <= notesDataList.nowNoteDataNum[usePlayer] + notesCheckedCount)
        {
            // 譜面最後のノーツ判定時間までまつ
            yield return new WaitForSeconds((notesDataList.musicNotesDate[usePlayer].notesList
                [notesDataList.musicNotesDate[usePlayer].notesList.Count - 1].time - MusicData.Timer) / 1000);

            Debug.Log("譜面外");
        }

        // スキルが終わってcooltimeがかかる
        yield return new WaitForSeconds(skillCoolTime);

        //スキルを再発動可能にする
        canSmaillTasteSkill = true;
    }


    /// <summary>
    /// ヒアのスキル
    /// </summary>
    /// <param name="usePlayerNum">プレイヤーのナンバー（0と1のみ）</param>
    /// <returns></returns>
    IEnumerator HearSkill(int usePlayerNum)
    {
        if(usePlayerNum == 0)
        {
            usePlayerNum = 1;
        }
        else
        {
            usePlayerNum = 0;
        }

        //　スキル使用不可にする
        canHearSkill = false;

        // 判定の値を変更する
        notesJudge.judgeLeverage[usePlayerNum] = hearSkillValue;


        //判定バーを移動させる
        barLine[usePlayerNum].transform.localScale
            -= new Vector3(0, barDecreaseValue, 0);



        //ヒアのスキル時間だけ待つ
        yield return new WaitForSeconds(hearSkillTime);

        // ヒアのスキルが終わったら判定を初期化
        notesJudge.judgeLeverage[usePlayerNum] = 1;


        //判定バーを元の場所に戻す
        barLine[usePlayerNum].transform.localScale
            += new Vector3(0, barDecreaseValue, 0);



        // スキルが終わってcooltimeがかかる
        yield return new WaitForSeconds(skillCoolTime);

        // cooltimeが終わったらスキル使用可能
        canHearSkill = true;
    }
}
