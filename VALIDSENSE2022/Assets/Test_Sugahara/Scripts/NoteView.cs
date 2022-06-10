using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteView : MonoBehaviour
{
    /// <summary>
    /// �t�F�[�h�A�E�g�p�Ɏ��g��sprite���擾�p
    /// </summary>
    SpriteRenderer sprite;


    /// <summary>
    /// 60fps�ŗ������鑬�x
    /// </summary>
    public float noteSpeed;

    private void Start()
    {
        // �t�F�[�h�A�E�g�p�Ɏ��g��sprite���擾
        sprite = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 60fps�ŗ������鑬�x�̐ݒ�
    /// </summary>
    /// <param name="speed"></param>
    public void NoteSpeedSetter(double speed)
    {
        noteSpeed = (float)speed;
    }

    
    void FixedUpdate()
    {
        // 60fps��speed������������
        transform.position -= new Vector3 (0, noteSpeed, 0);
    }


    /// <summary>
    /// �R�[���`���̊֐��𗘗p���āA�t�F�[�h�A�E�g���āA��A�N�e�B�u������
    /// </summary>
    public void NoteFadeOut()
    {
        StartCoroutine(FadeOut());
    }


    /// <summary>
    /// ���g���t�F�[�h�A�E�g���āA��A�N�e�B�u������
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOut()
    {
        sprite.color = new Color(1.0f, 1.0f ,1.0f,0.8f);
        yield return new WaitForSeconds(0.03f);

        sprite.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        yield return new WaitForSeconds(0.03f);

        sprite.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        yield return new WaitForSeconds(0.02f);

        this.gameObject.SetActive(false);
    }
}
