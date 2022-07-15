using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour
{
    /// <summary>
    /// コンボ数表記用
    /// </summary>
    Text text;

    /// <summary>
    /// コンボ数
    /// </summary>
    public int comboValue;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        _ComboValueUpdate();
    }


    /// <summary>
    /// コンボ数を加算
    /// </summary>
    public void AddComboValue()
    {
        comboValue++;

        _ComboValueUpdate();
    }

    /// <summary>
    /// コンボ数をリセット
    /// </summary>
    public void ComboReset()
    {
        comboValue = 0;

        _ComboValueUpdate();
    }

    //コンボ数の表記用
    private void _ComboValueUpdate()
    {
        text.text = comboValue.ToString();
    }
}
