using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilhouetteBackdropToggle : MonoBehaviour
{

    public Image image;

    private bool isImageActive = false;


    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            //turns silhouette on and off
            isImageActive = true;

        } else
        {
            isImageActive = false;
        }
        if (isImageActive)
        {
            SetImageOpacity(.5f);
        }
        else
        {
            SetImageOpacity(0f);
        }
    }

    void SetImageOpacity(float opacity)
    {
        //makes image invisible when tab is pressed and vice versa
        Color color = image.color;
        color.a = opacity;
        image.color = color;
    }

    void OnDisable()
    {
        // Set the image opacity to 0 when the script is disabled
        SetImageOpacity(0f);
    }

    void OnEnable()
    {
        // Set the image opacity to 0 when the script is enabled
        SetImageOpacity(0f);
    }
}


