using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainBGMPlayer : MonoBehaviour
{
    private CriAtomEx.CueInfo[] SongcueInfoList;
    private CriAtomExPlayer SongPlayer;
    private CriAtomExAcb SongExAcb;

    public static MainBGMPlayer instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    IEnumerator Start()
    {
        /* �L���[�V�[�g�t�@�C���̃��[�h�҂� */
        while (CriAtom.CueSheetsAreLoading) { yield return null; }
        /* Cue���̎擾 */
        SongExAcb = CriAtom.GetAcb("TitleCue");
        SongcueInfoList = SongExAcb.GetCueInfoList();
        /* AtomExPlayer�̐��� */
        SongPlayer = new CriAtomExPlayer();
        
        
        if(SceneManager.GetActiveScene().name == "CharaSelect")
            MusicPlay(0);
        else if(SceneManager.GetActiveScene().name == "Title")
            MusicPlay(1);
    }

    public void MusicPlay(int num)
    {
        if (SongPlayer.GetStatus() == CriAtomExPlayer.Status.Playing)
        {
            SongPlayer.Stop();
        }
        SongPlayer.SetCue(SongExAcb, SongcueInfoList[num].name);
        SongPlayer.Start();
    }

    public void StopPlayer()
    {
        SongPlayer.Stop();
    }

}
