using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private CriAtomEx.CueInfo[] SongcueInfoList;
    private CriAtomExPlayer SongPlayer;
    private CriAtomExAcb SongExAcb;
    private CriAtomExPlayback SongPlayback;
    public static MusicPlayer instance;
    public long PlayTime;
    public static int SongNum = 0;

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
        SongExAcb = CriAtom.GetAcb("BGM");
        SongcueInfoList = SongExAcb.GetCueInfoList();

        /* AtomExPlayerの生成 */
        SongPlayer = new CriAtomExPlayer(true); 
        
    }
    private void Update() 
    {
        PlayTime = SongPlayback.GetTime();
        MusicData.Timer = PlayTime;
    }
    public void MusicPlay(int num)
    {
        if(SongPlayer.GetStatus() == CriAtomExPlayer.Status.Playing) 
        {
            SongPlayer.Stop();
        }
        SongPlayer.SetCue(SongExAcb,SongcueInfoList[num].name); 
        SongPlayback = SongPlayer.Start();
    }

}
