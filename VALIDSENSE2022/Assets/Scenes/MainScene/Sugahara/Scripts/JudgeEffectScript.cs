using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeEffectScript : MonoBehaviour
{
    /// <summary>
    /// �����̃J���[�R�[�h�Ɋ�����p
    /// </summary>
    SpriteRenderer sprite;

    private void Start()
    {
        // ������SpriteRenderer������
        sprite = GetComponent<SpriteRenderer>();

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        sprite.color -= new Color(0f,0f,0f, 0.2f);
        transform.position += new Vector3(0f, 0.5f, 0f);
        yield return new WaitForSeconds(0.1f);

        sprite.color -= new Color(0f, 0f, 0f, 0.3f);
        transform.position += new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(0.08f);

        sprite.color -= new Color( 0f,0f,0f, 0.3f);
        transform.position += new Vector3(0f, 0.5f, 0f);
        yield return new WaitForSeconds(0.07f);

        this.gameObject.SetActive(false);
    }
}
