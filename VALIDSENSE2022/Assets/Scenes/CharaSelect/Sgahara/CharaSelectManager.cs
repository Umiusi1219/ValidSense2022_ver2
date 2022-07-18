using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSelectManager : MonoBehaviour
{
    /// <summary>
    /// �V�[���}�l�[�W���[�Q�Ƃ���p
    /// </summary>
    [SerializeField]
    GameObject sceneManager;

    /// <summary>
    /// �L������UI�Ȃǈꊇ�ł�����p
    /// </summary>
    [SerializeField]
    List<CharaSelect_CahraClass> charaClassList;


    /// <summary>
    /// �L�����̃A�C�R�����Q�Ƃ���p
    /// </summary>
    [SerializeField]
    List<RawImage> charaIcon;

    /// <summary>
    /// �L�����̃A�C�R���̃L�����I����̉摜�f�[�^
    /// </summary>
    [SerializeField]
    List<Texture> charaIcon_Sprite;

    /// <summary>
    /// �J�[�\��
    /// </summary>
    [SerializeField]
    List<GameObject> cursor;

    /// <summary>
    /// �J�[�\���ړ��p��pos
    /// </summary>
    [SerializeField]
    private float[] cursorPosY;

    /// <summary>
    /// �v���C���[�̓��͂ɑΉ����đ�������l
    /// </summary>
    [SerializeField]
    private int[] cursorNum;

    /// <summary>
    /// �J�[�\�����ړ��\��
    /// </summary>
    [SerializeField]
    private bool[] canMoveCursor;

    [SerializeField]
    private float toNextSceneTiem;


    void Start()
    {
        //�����\��
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
        // �L�������肵�ĂȂ�������A1p�̃J�[�\���ړ�
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

        // �L�������肵�ĂȂ�������A2p�̃J�[�\���ړ�
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


        //2P���L���������肵�Ă��āA���̏�L��������肵�Ă�����L��������s��
        if (!canMoveCursor[(int)ConstRepo.Player.P2] &&
            cursorNum[(int)ConstRepo.Player.P1] == cursorNum[(int)ConstRepo.Player.P2])
        {
        }
        //1P�L�����̌���
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            canMoveCursor[(int)ConstRepo.Player.P1] = false;

            charaIcon[cursorNum[(int)ConstRepo.Player.P1]].texture
                = charaIcon_Sprite[cursorNum[(int)ConstRepo.Player.P1]];
        }


        //1P���L���������肵�Ă��āA���̏�L��������肵�Ă�����L��������s��
        if (!canMoveCursor[(int)ConstRepo.Player.P1] &&
            cursorNum[(int)ConstRepo.Player.P1] == cursorNum[(int)ConstRepo.Player.P2])
        {
        }
        //2P�L�����̌���
        else if (Input.GetKeyDown(KeyCode.P))
        {
            canMoveCursor[(int)ConstRepo.Player.P2] = false;

            charaIcon[cursorNum[(int)ConstRepo.Player.P2]].texture
                = charaIcon_Sprite[cursorNum[(int)ConstRepo.Player.P2]];
        }

        //1p2p���L������I��������MusicSelect�ɑJ��
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
