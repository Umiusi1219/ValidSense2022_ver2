using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testi : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SEPlayer.instance.SETap(0);
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            SEPlayer.instance.SETap(1);
        }
        if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.S))
        {
            SEPlayer.instance.SETap(2);
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            SEPlayer.instance.SETap(3);
        }


    }
}
