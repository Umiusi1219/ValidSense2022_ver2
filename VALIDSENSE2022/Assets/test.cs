using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Transform newtransform;
    // Start is called before the first frame update
    void Start()
    {
        newtransform = transform.parent;
    }


}
