using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewNotesScript : MonoBehaviour
{
    /// <summary>
    /// �t�F�[�h�A�E�g�p�Ɏ��g��sprite���擾�p
    /// </summary>
    private SpriteRenderer _sprite;


    /// <summary>
    /// 60fps�ŗ������鑬�x
    /// </summary>
    public float notesSpeed;

    private void Start()
    {
        // �t�F�[�h�A�E�g�p�Ɏ��g��_sprite���擾
        _sprite = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 60fps�ŗ������鑬�x�̐ݒ�
    /// </summary>
    /// <param name="speed"></param>
    public void NotesSpeedSetter(double speed)
    {
        notesSpeed = (float)speed;
    }


    void FixedUpdate()
    {
        // 60fps��speed������������
        transform.position -= new Vector3(0, notesSpeed, 0);
    }


    /// <summary>
    /// �R�[���`���̊֐��𗘗p���āA�t�F�[�h�A�E�g���āA��A�N�e�B�u������
    /// </summary>
    public void NotesFadeOut()
    {
        StartCoroutine(FadeOut());
    }


    /// <summary>
    /// ���g���t�F�[�h�A�E�g���āA��A�N�e�B�u������
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOut()
    {
        _sprite.color -= new Color( 0f, 0f, 0f, 0.2f);
        yield return new WaitForSeconds(0.03f);

        _sprite.color -= new Color( 0f, 0f, 0f, 0.3f);
        yield return new WaitForSeconds(0.03f);

        _sprite.color -= new Color( 0f, 0f, 0f, 0.3f);
        yield return new WaitForSeconds(0.02f);

        this.gameObject.SetActive(false);
    }
}
