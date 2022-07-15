using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChargeRate : MonoBehaviour
{
    // ���g��Text���Ǘ�����I�u�W�F�N�g
    Text skillChargeText;

    [SerializeField]
    // �X�L���̃`���[�W���̒l
    public int skillValue;

    // �X�L���̃`���[�W���̒l�̍ő�l
    [SerializeField]
    private int _skillValueMax;


    /// <summary>
    /// �L�������������Ă�q�ɎQ�Ɨp
    /// </summary>
    [SerializeField]
    TestChara testChara;


    /// <summary>
    /// �F�ύX���g�p����J���[�R�[�h�́A�z��
    /// </summary>
    public string[] charaColorCode;


    /// <summary>
    ///string�^�̃J���[�R�[�h��Color�ϊ��������̎󂯎���
    /// </summary>
    Color colorCode;


    // Start is called before the first frame update
    void Start()
    {
        // ������Text��}��
        skillChargeText = GetComponent<Text>();

        skillChargeTextUpdate();

        // Color�^�ւ̕ϊ����������color��Color�^�̐ԐF����������jout�L�[���[�h�ŎQ�Ɠn���ɂ���
        if (ColorUtility.TryParseHtmlString(charaColorCode[testChara.count1P],
            out colorCode))
        {
            // �L�����ɂ������F�ɕύX
            skillChargeText.color = colorCode;
        }
    }


    /// <summary>
    /// skillValue�Ɉ����𑫂��֐�
    /// </summary>
    /// <param name="addValue">skillValue�ɑ����l</param>
    public void AddSkillValue(int addValue)
    {
        // skillValue + addValue ��Max���z���Ȃ���΁A���̂܂ܑ����āA������̂ł����
        // skillValue ��Max�̒l������
        if (skillValue + addValue > _skillValueMax) 
        {
            skillValue = _skillValueMax;
        }
        else
        {
            //����������
            skillValue += addValue;

        }

        //�\���̍X�V
        skillChargeTextUpdate();
    }


    /// <summary>
    /// �`���[�W���̕\�L�X�V
    /// </summary>
    void skillChargeTextUpdate()
    {
        skillChargeText.text = skillValue.ToString() + "%";
    }

    /// <summary>
    /// �X�L�����g�p�������̏���
    /// </summary>
    public void UseSkill_Text()
    {
        //�X�L���g�p���̏���ʕ�����
        skillValue -= 100;

        skillChargeTextUpdate();
    }
}
