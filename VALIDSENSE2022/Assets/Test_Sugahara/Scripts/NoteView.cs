using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteView : MonoBehaviour
{
    /// <summary>
    /// フェードアウト用に自身のspriteを取得用
    /// </summary>
    SpriteRenderer sprite;


    /// <summary>
    /// 60fpsで落下する速度
    /// </summary>
    public float noteSpeed;

    private void Start()
    {
        // フェードアウト用に自身のspriteを取得
        sprite = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 60fpsで落下する速度の設定
    /// </summary>
    /// <param name="speed"></param>
    public void NoteSpeedSetter(double speed)
    {
        noteSpeed = (float)speed;
    }

    
    void FixedUpdate()
    {
        // 60fpsでspeed分落下させる
        transform.position -= new Vector3 (0, noteSpeed, 0);
    }


    /// <summary>
    /// コールチンの関数を利用して、フェードアウトして、非アクティブ化する
    /// </summary>
    public void NoteFadeOut()
    {
        StartCoroutine(FadeOut());
    }


    /// <summary>
    /// 自身をフェードアウトして、非アクティブ化する
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
