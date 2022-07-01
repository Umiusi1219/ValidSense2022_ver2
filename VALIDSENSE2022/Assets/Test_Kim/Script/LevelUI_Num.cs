using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUI_Num : MonoBehaviour
{
    [SerializeField]
    private Text NormalLevelNum;

    public int HogeNum_1;

    [SerializeField]
    private Text HighLevelNum;

    public int HogeNum_2;

    [SerializeField]
    private Text SixthLevelNum;

    public int HogeNum_3;

    [SerializeField]
    private int LevelUI_Pos;

    [SerializeField]
    private GameObject NormalLevelUI;

    [SerializeField]
    private GameObject HighLevelUI;

    [SerializeField]
    private GameObject SixthLevelUI;

    // Start is called before the first frame update
    void Start()
    {
        NormalLevelNum.text = HogeNum_1.ToString();
        HighLevelNum.text = HogeNum_2.ToString();
        SixthLevelNum.text = HogeNum_3.ToString();

        if(HogeNum_1 < 10)
        {
            NormalLevelUI.transform.position = new Vector3(NormalLevelNum.transform.position.x + LevelUI_Pos, NormalLevelNum.transform.position.y, NormalLevelNum.transform.position.z);
        }
        else if(HogeNum_1 >= 10)
        {
            NormalLevelUI.transform.position = new Vector3(NormalLevelNum.transform.position.x + (LevelUI_Pos + 7), NormalLevelNum.transform.position.y, NormalLevelNum.transform.position.z);
        }

        if (HogeNum_2 < 10)
        {
            HighLevelUI.transform.position = new Vector3(HighLevelNum.transform.position.x + LevelUI_Pos, HighLevelNum.transform.position.y, HighLevelNum.transform.position.z);
        }
        else if (HogeNum_2 >= 10)
        {
            HighLevelUI.transform.position = new Vector3(HighLevelNum.transform.position.x + (LevelUI_Pos + 7), HighLevelNum.transform.position.y, HighLevelNum.transform.position.z);
        }

        if (HogeNum_3 < 10)
        {
            SixthLevelUI.transform.position = new Vector3(SixthLevelNum.transform.position.x + LevelUI_Pos, SixthLevelNum.transform.position.y, SixthLevelNum.transform.position.z);
        }
        else if (HogeNum_3 >= 10)
        {
            SixthLevelUI.transform.position = new Vector3(SixthLevelNum.transform.position.x + (LevelUI_Pos + 7), SixthLevelNum.transform.position.y, SixthLevelNum.transform.position.z);
        }
    }

}
