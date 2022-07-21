using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleMp4BG : MonoBehaviour
{
    [SerializeField]
    PlayerManagerScript playerManagerScript;


    [SerializeField]
    string[] charaColorCode;

    Color colorCode;


    // Start is called before the first frame update
    void Start()
    {
        playerManagerScript = GameObject.Find("SceneManager").GetComponent<PlayerManagerScript>();


        // �O��̏����L�����̐F�Ƀ^�C�g����mp4��ς���
        if (ColorUtility.TryParseHtmlString(charaColorCode[playerManagerScript.winCharaNum],
            out colorCode))
        {

            // �������C���̈��2p���𑊎�̐F�ɕύX����
            gameObject.GetComponent<RawImage>().color = colorCode;
        }
    }


}
