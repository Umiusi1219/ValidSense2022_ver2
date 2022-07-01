using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// 1PのbarLineTopを動かす
    /// </summary>
    [SerializeField]
    GameObject barLineTop_1P;

    /// <summary>
    /// 1PのbarLineUnderを動かす
    /// </summary>
    [SerializeField]
    GameObject barlineUnder_1P;

    /// <summary>
    /// 2PのbarLineTopを動かす
    /// </summary>
    [SerializeField]
    GameObject barlineTop_2P;

    /// <summary>
    /// 2PのbarLineUnderを動かす
    /// </summary>
    [SerializeField]
    GameObject barlineUnder_2P;

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

    [SerializeField]
    private bool canTactileSkill;


    [SerializeField]
    private bool canSmaillTasteSkill;
    
    /// <summary>
    /// スメイル、テイストスキルのノーツの数割り出しの値
    /// </summary>
    [SerializeField]
    private float smaillSkillDivValue;

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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(SightSkill(0));
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(TactileSkill());
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(HearSkill());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="usePlayerNum">プレイヤーの番号を入れる（０からカウント）</param>
    /// <returns></returns>
    IEnumerator SightSkill(int usePlayerNum)
    {
        canSightSkill = false;

        // 下に移動
        while(sightSkillUI[usePlayerNum].transform.position.y >= 0)
        {
            sightSkillUI[usePlayerNum].transform.position -= 
                new Vector3(0, 1080 / 60 / sightSkillSpeed, 0);

            yield return null;
        }

        //　ｙのずれ防止
        sightSkillUI[usePlayerNum].transform.position = 
            new Vector3(sightSkillUI[usePlayerNum].transform.position.x,
            0, sightSkillUI[usePlayerNum].transform.position.z);

        // タクタイルのスキル時間だけ待つ
        yield return new WaitForSeconds(sightSkilltime);

        //　上に移動
        while (sightSkillUI[usePlayerNum].transform.position.y <= 0)
        {
            sightSkillUI[usePlayerNum].transform.position +=
                new Vector3(0, 1080 / 60 / sightSkillSpeed, 0);
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

    IEnumerator TactileSkill()
    {
        //　スキル使用不可にする
        canTactileSkill = false;

        //　減速と加速をswitchで分ける
        switch(Random.Range(0,2))
        {
            // 加速をbpmが200以上と未満で２つに分ける
            case 0:
                if (bpm >= 200)
                {
                    viewNotesManager.NotesSpeedLeverage = tactile_accel[0];
                }
                else
                {
                    viewNotesManager.NotesSpeedLeverage = tactile_accel[1];
                }
                    break;
                // 減速
                case 1:
                viewNotesManager.NotesSpeedLeverage = tactile_deceleration;
                break;
                
        }
        // タクタイルのスキル時間だけ待つ
        yield return new WaitForSeconds(tactileSkillTime);

        // スキル用変数を初期値に変更
        viewNotesManager.NotesSpeedLeverage = 1;

        // スキルが終わってcooltimeがかかる
        yield return new WaitForSeconds(skillCoolTime);

        // cooltimeが終わったらスキル使用可能
        canTactileSkill = true;
    }

    IEnumerator SmaillTasteSkill() // 途中
    {
        //　スキル使用不可にす
        canSmaillTasteSkill = false;

        // スキルが終わってcooltimeがかかる
        yield return new WaitForSeconds(skillCoolTime);

        canSmaillTasteSkill = true;
    }

    IEnumerator HearSkill()
    {
        //　スキル使用不可にする
        canHearSkill = false;

        // 判定の値を変更する
        notesJudge.judgeLeverage = hearSkillValue;

        //ヒアのスキル時間だけ待つ
        yield return new WaitForSeconds(hearSkillTime);

        // ヒアのスキルが終わったら判定を初期化
        notesJudge.judgeLeverage = 1;

        // スキルが終わってcooltimeがかかる
        yield return new WaitForSeconds(skillCoolTime);

        // cooltimeが終わったらスキル使用可能
        canHearSkill = true;
    }
}
