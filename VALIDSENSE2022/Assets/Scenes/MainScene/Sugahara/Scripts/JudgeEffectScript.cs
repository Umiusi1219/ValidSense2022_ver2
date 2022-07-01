using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeEffectScript : MonoBehaviour
{
    /// <summary>
    /// 自分のカラーコードに干渉する用
    /// </summary>
    SpriteRenderer sprite;

    private void Start()
    {
        // 自分のSpriteRendererを入れる
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
