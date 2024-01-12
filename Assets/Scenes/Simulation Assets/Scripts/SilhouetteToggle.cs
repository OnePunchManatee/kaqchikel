using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilhouetteToggle : MonoBehaviour
{

    public Image image;

    private bool isImageActive = false;
    public Sprite newImage;


    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            //turns silhouette on and off
            isImageActive = true;

        }
        else
        {
            isImageActive = false;
        }
        if (isImageActive)
        {
            SetImageOpacity(1f);
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

    public void SwapImage()
    {
        // Swap out the image
        // You can replace "newImage" with the new image you want to display
        image.sprite = newImage;
    }
}


