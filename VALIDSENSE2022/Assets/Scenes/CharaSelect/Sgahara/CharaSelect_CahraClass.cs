using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSelect_CahraClass : MonoBehaviour
{
    /// <summary>
    /// Live2D���i�[�p
    /// </summary>
    [SerializeField]
    List<GameObject> charaLive2D;

    [SerializeField]
    List<GameObject> chara_Name;

    [SerializeField]
    List<GameObject> chara_Name_2;

    [SerializeField]
    List<GameObject> chara_Name_Symbols;


    /// <summary>
    /// �����ȊO��charaClassList�̔�\���ɂ��āA�����̂́A�\������
    /// </summary>
    /// <param name="showNum"></param>
    public void CharaUI_1P_DisplaySwitching(int showNum)
    {
        for (int i = 0; i < charaLive2D.Count;)
        {
            if (i == showNum)
            {
                charaLive2D[i].SetActive(true);
                chara_Name[i].SetActive(true);
                chara_Name_2[i].SetActive(true);
                chara_Name_Symbols[i].SetActive(true);
            }
            else
            {
                charaLive2D[i].SetActive(false);
                chara_Name[i].SetActive(false);
                chara_Name_2[i].SetActive(false);
                chara_Name_Symbols[i].SetActive(false);
            }

            i++;
        }
    }
}
