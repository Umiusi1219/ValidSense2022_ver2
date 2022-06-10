using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorEffectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.5f);

        this.gameObject.SetActive(false);
    }
}
