using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameScene
{
    Title,
    CharaSelect,
    MusicSelect,
    Playing,
    Result
}

public class SceneManagers : MonoBehaviour
{
    public static SceneManagers instance = null;
    private GameScene currentGameScene;

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

    public void SetScene(GameScene scene)
    {
        currentGameScene = scene;
        OnGameSceneChanged (currentGameScene);
    }

    public void OnGameSceneChanged(GameScene scene)
    {
        switch(scene)
        {
            case GameScene.Title:
                SceneManager.LoadScene(0);
                break;
            case GameScene.CharaSelect:
                SceneManager.LoadScene(1);
                break;
            case GameScene.MusicSelect:
                SceneManager.LoadScene(1);
                break;
            case GameScene.Playing:
                SceneManager.LoadScene(2);
                break;
            case GameScene.Result:
                SceneManager.LoadScene(3);
                break;
            default:
                break;
        }
    }
}
