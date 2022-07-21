using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_PlayerInput : MonoBehaviour
{
    [SerializeField]
    GameObject sceneManagerTest;

    [SerializeField]
    AllCharaVoicePlayer allVoicePlayer;


    [SerializeField]
    private float _toNextScene;

    [SerializeField]
    private float voiceStandbyTime;

    bool _canGetKey = true;

    bool _canToNextScene = false;


    private void Start()
    {
        sceneManagerTest = GameObject.Find("SceneManager");

        StartCoroutine(VoicePlay());

        Invoke("CanNextScene", 3 + voiceStandbyTime);
        //MainBGMPlayer.instance.MusicPlay(0);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !Input.GetMouseButtonDown(0) && _canGetKey && _canToNextScene)
        {
            _canGetKey = false;

            SEPlayer.instance.SEOneShot(6);
            MainBGMPlayer.instance.StopPlayer();
            Invoke("ToNextScene", _toNextScene);
        }
    }


    void ToNextScene()
    {
        

        sceneManagerTest.GetComponent<Test>().ToCharaSelectScene();
    }


    void CanNextScene()
    {
        _canToNextScene = true;

    }


    IEnumerator VoicePlay ()
    {
        yield return  new WaitForSeconds(voiceStandbyTime);
        //勝利キャラのウェルカムボイスを再生
        allVoicePlayer.OnShot_CharaVoice(
        sceneManagerTest.GetComponent<PlayerManagerScript>().winCharaNum, 6);
    }
}
