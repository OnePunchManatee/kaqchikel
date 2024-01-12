using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectButton : MonoBehaviour
{

    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    private IconScript iconScript;
    private PanelScript panelScript;

    //for changing the inventory icons
    public Image silhouette;
    //public Sprite newImage;
    public SilhouetteToggle silhouetteScript;

    //for spinning and bobbing
    public float rotationSpeed = 15f;
    public float bobSpeed = 0.5f;
    public float bobHeight = 0.001f;

    private Vector3 startPosition;

    private bool isPoppedUp;

    // Use this for initialization
    void Start()
    {
        silhouette = GetComponent<Image>();
        definedButton = this.gameObject;
        iconScript = GetComponent<IconScript>();
        panelScript = GetComponent<PanelScript>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // Rotate the game object around the y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Bob the game object up and down
        float yOffset = bobHeight * Mathf.Sin(bobSpeed * Time.time) + 1;
        transform.position = startPosition + new Vector3(0, yOffset, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //print("image status: " + iconScript.image.enabled);
        if (isPoppedUp)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                TogglePopup();
            } 
        } else
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit Hit;
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                {
                    float distance = Vector3.Distance(Hit.point, Camera.main.transform.position);
                    if (distance < 3)
                    {
                        GetComponent<AudioSource>().Play();
                        TogglePopup();
                    }
                }
            }
        }
    }

    void Freeze()
    {
        PlayerMovement.freeze = !PlayerMovement.freeze;
    }

    void TogglePopup()
    {
        if (iconScript != null)
        {
            Freeze();   
            iconScript.popup();
            panelScript.popup();
            silhouetteScript.SwapImage();
            //silhouette.sprite = newImage
            isPoppedUp = !isPoppedUp;
        }
    }

    
}