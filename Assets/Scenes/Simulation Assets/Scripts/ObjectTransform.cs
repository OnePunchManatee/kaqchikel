using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransform : MonoBehaviour
{

    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        //rigid = MainCamera.m_OrthographicCamera.GetComponent();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //while (Time.frameCount < 120)
        //{
            //transform.localScale += new Vector3(.1f, 0.1f, 0.1f);
        rigid.rotation.Equals(32);
        //}
    }
}
