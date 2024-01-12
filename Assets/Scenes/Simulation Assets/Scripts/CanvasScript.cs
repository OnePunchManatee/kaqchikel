using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public Canvas myCanvas;
    public bool a = false;

    public void Start()
    {
    }
    public void popup()
    {
        if (!a)
        {
            a = true;
            myCanvas.enabled = true;
        }
        else if (a)
        {
           a = false;
           myCanvas.enabled = false;
        }
    }

}
