using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    [SerializeField]
    private int _playerNum;

    public Text Result_Text;
    // Start is called before the first frame update
    void Start()
    {
        Result_Text.text = "�X�R�A :" + PlayerManagerScript.score[_playerNum] + " \n"
            + "�Ȗ� : " + PlayerManagerScript.nowMusicNum[_playerNum] + "\n"
            + "��Փx : " + PlayerManagerScript.nowMusicLevel[_playerNum] + "\n"
            + "\n"
            + "���Ő� : " + PlayerManagerScript.totalHitsNum[_playerNum] + "\n"
            + "�D�������[���� : " + PlayerManagerScript.stolenLane[_playerNum] + "\n"
            + "�D��ꂽ���[����" + PlayerManagerScript.losLanes[_playerNum] + "\n"
            + "\n"
            + "V�{�^���ŃX�L�b�v"
            + "\n";

    }
}
