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
    /// ラインマネージャーに参照する用
    /// </summary>
    [SerializeField]
    LinesManager linesManager;


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
    /// スキル使用用スクリプトを参照する用
    /// </summary>
    [SerializeField]
    SkillManager skillManager;


    /// <summary>
    /// スキルのUIスクリプトを参照する用
    /// </summary>
    [SerializeField]
    SkillChargeRate skillChargeRate;


    /// <summary>
    /// 何番目のノーツに干渉するかの値の配列
    /// </summary>
    [SerializeField]
    public int[] lineNotesNum; 


    /// <summary>
    /// スキルの発動時に連続でのキー入力に対する猶予時間
    /// </summary>
    [SerializeField]
    private float _inputStandbyTime;


    /// <summary>
    /// スキルの発動時同時押しで誤作動しないようにする為の入力無効時間
    /// </summary>
    [SerializeField]
    private float _inputInvalidTime;


    /// <summary>
    /// スキルの発動時にキー入力してからどれくらい時間が経過してるか記憶用(右からの入力)
    /// </summary>
    [SerializeField]
    private float[] _inputWaitTime_R;

    /// <summary>
    /// スキルの発動時にキー入力してからどれくらい時間が経過してるか記憶用(左からの入力)
    /// </summary>
    [SerializeField]
    private float[] _inputWaitTime_L;


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
        if (notesDataList.listNumMax[0] > lineNotesNum[0])
        {
            // Qキーを押したとき
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // criwearの時間 - 判定バー到達予定時間 < judgeTimeなら実行
                if (notesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer < judgeTime)
                {
                    // ノーツがポイズンノーツかそうじゃないかで、判定を変える
                    if (notesDataList.notesList_0[lineNotesNum[0]].isPoison)
                    {
                        // 判定用関数で、ポイズンノーツの判定をする
                        notesJudge.PoisonNotesJudgement(
                            // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                            (long)Mathf.Abs(notesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer), 0);
                    }
                    else
                    {
                        // 判定用関数で、ノーマルノーツの判定をする
                        notesJudge.NotesJudgement(
                            // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                            (long)Mathf.Abs(notesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer), 0);
                    }


                    //干渉するノーツを次にする
                    lineNotesNum[0]++;

                }
            }
            // poor判定の自動化
            // 判定バー到達予定時間 - criwearの時間 < poorTimingなら実行
            if (notesDataList.listNumMax[0] > lineNotesNum[0]
                && notesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {

                // ノーツがポイズンノーツかそうじゃないかで、判定を変える
                if (notesDataList.notesList_0[lineNotesNum[0]].isPoison)
                {
                    // 判定用関数で、毒ノーツの判定をする
                    notesJudge.PoisonNotesJudgement(
                        // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                        (long)Mathf.Abs(notesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer), 0);
                }
                else
                {
                    // 判定用関数で、ノーマルノーツの判定をする
                    notesJudge.NotesJudgement(
                        // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                        (long)Mathf.Abs(notesDataList.notesList_0[lineNotesNum[0]].time - MusicData.Timer), 0);
                }


                //干渉するノーツを次にする
                lineNotesNum[0]++;
            }
        }

        // 上のラインが違う番-------------------------------------------------------------------------
        if (notesDataList.listNumMax[1] > lineNotesNum[1])
        {
            // wに対応するラインが奪われてなかったらWキーで判定
            if(linesManager.Get_1pHaveLines() >= 1)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (notesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer < judgeTime)
                    {
                        if (notesDataList.notesList_1[lineNotesNum[1]].isPoison)
                        {
                            notesJudge.PoisonNotesJudgement(
                            (long)(Mathf.Abs(notesDataList.notesList_1[lineNotesNum[1]].time) - MusicData.Timer), 1);
                        }
                        else
                        {
                            notesJudge.NotesJudgement(
                            (long)(Mathf.Abs(notesDataList.notesList_1[lineNotesNum[1]].time) - MusicData.Timer), 1);
                        }


                        lineNotesNum[1]++;
                    }
                }
            }
            // wに対応するラインが奪われていたらSキーで判定
            else
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (notesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer < judgeTime)
                    {
                        if (notesDataList.notesList_1[lineNotesNum[1]].isPoison)
                        {
                            notesJudge.PoisonNotesJudgement(
                            (long)(Mathf.Abs(notesDataList.notesList_1[lineNotesNum[1]].time) - MusicData.Timer), 1);
                        }
                        else
                        {
                            notesJudge.NotesJudgement(
                            (long)(Mathf.Abs(notesDataList.notesList_1[lineNotesNum[1]].time) - MusicData.Timer), 1);
                        }

                        lineNotesNum[1]++;
                    }
                }
            }

            // poor判定の自動化
            if (notesDataList.listNumMax[1] > lineNotesNum[1]
                && notesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                if (notesDataList.notesList_1[lineNotesNum[1]].isPoison)
                {
                    notesJudge.PoisonNotesJudgement(
                        (long)Mathf.Abs(notesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer), 1);
                }
                else
                {
                    notesJudge.NotesJudgement(
                        (long)Mathf.Abs(notesDataList.notesList_1[lineNotesNum[1]].time - MusicData.Timer), 1);
                }


                lineNotesNum[1]++;
            }
        }

        // 上のラインが違う番--------------------------------------------------------------------------
        if (notesDataList.listNumMax[2] > lineNotesNum[2])
        {
            // Eに対応するラインが奪われてなかったらEキーで判定
            if (linesManager.Get_1pHaveLines() >= 2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (notesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer < judgeTime)
                    {
                        if (notesDataList.notesList_2[lineNotesNum[2]].isPoison)
                        {
                            notesJudge.PoisonNotesJudgement(
                                (long)(Mathf.Abs(notesDataList.notesList_2[lineNotesNum[2]].time) - MusicData.Timer), 2);
                        }
                        else
                        {
                            notesJudge.NotesJudgement(
                                (long)(Mathf.Abs(notesDataList.notesList_2[lineNotesNum[2]].time) - MusicData.Timer), 2);
                        }


                        lineNotesNum[2]++;
                    }
                }
            }
            // Eに対応するラインが奪われていたらDキーで判定
            else
            {
                if (Input.GetKeyDown(KeyCode.D))
                {

                    if (notesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer < judgeTime)
                    {
                        if (notesDataList.notesList_2[lineNotesNum[2]].isPoison)
                        {
                            notesJudge.PoisonNotesJudgement(
                                (long)(Mathf.Abs(notesDataList.notesList_2[lineNotesNum[2]].time) - MusicData.Timer), 2);
                        }
                        else
                        {
                            notesJudge.NotesJudgement(
                                (long)(Mathf.Abs(notesDataList.notesList_2[lineNotesNum[2]].time) - MusicData.Timer), 2);
                        }

                        lineNotesNum[2]++;
                    }
                }
            }
            // poor判定の自動化
            if (notesDataList.listNumMax[2] > lineNotesNum[2]
                && notesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                if (notesDataList.notesList_2[lineNotesNum[2]].isPoison)
                {
                    notesJudge.PoisonNotesJudgement(
                        (long)Mathf.Abs(notesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer), 2);
                }
                else
                {
                    notesJudge.NotesJudgement(
                        (long)Mathf.Abs(notesDataList.notesList_2[lineNotesNum[2]].time - MusicData.Timer), 2);
                }

                lineNotesNum[2]++;
            }
        }

        // 上のラインが違う番-------------------------------------------------------------------
        if (notesDataList.listNumMax[3] > lineNotesNum[3])
        {
            // Rに対応するラインが奪われてなかったらRキーで判定
            if (linesManager.Get_1pHaveLines() >= 3)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {

                    if (notesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer < judgeTime)
                    {
                        if (notesDataList.notesList_3[lineNotesNum[3]].isPoison)
                        {
                            notesJudge.PoisonNotesJudgement(
                                (long)(Mathf.Abs(notesDataList.notesList_3[lineNotesNum[3]].time) - MusicData.Timer), 3);
                        }
                        else
                        {
                            notesJudge.NotesJudgement(
                                (long)(Mathf.Abs(notesDataList.notesList_3[lineNotesNum[3]].time) - MusicData.Timer), 3);
                        }

                        lineNotesNum[3]++;
                    }

                }
            }
            // Rに対応するラインが奪われていたらFキーで判定
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {

                    if (notesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer < judgeTime)
                    {
                        if (notesDataList.notesList_3[lineNotesNum[3]].isPoison)
                        {
                            notesJudge.PoisonNotesJudgement(
                                (long)(Mathf.Abs(notesDataList.notesList_3[lineNotesNum[3]].time) - MusicData.Timer), 3);
                        }
                        else
                        {
                            notesJudge.NotesJudgement(
                                (long)(Mathf.Abs(notesDataList.notesList_3[lineNotesNum[3]].time) - MusicData.Timer), 3);
                        }

                        lineNotesNum[3]++;
                    }

                }
            }


            // poor判定の自動化
            if (notesDataList.listNumMax[3] > lineNotesNum[3]
                && notesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer < (long)ConstRepo.poorTiming)
            {
                if (notesDataList.notesList_3[lineNotesNum[3]].isPoison)
                {
                    notesJudge.PoisonNotesJudgement(
                        (long)Mathf.Abs(notesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer), 3);
                }
                else
                {
                    notesJudge.NotesJudgement(
                        (long)Mathf.Abs(notesDataList.notesList_3[lineNotesNum[3]].time - MusicData.Timer), 3);
                }

                lineNotesNum[3]++;
            }
        }





        // スキルの発動処理---------------------------------------------------------------------------
        if(skillChargeRate.skillValue >= 100 && skillManager.IsCanUseSkill())
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(L_SkillUseInput_Key_D());
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(R_SkillUseInput_Key_D());
            }
        }
        //----------------------------------------------------------------------------------------------

    }


    /// <summary>
    /// 左からのスキル入力の発動関数
    /// </summary>
    /// <returns></returns>
    IEnumerator L_SkillUseInput_Key_D()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);


        // 値の初期化
        _inputWaitTime_L[0] = 0;


        while (_inputStandbyTime >= _inputWaitTime_L[0])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine( L_SkillUseInput_Key_F());
                _inputWaitTime_L[0] = _inputStandbyTime;
            }
            else if (Input.anyKeyDown)
            {
                _inputWaitTime_L[0] = _inputStandbyTime;
            }

            _inputWaitTime_L[0] += Time.deltaTime;
        }
    }



    IEnumerator L_SkillUseInput_Key_F()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);

        // 値の初期化
        _inputWaitTime_L[1] = 0;


        while (_inputStandbyTime >= _inputWaitTime_L[1])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.F))
            {
                // スキルの使用
                skillChargeRate.UseSkill_Text();
                skillManager.UseSkill_Logic();

                _inputWaitTime_L[1] = _inputStandbyTime;
            }
            else if (Input.anyKeyDown)
            {
                _inputWaitTime_L[1] = _inputStandbyTime;
            }
            _inputWaitTime_L[1] += Time.deltaTime;
        }
    }



    /// <summary>
    /// 右からのスキル入力の発動関数
    /// </summary>
    /// <returns></returns>
    IEnumerator R_SkillUseInput_Key_D()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);

        // 値の初期化
        _inputWaitTime_R[0] = 0;


        while (_inputStandbyTime >= _inputWaitTime_R[0])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(R_SkillUseInput_Key_S());
                _inputWaitTime_R[0] = _inputStandbyTime;
            }
            else if (Input.anyKeyDown)
            {
                _inputWaitTime_R[0] = _inputStandbyTime;
            }

            _inputWaitTime_R[0] += Time.deltaTime;
        }
    }
    IEnumerator R_SkillUseInput_Key_S()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);

        // 値の初期化
        _inputWaitTime_R[1] = 0;


        while (_inputStandbyTime >= _inputWaitTime_R[1])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.S))
            {
                // スキルの使用
                skillChargeRate.UseSkill_Text();
                skillManager.UseSkill_Logic();

                _inputWaitTime_R[1] = _inputStandbyTime;
            }
            else if (Input.anyKeyDown)
            {
                _inputWaitTime_R[1] = _inputStandbyTime;
            }
            _inputWaitTime_R[1] += Time.deltaTime;
        }
    }
}
