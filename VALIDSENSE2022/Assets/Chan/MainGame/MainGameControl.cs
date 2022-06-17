using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameControl : MonoBehaviour
{
    public Text text;
    private bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        //MusicPlayer.instance.MusicPlay(0);   
    }

    // Update is called once per frame
    void Update()
    {
        // p�L�[����������Ȃ�criwear�Đ�����
        if(!isStart && Input.GetKeyDown(KeyCode.P))
        {
            MusicPlayer.instance.MusicPlay(0);   
            isStart = true;
        }

        // �Ȃ̍Đ����ԕ\�L���X�V m/s
        text.text = MusicData.Timer+ "ms";
    }
}
