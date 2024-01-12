using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconScript : MonoBehaviour
{
    //public Canvas myCanvas;
    public Image image;
    public GameObject obj;
    public static int counter = 0;
    public bool completion;

    public void Start()
    {
        image.enabled = false;
        obj.SetActive(false);
        //obj = GetComponent<GameObject>();
    }
    public void popup()
    {
        if (!completion) {
            counter++;
            completion = true;
        }

        if(counter > 1)
        {
            obj.SetActive(true);
        }
        image.enabled = !image.enabled;
    }
}
