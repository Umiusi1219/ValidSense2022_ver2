using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Title,
    CharaSelect,
    MusicSelect,
    Playing,
    Result
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private GameState currentGameState;

    private void Awake()
    {   

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged (currentGameState);
    }

    void OnGameStateChanged(GameState state)
    {
        switch(state)
        {
            case GameState.Title:
                break;
            case GameState.CharaSelect:
                break;
            case GameState.MusicSelect:
                break;
            case GameState.Playing:
                break;
            case GameState.Result:
                break;
            default:
                break;
        }
    }
}
