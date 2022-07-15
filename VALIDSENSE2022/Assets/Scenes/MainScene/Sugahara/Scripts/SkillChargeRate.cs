using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChargeRate : MonoBehaviour
{
    // 自身のTextを管理するオブジェクト
    Text skillChargeText;

    [SerializeField]
    // スキルのチャージ率の値
    public int skillValue;

    // スキルのチャージ率の値の最大値
    [SerializeField]
    private int _skillValueMax;


    /// <summary>
    /// キャラをいじってる子に参照用
    /// </summary>
    [SerializeField]
    TestChara testChara;


    /// <summary>
    /// 色変更時使用するカラーコードの、配列
    /// </summary>
    public string[] charaColorCode;


    /// <summary>
    ///string型のカラーコードをColor変換した時の受け取り先
    /// </summary>
    Color colorCode;


    // Start is called before the first frame update
    void Start()
    {
        // 自分のTextを挿入
        skillChargeText = GetComponent<Text>();

        skillChargeTextUpdate();

        // Color型への変換成功するとcolorにColor型の赤色が代入される）outキーワードで参照渡しにする
        if (ColorUtility.TryParseHtmlString(charaColorCode[testChara.count1P],
            out colorCode))
        {
            // キャラにあった色に変更
            skillChargeText.color = colorCode;
        }
    }


    /// <summary>
    /// skillValueに引数を足す関数
    /// </summary>
    /// <param name="addValue">skillValueに足す値</param>
    public void AddSkillValue(int addValue)
    {
        // skillValue + addValue がMaxを越えなければ、そのまま足して、超えるのであれば
        // skillValue にMaxの値を入れる
        if (skillValue + addValue > _skillValueMax) 
        {
            skillValue = _skillValueMax;
        }
        else
        {
            //引数分足す
            skillValue += addValue;

        }

        //表示の更新
        skillChargeTextUpdate();
    }


    /// <summary>
    /// チャージ率の表記更新
    /// </summary>
    void skillChargeTextUpdate()
    {
        skillChargeText.text = skillValue.ToString() + "%";
    }

    /// <summary>
    /// スキルを使用した時の処理
    /// </summary>
    public void UseSkill_Text()
    {
        //スキル使用時の消費量分引く
        skillValue -= 100;

        skillChargeTextUpdate();
    }
}
