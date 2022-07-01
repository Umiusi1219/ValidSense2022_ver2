using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̃X�R�A�L���p
    /// </summary>
    public int scoreValue;


    /// <summary>
    /// ���g�̃e�L�X�g���p
    /// </summary>
    private Text _scoreText;


    private void Start()
    {
        // scoreText �Ɏ��g������
        _scoreText = GetComponent<Text>();

        // score�̕\���̏�����
        ScoreUpdate();
    }


    public void ScoreUpdate()
    {
        _scoreText.text = scoreValue.ToString();
    }
}
