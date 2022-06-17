using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevelSelect : MonoBehaviour
{
    /// <summary>
    /// cursor�̍��W
    /// </summary>
    [SerializeField]
    private Vector3[] _cursorPosY;

    /// <summary>
    /// cursor���W�̔z��
    /// </summary>
    [SerializeField]
    private int _cursorPosNum;

    /// <summary>
    /// �I�������Ȃ̓�Փx�̐�
    /// </summary>
    [SerializeField]
    public int levelsMax;


    void Start()
    {
        //cursor�������ʒu�Ɉړ�
        MoveCursor(0);
    }


    void Update()
    {
        //W�����������Ɉړ�����1�ԏゾ������1�ԉ��Ɉړ�����
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_cursorPosNum > 0)
            {
                _cursorPosNum--;
            }
            else if (_cursorPosNum <= 0)
            {
                _cursorPosNum = (levelsMax - 1);
            }

            MoveCursor(_cursorPosNum);
        }
        //S���������牺�Ɉړ�����1�ԉ���������1�ԏ�Ɉړ�����
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _cursorPosNum = (_cursorPosNum + 1) % levelsMax;

            MoveCursor(_cursorPosNum);
        }
    }


    /// <summary>
    /// �J�[�\���� _cursorPosY[����] �̏ꏊ�Ɉړ�������֐��ł�
    /// </summary>
    /// <param name="posNum">0 �` levelsMax�̒l�̂ݓ���Ă�������</param>
    private void MoveCursor(int posNum)
    {
        this.transform.position = _cursorPosY[posNum];
    }
}
