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

    [SerializeField]
    List<ScoreScript> score;

    [SerializeField]
    LinesManager linesManager;

    public bool notMusicEnd = true;

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
        MusicEndCheck();
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
    public void MusicEndCheck()
    {
        if (SongPlayer.GetStatus() == CriAtomExPlayer.Status.PlayEnd)
        {
            if (notMusicEnd)
            {
                notMusicEnd = false;

                score[0].SetScores();
                score[1].SetScores();

                StartCoroutine(linesManager.LineJudgmentPerformance());

                StartCoroutine(ToNextScene());
            }

        }
    }

    IEnumerator ToNextScene()
    {
        yield return new WaitForSeconds(8f);

        if (score[0].scoreValue >= score[1].scoreValue)
        {

            GameObject.Find("SceneManager").SendMessage("SetScene", GameScene.Result_1P);
        }
        else
        {
            GameObject.Find("SceneManager").SendMessage("SetScene", GameScene.Result_2P);
        }
    }

}
