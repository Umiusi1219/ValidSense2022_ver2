using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevelSelect : MonoBehaviour
{
    [SerializeField]
    private Vector3[] _cursorPosY_1P;
    [SerializeField]
    private Vector3[] _cursorPosY_2P;

    [SerializeField]
    private int _cursorPosNum_1P;

    [SerializeField]
    private int _cursorPosNum_2P;

    [SerializeField]
    public int levelMax;

    [SerializeField]
    private GameObject cursor_1p;

    [SerializeField]
    private GameObject cursor_2p;
    // Start is called before the first frame update
    void Start()
    {
        MoveCursor1P(0);
        MoveCursor2P(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(_cursorPosNum_1P>0)
            {
                _cursorPosNum_1P--;
            }
            else if(_cursorPosNum_1P <= 0)
            {
                _cursorPosNum_1P = (levelMax-1);
            }
            MoveCursor1P(_cursorPosNum_1P);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            _cursorPosNum_1P = (_cursorPosNum_1P + 1) % levelMax;

            MoveCursor1P(_cursorPosNum_1P);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_cursorPosNum_2P > 0)
            {
                _cursorPosNum_2P--;
            }
            else if (_cursorPosNum_2P <= 0)
            {
                _cursorPosNum_2P = (levelMax - 1);
            }
            MoveCursor2P(_cursorPosNum_2P);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _cursorPosNum_2P = (_cursorPosNum_2P + 1) % levelMax;

            MoveCursor2P(_cursorPosNum_2P);
        }
    }

    private void MoveCursor1P(int posNum)
    {
        cursor_1p.transform.position = _cursorPosY_1P[posNum];
    }

    private void MoveCursor2P(int posNum)
    {
        cursor_2p.transform.position = _cursorPosY_2P[posNum];
    }
}
