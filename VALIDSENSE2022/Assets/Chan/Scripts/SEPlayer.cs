using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    private CriAtomEx.CueInfo[] SEcueInfoList;
    private CriAtomExPlayer SEExPlayer;
    private CriAtomExAcb SEExAcb;
    private CriAtomExPlayback SEPlayback;
    public static SEPlayer instance;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    IEnumerator Start()
    {
        /* キューシートファイルのロード待ち */
        while (CriAtom.CueSheetsAreLoading) { yield return null; }
        /* Cue情報の取得 */
        SEExAcb = CriAtom.GetAcb("SECue");
        SEcueInfoList = SEExAcb.GetCueInfoList();

        /* AtomExPlayerの生成 */
        SEExPlayer = new CriAtomExPlayer();    
        
    }
    public void SETap(int SEtype)
    {
        SEExPlayer.SetCue(SEExAcb,SEcueInfoList[SEtype].name);
        SEPlayback = SEExPlayer.Start();
    }
    public void SETap2()
    {
        SEExPlayer.SetCue(SEExAcb,SEcueInfoList[1].name);
        SEPlayback = SEExPlayer.Start();
    }
    public void SEHold()
    {
        SEExPlayer.SetCue(SEExAcb,SEcueInfoList[2].name);
        SEPlayback = SEExPlayer.Start();
    }
}
