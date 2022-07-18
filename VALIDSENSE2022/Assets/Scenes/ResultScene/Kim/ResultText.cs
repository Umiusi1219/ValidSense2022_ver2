using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManager;

    [SerializeField]
    int[] playerNum;

    private Text text;


    /*
�X�R�A
�Ȗ�
��ȎҖ�
��Փx

���Ő�
�D�������[��
�D��ꂽ���[��

�{�^���������ăX�L�b�v
     */


    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");

        text = gameObject.GetComponent<Text>();

        text.text =
            "�X�R�A�@" + sceneManager.GetComponent<PlayerManagerScript>().score[playerNum[0]] + "\n" +
            "�Ȗ��@" + "Chartreuse Green" + "\n" +
            "��ȎҖ��@" + "t+pazolite" + "\n" +
            "��Փx�@" + "6" + "\n" +
            "\n" +
            "���Ő��@" + sceneManager.GetComponent<PlayerManagerScript>().totalHitsNum[playerNum[0]] + "\n" +
            "�D�������[���@" + sceneManager.GetComponent<PlayerManagerScript>().stolenLane[playerNum[0]] + "\n" +
            "�D��ꂽ���[���@" + sceneManager.GetComponent<PlayerManagerScript>().stolenLane[playerNum[1]] + "\n" +
            "\n" +
            "�{�^���������ăX�L�b�v";
    }

}
