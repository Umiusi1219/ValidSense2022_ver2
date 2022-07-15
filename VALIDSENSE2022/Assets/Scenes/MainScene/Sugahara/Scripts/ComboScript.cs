using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour
{
    /// <summary>
    /// �R���{���\�L�p
    /// </summary>
    Text text;

    /// <summary>
    /// �R���{��
    /// </summary>
    public int comboValue;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        _ComboValueUpdate();
    }


    /// <summary>
    /// �R���{�������Z
    /// </summary>
    public void AddComboValue()
    {
        comboValue++;

        _ComboValueUpdate();
    }

    /// <summary>
    /// �R���{�������Z�b�g
    /// </summary>
    public void ComboReset()
    {
        comboValue = 0;

        _ComboValueUpdate();
    }

    //�R���{���̕\�L�p
    private void _ComboValueUpdate()
    {
        text.text = comboValue.ToString();
    }
}
