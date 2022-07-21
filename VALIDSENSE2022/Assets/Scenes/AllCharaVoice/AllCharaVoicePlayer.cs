using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCharaVoicePlayer : MonoBehaviour
{
    [SerializeField]
    List<CharaVoiceOnlyClass> charaVoices;

    public void OnShot_CharaVoice(int charaNum, int voiceNum)
    {
        charaVoices[charaNum].VoiceOneShot(voiceNum);
    }

}
