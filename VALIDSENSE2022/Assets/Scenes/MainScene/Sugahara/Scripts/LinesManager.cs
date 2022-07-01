using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesManager : MonoBehaviour
{
    /// <summary>
    /// �L�������������Ă�q�ɎQ�Ɨp
    /// </summary>
    [SerializeField]
    TestChara testChara;

    /// <summary>
    /// Line�Q�Ɨp
    /// </summary>
    [SerializeField]
    List<GameObject> lines;


    /// <summary>
    /// Line�̐F�ύX���g�p����J���[�R�[�h�́A�z��
    /// </summary>
    public string[] charaColorCode;


    /// <summary>
    ///string�^�̃J���[�R�[�h��Color�ϊ��������̎󂯎���
    /// </summary>
    Color colorCode;


    /// <summary>
    /// ���ݏ������Ă��郉�C���̖{��(�z��p��0����v�Z)
    /// </summary>
    [Range(1, 6)]
    [SerializeField]
    private int _1pHaveLines;


    /// <summary>
    /// line�̓����x���w�肷��
    /// </summary>
    [Range(0f, 1.0f)]
    [SerializeField]
    private float _lineAlpha;


    /// <summary>
    /// �������C���̈�ԑ��葤�𑊎�̐F�ɕύX����
    /// </summary>
    /// <param name="opponentChara">�ΐ푊��̃L�����ԍ�</param>
    void LineIsStolen_1p(int opponentCharaNum)
    {
        //�z��Q�Ƃ�h��
        if(_1pHaveLines > 0 )
        {
            // Color�^�ւ̕ϊ����������color��Color�^�̐ԐF����������jout�L�[���[�h�ŎQ�Ɠn���ɂ���
            if (ColorUtility.TryParseHtmlString(charaColorCode[opponentCharaNum],
                out colorCode))
            {
                // �����x�̐ݒ�
                colorCode.a = _lineAlpha;

                // �������C���̈�ԑ��葤�𑊎�̐F�ɕύX����
                lines[_1pHaveLines].GetComponent<SpriteRenderer>().color = colorCode;

                // �������C�������Z
                _1pHaveLines--;
            }
        }
    }


    /// <summary>
    /// ����̏������C���̈�Ԏ������������̐F�ɕύX����
    /// </summary>
    /// <param name="opponentChara">�����̃L�����ԍ�</param>
    void LineIsStolen_2p(int myCharaNum)
    {
        //�z��Q�Ƃ�h��
        if (_1pHaveLines < 6)
        {
            // Color�^�ւ̕ϊ���������Ɓicolor��Color�^�̐ԐF����������jout�L�[���[�h�ŎQ�Ɠn���ɂ���
            if (ColorUtility.TryParseHtmlString(charaColorCode[myCharaNum],
                out colorCode))
            {

                // �������C�������Z
                _1pHaveLines++;

                // �����x�̐ݒ�
                colorCode.a = _lineAlpha;

                // ����̏������C���̈��1p����1p�̐F�ɕύX����
                lines[_1pHaveLines].GetComponent<SpriteRenderer>().color = colorCode;

            }
        }
    }

    /// <summary>
    /// �S���C�����D�F������
    /// </summary>
    void OllLineColorChange()
    {
        // �S���C���ɎQ��
        foreach (GameObject line in lines)
        {
            //�D�F�Ɏw��
            if (ColorUtility.TryParseHtmlString(charaColorCode[4],
                out colorCode))
            {
                // �����x�̐ݒ�
                colorCode.a = _lineAlpha;

                // �������C�����D�F�ɕύX����
                line.GetComponent<SpriteRenderer>().color = colorCode;
            }
        }
    }


    /// <summary>
    /// 1p2p�̃��C�����e�L�����J���[�ɕύX����
    /// </summary>
    void SetLineColor_1p2p()
    {
        //���[�������J��Ԃ�
        for(int i = 0; i < lines.Count; i++)
        {
            if(i <4)
            {
                //1P�̃J���[�R�[�h��colorCode�ɓ����
                ColorUtility.TryParseHtmlString(charaColorCode[testChara.count1P], out colorCode);

                // �����x�̐ݒ�
                colorCode.a = _lineAlpha;

                // ���C���̐F��ύX����
                lines[i].GetComponent<SpriteRenderer>().color = colorCode;

            }
            else
            {
                //2P�̃J���[�R�[�h��colorCode�ɓ����
                ColorUtility.TryParseHtmlString(charaColorCode[testChara.count2P], out colorCode);

                // �����x�̐ݒ�
                colorCode.a = _lineAlpha;

                // ���C���̐F��ύX����
                lines[i].GetComponent<SpriteRenderer>().color = colorCode;
            }
        }
    }


    private void Start()
    {
        // 1p2p�̃L�����ɍ��킹��Line�̐F��ς���
        SetLineColor_1p2p();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("1P�����C���Ƃ�ꂽ");

            LineIsStolen_1p(testChara.count2P);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("2P�����C���Ƃ�ꂽ");

            LineIsStolen_2p(testChara.count1P);
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("�S���C�����D�F��");

            OllLineColorChange();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("���C�������Z�b�g");
            SetLineColor_1p2p();

            _1pHaveLines = 3;
        }
    }
}
