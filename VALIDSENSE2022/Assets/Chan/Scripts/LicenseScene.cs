using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicenseScene : MonoBehaviour
{
    public GameObject criware,otoLogic;
    // Start is called before the first frame update
    void Start()
    {
        criware.SetActive(true);
        otoLogic.SetActive(false);
        Invoke("Change",2.5f);
    }
    private void Change()
    {
        criware.SetActive(false);
        otoLogic.SetActive(true);
        Invoke("ChangeScene",2.5f);
    }
    private void ChangeScene()
    {
        otoLogic.SetActive(false);
        GameObject.Find("SceneManager").SendMessage("SetScene", GameScene.Title);
    }
}
