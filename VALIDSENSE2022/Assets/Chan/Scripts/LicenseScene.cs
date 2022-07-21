using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicenseScene : MonoBehaviour
{
    public GameObject criware,otoLogic,QR;

    bool canToNextScene = false;

    // Start is called before the first frame update
    void Start()
    {
        criware.SetActive(true);
        otoLogic.SetActive(false);
        QR.SetActive(false);
        Invoke("Change",3.2f);
    }
    private void Change()
    {
        criware.SetActive(false);
        otoLogic.SetActive(true);
        QR.SetActive(false);
        Invoke("ShowQR", 3.2f);
    }

    void ShowQR()
    {
        criware.SetActive(false);
        otoLogic.SetActive(false);
        QR.SetActive(true);

        canToNextScene = true;
    }

    private void Update()
    {
        if(canToNextScene)
        {
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.R) ||
                Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F))
            {
                if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.U) ||
                    Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.J))
                {
                    Invoke("ChangeScene", 0.1f);
                }
            }

            if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.U) ||
                Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.J))
            {
                if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.R) ||
                    Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F))
                {
                    Invoke("ChangeScene", 0.1f);
                }
            }

        }




    }

    private void ChangeScene()
    {
        GameObject.Find("SceneManager").SendMessage("SetScene", GameScene.Title);
    }
}
