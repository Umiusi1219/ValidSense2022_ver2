using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSelectManager : MonoBehaviour
{
    /// <summary>
    /// シーンマネージャー参照する用
    /// </summary>
    [SerializeField]
    GameObject sceneManager;

    /// <summary>
    /// キャラのUIなど一括でいじる用
    /// </summary>
    [SerializeField]
    List<CharaSelect_CahraClass> charaClassList;


    /// <summary>
    /// キャラのアイコンを参照する用
    /// </summary>
    [SerializeField]
    List<RawImage> charaIcon;

    /// <summary>
    /// キャラのアイコンのキャラ選択後の画像データ
    /// </summary>
    [SerializeField]
    List<Texture> charaIcon_Sprite;

    /// <summary>
    /// カーソル
    /// </summary>
    [SerializeField]
    List<GameObject> cursor;

    /// <summary>
    /// カーソル移動用のpos
    /// </summary>
    [SerializeField]
    private float[] cursorPosY;

    /// <summary>
    /// プレイヤーの入力に対応して増減する値
    /// </summary>
    [SerializeField]
    private int[] cursorNum;

    /// <summary>
    /// カーソルが移動可能か
    /// </summary>
    [SerializeField]
    private bool[] canMoveCursor;

    [SerializeField]
    private float toNextSceneTiem;


    void Start()
    {
        //初期表示
        charaClassList[(int)ConstRepo.Player.P1]
            .CharaUI_1P_DisplaySwitching((int)ConstRepo.Chara.Sight);
        charaClassList[(int)ConstRepo.Player.P2]
            .CharaUI_1P_DisplaySwitching((int)ConstRepo.Chara.Sight);

        MoveCursor((int)ConstRepo.Player.P1);
        MoveCursor((int)ConstRepo.Player.P2);


        sceneManager = GameObject.Find("SceneManager");
    }


    void Update()
    {
        // キャラ決定してなかったら、1pのカーソル移動
        if (canMoveCursor[(int)ConstRepo.Player.P1])
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) ||
                Input.GetKeyDown(KeyCode.R))
            {
                ChangeCharacter((int)ConstRepo.Player.P1, -1);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.F))
            {
                ChangeCharacter((int)ConstRepo.Player.P1, 1);
            }
        }

        // キャラ決定してなかったら、2pのカーソル移動
        if (canMoveCursor[(int)ConstRepo.Player.P2])
        {
            if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.I) ||
                Input.GetKeyDown(KeyCode.U))
            {
                ChangeCharacter((int)ConstRepo.Player.P2, -1);
            }
            else if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.K) ||
                Input.GetKeyDown(KeyCode.J))
            {
                ChangeCharacter((int)ConstRepo.Player.P2, 1);
            }
        }


        //2Pがキャラを決定していて、その上キャラが被りしていたらキャラ決定不可
        if (!canMoveCursor[(int)ConstRepo.Player.P2] &&
            cursorNum[(int)ConstRepo.Player.P1] == cursorNum[(int)ConstRepo.Player.P2])
        {
        }
        //1Pキャラの決定
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            canMoveCursor[(int)ConstRepo.Player.P1] = false;

            charaIcon[cursorNum[(int)ConstRepo.Player.P1]].texture
                = charaIcon_Sprite[cursorNum[(int)ConstRepo.Player.P1]];
        }


        //1Pがキャラを決定していて、その上キャラが被りしていたらキャラ決定不可
        if (!canMoveCursor[(int)ConstRepo.Player.P1] &&
            cursorNum[(int)ConstRepo.Player.P1] == cursorNum[(int)ConstRepo.Player.P2])
        {
        }
        //2Pキャラの決定
        else if (Input.GetKeyDown(KeyCode.P))
        {
            canMoveCursor[(int)ConstRepo.Player.P2] = false;

            charaIcon[cursorNum[(int)ConstRepo.Player.P2]].texture
                = charaIcon_Sprite[cursorNum[(int)ConstRepo.Player.P2]];
        }

        //1p2pがキャラを選択したらMusicSelectに遷移
        if (!canMoveCursor[(int)ConstRepo.Player.P1] && !canMoveCursor[(int)ConstRepo.Player.P2])
        {
            StartCoroutine(ToMusicSelectScene());
        }
    }

    void MoveCursor(int player)
    {
        cursor[player].transform.position = new Vector3
            (cursor[player].transform.position.x,cursorPosY[cursorNum[player]], cursor[player].transform.position.z);
   
    }

    void ChangeCharacter(int player, int cursorNumFluctuation)
    {
        if (0 > cursorNumFluctuation)
        {
            if (cursorNum[player] == (int)ConstRepo.Chara.Sight)
            {
                cursorNum[player] = (int)ConstRepo.Chara.Hear;
            }
            else
            {
                cursorNum[player]--;

            }
        }
        else if (0 < cursorNumFluctuation)
        {
            if (cursorNum[player] == (int)ConstRepo.Chara.Hear)
            {
                cursorNum[player] = (int)ConstRepo.Chara.Sight;
            }
            else
            {
                cursorNum[player]++;
            }
        }

        charaClassList[player].
            CharaUI_1P_DisplaySwitching(cursorNum[player]);
        MoveCursor(player);
    }

    IEnumerator ToMusicSelectScene()
    {
        yield return new WaitForSeconds(toNextSceneTiem);

        sceneManager.GetComponent<PlayerManagerScript>().playerCharaNum = cursorNum;

        sceneManager.GetComponent<Test>().ToMusicSelectScene();
    }
}
