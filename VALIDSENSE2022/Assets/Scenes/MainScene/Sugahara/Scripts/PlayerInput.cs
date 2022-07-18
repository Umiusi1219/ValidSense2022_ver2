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
    List <SkillChargeRate> skillChargeRate;


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
    private float[] _inputWaitTime_R_1P;

    /// <summary>
    /// スキルの発動時にキー入力してからどれくらい時間が経過してるか記憶用(左からの入力)
    /// </summary>
    [SerializeField]
    private float[] _inputWaitTime_L_1P;


    /// <summary>
    /// スキルの発動時にキー入力してからどれくらい時間が経過してるか記憶用(右からの入力)
    /// </summary>
    [SerializeField]
    private float[] _inputWaitTime_R_2P;

    /// <summary>
    /// スキルの発動時にキー入力してからどれくらい時間が経過してるか記憶用(左からの入力)
    /// </summary>
    [SerializeField]
    private float[] _inputWaitTime_L_2P;




    void Update()
    {
        //        //判定バーデバック用(判定バー到達予定時間に任意エラーにて強制停止)
        //        if (MusicData.Timer >= notesDataList.notesLists[0].notesList[lineNotesNum[0]].time)
        //        {
        //            Debug.Log("Timer" + MusicData.Timer);
        //            Debug.Log("Judge" + notesDataList.notesLists[0].notesList[lineNotesNum[0]].time);

        //            Debug.Log("差" + (MusicData.Timer - notesDataList.notesLists[0].notesList[lineNotesNum[0]].time));

        //#if UNITY_EDITOR
        //            UnityEditor.EditorApplication.isPaused = true;
        //#endif
        //        }


        // 1P SE---------------------------------------------------------------------------------------------
        if(Input.GetKeyDown(KeyCode.Q))
        {
            // タンバリン
            SEPlayer.instance.SEOneShot(0);
        }


        // wに対応するラインが奪われてなかったらWキーで判定
        if (linesManager.Get_1pHaveLines() >= 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }
        // wに対応するラインが奪われていたらSキーで判定
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }

        // Eに対応するラインが奪われてなかったらEキーで判定
        if (linesManager.Get_1pHaveLines() >= 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }
        // Eに対応するラインが奪われていたらDキーで判定
        else
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }

        // Rに対応するラインが奪われてなかったらRキーで判定
        if (linesManager.Get_1pHaveLines() >= 3)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }
        // Rに対応するラインが奪われていたらFキーで判定
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }
        // -------------------------------------------------------------------------------------------------


        // 2P SE---------------------------------------------------------------------------------------------

        // Pキーを押したとき
        if (Input.GetKeyDown(KeyCode.P))
        {
            // タンバリン
            SEPlayer.instance.SEOneShot(0);
        }

        // oに対応するラインが奪われてなかったらoキーで判定
        if (linesManager.Get_1pHaveLines() <= 6)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }
        // oに対応するラインが奪われていたらLキーで判定
        else
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }

        // Iに対応するラインが奪われてなかったらIキーで判定
        if (linesManager.Get_1pHaveLines() <= 5)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }
        // Iに対応するラインが奪われていたらKキーで判定
        else
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }

        // Uに対応するラインが奪われてなかったらUキーで判定
        if (linesManager.Get_1pHaveLines() <= 4)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }
        // Rに対応するラインが奪われていたらFキーで判定
        else
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                // タンバリン
                SEPlayer.instance.SEOneShot(0);
            }
        }
        //--------------------------------------------------------------------------------------------------


        // 1p 入力----------------------------------------------------------------------------------
        // 配列の総数を超えて配列参照しないようにする制御
        if (notesDataList.listNumMax[0] > lineNotesNum[0])
        {
            // Qキーを押したとき
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // 引数のラインのノーツチェック
                NotesListsCheck(0,0);
            }
            // poor判定の自動化
            NotesListsPoorCheck(0, 0);
        }

        // 上のラインが違う番-------------------------------------------------------------------------
        if (notesDataList.listNumMax[1] > lineNotesNum[1])
        {
            // wに対応するラインが奪われてなかったらWキーで判定
            if (linesManager.Get_1pHaveLines() >= 1)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(1, 0);
                }
            }
            // wに対応するラインが奪われていたらSキーで判定
            else
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(1, 0);
                }
            }

            // poor判定の自動化
            NotesListsPoorCheck(1, 0);
        }

        // 上のラインが違う番--------------------------------------------------------------------------
        if (notesDataList.listNumMax[2] > lineNotesNum[2])
        {
            // Eに対応するラインが奪われてなかったらEキーで判定
            if (linesManager.Get_1pHaveLines() >= 2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(2, 0);
                }
            }
            // Eに対応するラインが奪われていたらDキーで判定
            else
            {
                if (Input.GetKeyDown(KeyCode.D))
                {

                    // 引数のラインのノーツチェック
                    NotesListsCheck(2, 0);
                }
            }
            // poor判定の自動化
            NotesListsPoorCheck(2, 0);
        }

        // 上のラインが違う番-------------------------------------------------------------------
        if (notesDataList.listNumMax[3] > lineNotesNum[3])
        {
            // Rに対応するラインが奪われてなかったらRキーで判定
            if (linesManager.Get_1pHaveLines() >= 3)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(3, 0);

                }
            }
            // Rに対応するラインが奪われていたらFキーで判定
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(3, 0);
                }
            }


            // poor判定の自動化
            NotesListsPoorCheck(3, 0);
        }//-----------------------------------------------------------------------------------------



        // 2p 入力----------------------------------------------------------------------------------
        // 配列の総数を超えて配列参照しないようにする制御
        if (notesDataList.listNumMax[7] > lineNotesNum[7])
        {
            // Pキーを押したとき
            if (Input.GetKeyDown(KeyCode.P))
            {
                // 引数のラインのノーツチェック
                NotesListsCheck(7, 1);
            }
            // poor判定の自動化
            NotesListsPoorCheck(7, 1);
        }

        // 上のラインが違う番-------------------------------------------------------------------------
        if (notesDataList.listNumMax[6] > lineNotesNum[6])
        {
            // oに対応するラインが奪われてなかったらoキーで判定
            if (linesManager.Get_1pHaveLines() <= 6)
            {
                if (Input.GetKeyDown(KeyCode.O))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(6, 1);
                }
            }
            // oに対応するラインが奪われていたらLキーで判定
            else
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(6, 1);
                }
            }

            // poor判定の自動化
            NotesListsPoorCheck(6, 1);
        }

        // 上のラインが違う番--------------------------------------------------------------------------
        if (notesDataList.listNumMax[2] > lineNotesNum[2])
        {
            // Iに対応するラインが奪われてなかったらIキーで判定
            if (linesManager.Get_1pHaveLines() <= 5)
            {
                if (Input.GetKeyDown(KeyCode.I))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(5, 1);
                }
            }
            // Iに対応するラインが奪われていたらKキーで判定
            else
            {
                if (Input.GetKeyDown(KeyCode.K))
                {

                    // 引数のラインのノーツチェック
                    NotesListsCheck(5, 1);
                }
            }
            // poor判定の自動化
            NotesListsPoorCheck(5, 1);
        }

        // 上のラインが違う番-------------------------------------------------------------------
        if (notesDataList.listNumMax[4] > lineNotesNum[4])
        {
            // Uに対応するラインが奪われてなかったらUキーで判定
            if (linesManager.Get_1pHaveLines() <= 4)
            {
                if (Input.GetKeyDown(KeyCode.U))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(4, 1);

                }
            }
            // Rに対応するラインが奪われていたらFキーで判定
            else
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    // 引数のラインのノーツチェック
                    NotesListsCheck(4, 1);
                }
            }


            // poor判定の自動化
            NotesListsPoorCheck(4, 1);
        }//-----------------------------------------------------------------------------------------





        // 1Pスキルの発動処理---------------------------------------------------------------------------
        if (skillChargeRate[0].skillValue >= 100 && skillManager.IsCanUseSkill())
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(L_SkillUseInput_Key_D());
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(R_SkillUseInput_Key_D());
            }
        }


        // 2Pスキルの発動処理---------------------------------------------------------------------------
        if (skillChargeRate[1].skillValue >= 100 && skillManager.IsCanUseSkill())
        
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                StartCoroutine(L_SkillUseInput_Key_K());
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                StartCoroutine(R_SkillUseInput_Key_K());
            }
        }
        //----------------------------------------------------------------------------------------------

    }


    /// <summary>
    /// poor判定かチェック用
    /// </summary>
    /// <param name="line">どのラインのノーツを判定するか指定用</param>
    void NotesListsPoorCheck(int line, int usePlayer)
    {
        // 判定バー到達予定時間 - criwearの時間 < poorTimingなら実行
        if (notesDataList.listNumMax[line] > lineNotesNum[line]
                && notesDataList.notesLists[line].notesList[lineNotesNum[line]].time
                - MusicData.Timer < (long)ConstRepo.poorTiming)
        {

            // ノーツがポイズンノーツかそうじゃないかで、判定を変える
            if (notesDataList.notesLists[line].notesList[lineNotesNum[line]].isPoison)
            {
                // 判定用関数で、毒ノーツの判定をする
                notesJudge.PoisonNotesJudgement(
                    // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                    (long)Mathf.Abs(notesDataList.notesLists[line].
                    notesList[lineNotesNum[line]].time - MusicData.Timer), line, usePlayer);
            }
            else
            {
                // 判定用関数で、ノーマルノーツの判定をする
                notesJudge.NotesJudgement(
                    // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                    (long)Mathf.Abs(notesDataList.notesLists[line].
                    notesList[lineNotesNum[line]].time - MusicData.Timer), line, usePlayer);
            }


            //干渉するノーツを次にする
            lineNotesNum[line]++;
        }
    }


    /// <summary>
    /// ノーツの判定チェック、判定してもよい場所なら、判定
    /// </summary>
    /// <param name="line">どのラインのノーツを判定するか指定用</param>
    void NotesListsCheck(int line , int usePlayer)
    {
        // criwearの時間 - 判定バー到達予定時間 < judgeTimeなら実行
        if (notesDataList.notesLists[line].notesList[lineNotesNum[line]].time - MusicData.Timer < judgeTime)
        {
            // ノーツがポイズンノーツかそうじゃないかで、判定を変える
            if (notesDataList.notesLists[line].notesList[lineNotesNum[line]].isPoison)
            {
                // 判定用関数で、ポイズンノーツの判定をする
                notesJudge.PoisonNotesJudgement(
                    // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                    (long)Mathf.Abs(notesDataList.notesLists[line].
                    notesList[lineNotesNum[line]].time - MusicData.Timer), line, usePlayer);
            }
            else
            {
                // 判定用関数で、ノーマルノーツの判定をする
                notesJudge.NotesJudgement(
                    // criwearの時間 - 判定バー到達予定時間 を絶対値化して引数に設定
                    (long)Mathf.Abs(notesDataList.notesLists[line].
                    notesList[lineNotesNum[line]].time - MusicData.Timer), line, usePlayer);
            }


            //干渉するノーツを次にする
            lineNotesNum[line]++;
        }
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
        _inputWaitTime_L_1P[0] = 0;


        while (_inputStandbyTime >= _inputWaitTime_L_1P[0])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(L_SkillUseInput_Key_F());
                _inputWaitTime_L_1P[0] = _inputStandbyTime;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E)
                || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.F))
            {
                _inputWaitTime_L_1P[0] = _inputStandbyTime;
            }

            _inputWaitTime_L_1P[0] += Time.deltaTime;
        }
    }



    IEnumerator L_SkillUseInput_Key_F()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);

        // 値の初期化
        _inputWaitTime_L_1P[1] = 0;


        while (_inputStandbyTime >= _inputWaitTime_L_1P[1])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.F))
            {
                // スキルの使用
                skillChargeRate[0].UseSkill_Text();
                skillManager.UseSkill_Logic((int)ConstRepo.Player.P2);

                _inputWaitTime_L_1P[1] = _inputStandbyTime;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E)
                || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                _inputWaitTime_L_1P[1] = _inputStandbyTime;
            }
            _inputWaitTime_L_1P[1] += Time.deltaTime;
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
        _inputWaitTime_R_1P[0] = 0;


        while (_inputStandbyTime >= _inputWaitTime_R_1P[0])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(R_SkillUseInput_Key_S());
                _inputWaitTime_R_1P[0] = _inputStandbyTime;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E)
                || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.S))
            {
                _inputWaitTime_R_1P[0] = _inputStandbyTime;
            }

            _inputWaitTime_R_1P[0] += Time.deltaTime;
        }
    }
    IEnumerator R_SkillUseInput_Key_S()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);

        // 値の初期化
        _inputWaitTime_R_1P[1] = 0;


        while (_inputStandbyTime >= _inputWaitTime_R_1P[1])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.S))
            {
                // スキルの使用
                skillChargeRate[0].UseSkill_Text();
                skillManager.UseSkill_Logic((int)ConstRepo.Player.P2);

                _inputWaitTime_R_1P[1] = _inputStandbyTime;
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E)
                || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.D))
            {
                _inputWaitTime_R_1P[1] = _inputStandbyTime;
            }
            _inputWaitTime_R_1P[1] += Time.deltaTime;
        }
    }





































    //2p-----------------------------------------------------------------------------------------------------------
    /// <summary>
    /// 左からのスキル入力の発動関数
    /// </summary>
    /// <returns></returns>
    IEnumerator L_SkillUseInput_Key_K()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);


        // 値の初期化
        _inputWaitTime_L_2P[0] = 0;


        while (_inputStandbyTime >= _inputWaitTime_L_2P[0])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.K))
            {
                StartCoroutine(L_SkillUseInput_Key_L());
                _inputWaitTime_L_2P[0] = _inputStandbyTime;
            }
            else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.I)
                 || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L))
                {
                _inputWaitTime_L_2P[0] = _inputStandbyTime;
            }

            _inputWaitTime_L_2P[0] += Time.deltaTime;
        }
    }



    IEnumerator L_SkillUseInput_Key_L()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);

        // 値の初期化
        _inputWaitTime_L_2P[1] = 0;


        while (_inputStandbyTime >= _inputWaitTime_L_2P[1])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.L))
            {
                // スキルの使用
                skillChargeRate[1].UseSkill_Text();
                skillManager.UseSkill_Logic((int)ConstRepo.Player.P2);

                _inputWaitTime_L_2P[1] = _inputStandbyTime;
            }
            else if (Input.GetKeyDown(KeyCode.P)|| Input.GetKeyDown(KeyCode.O)|| Input.GetKeyDown(KeyCode.I)
                 || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.J)||Input.GetKeyDown(KeyCode.K))
            {
                _inputWaitTime_L_2P[1] = _inputStandbyTime;
            }
            _inputWaitTime_L_2P[1] += Time.deltaTime;
        }
    }



    /// <summary>
    /// 右からのスキル入力の発動関数
    /// </summary>
    /// <returns></returns>
    IEnumerator R_SkillUseInput_Key_K()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);

        // 値の初期化
        _inputWaitTime_R_2P[0] = 0;


        while (_inputStandbyTime >= _inputWaitTime_R_2P[0])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.K))
            {
                StartCoroutine(R_SkillUseInput_Key_J());
                _inputWaitTime_R_2P[0] = _inputStandbyTime;
            }
            else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.I)
            || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
            {
                _inputWaitTime_R_2P[0] = _inputStandbyTime;
            }

            _inputWaitTime_R_2P[0] += Time.deltaTime;
        }
    }
    IEnumerator R_SkillUseInput_Key_J()
    {
        // 同時押しでの誤作動をしないようにする時間
        yield return new WaitForSeconds(_inputInvalidTime);

        // 値の初期化
        _inputWaitTime_R_2P[1] = 0;


        while (_inputStandbyTime >= _inputWaitTime_R_2P[1])
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.J))
            {
                // スキルの使用
                skillChargeRate[1].UseSkill_Text();
                skillManager.UseSkill_Logic((int)ConstRepo.Player.P2);

                _inputWaitTime_R_2P[1] = _inputStandbyTime;
            }
            else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.I)
                || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.K))
            {
                _inputWaitTime_R_2P[1] = _inputStandbyTime;
            }
            _inputWaitTime_R_2P[1] += Time.deltaTime;
        }
    }
    //-----------------------------------------------------------------------------------------------------------
}
