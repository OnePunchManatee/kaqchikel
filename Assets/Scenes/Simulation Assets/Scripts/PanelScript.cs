using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public Image image;
    public float opacity = 0.7f;

    void Start()
    {
        image.enabled = false;
        // Get the image component if it is not set
        if (image == null)
            image = GetComponent<Image>();

        // Set the alpha value of the image's color
        Color imageColor = image.color;
        imageColor.a = opacity;
        image.color = imageColor;
    }

    public void popup()
    {
        
        image.enabled = !image.enabled;
    }
}