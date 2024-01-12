using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class MainCamera : MonoBehaviour
{

    private bool rClickInput;
    private float horizontalInput;
    private float verticalInput;
    private float xCurrent;
    private float yCurrent;
    private float zCurrent;
    const float xMinConst = 5;
    const float xMaxConst = 150f;
    private float xMinimum; 
    private float yMinimum;
    private float zMinimum;
    private float xMaximum;
    public Camera m_OrthographicCamera;
    private bool cameraBig;
    //bool moveCamPos = true;
    public CinemachineVirtualCamera virtualCamera;
    private float speed = 10.0f;
    //Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        m_OrthographicCamera = Camera.main;
       // m_OrthographicCamera.enabled = true;
        //rb = GetComponent<Rigidbody>();
        xMaximum = xMaxConst;
        xMinimum = xMinConst;
    }

    // Update is called once per frame
    void Update()
    {
        
            Vector3 cameraPosition = virtualCamera.transform.position;
        //print(cameraPosition.x);
        //print(rb.position.x);
        horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            rClickInput = Input.GetMouseButton(1);
            xCurrent = cameraPosition.x;
            yCurrent = cameraPosition.y;
            zCurrent = cameraPosition.z;
            if (cameraPosition.x >= xMinimum && cameraPosition.x <= xMaximum){
                transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            } else if (cameraPosition.x <= xMinimum) {
                virtualCamera.transform.position = new Vector3((float)(cameraPosition.x + .001), cameraPosition.y, cameraPosition.z);
            }
            else if (cameraPosition.x >= xMaximum)
            {
                virtualCamera.transform.position = new Vector3((float)(cameraPosition.x - .001), cameraPosition.y, cameraPosition.z);
            }

        /*if (cameraPosition.x <= xMinimum)
        {
            virtualCamera.transform.position = new Vector3((float)(xMinimum + .001), cameraPosition.y, cameraPosition.z);
        }
        if (cameraPosition.x >= xMaximum)
        {
            virtualCamera.transform.position = new Vector3((float)(xMaximum - .001), cameraPosition.y, cameraPosition.z);
        }*/
        //rb.velocity = new Vector3(horizontalInput * 30, rb.velocity.y, 0);
        /*if (rb.position.x <= xMinimum)
        {
            rb.position = new Vector3((float)(xMinimum + .01), yCurrent, -10);
        }d
        if (rb.position.x >= xMaximum)
        {
            rb.position = new Vector3((float)(xMaximum - .01), yCurrent, -10);
        }
        if (rClickInput)
        {

            //Set the size of the viewing volume you'd like the orthographic Camera to pick up (5)
            m_OrthographicCamera.orthographicSize = 5.0f;
            xMinimum = xMinConst - 9; // TODO USE ASPECT RATIO REMOVE MAGIC NUM
            xMaximum = xMaxConst + 9;
            rb.velocity = new Vector3(horizontalInput * 20, verticalInput * 20, 0);
            if(moveCamPos)
            {
                rb.position = m_OrthographicCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            if (rb.position.y >= 5)
            {
                rb.position = new Vector3(xCurrent, (float)4.9, -10);
            }
            if (rb.position.y <= -7)
            {
                rb.position = new Vector3(xCurrent, (float)-6.9, -10);
            }
            cameraBig = true;
            moveCamPos = false;
        } else if (cameraBig)
        {
        moveCamPos = true;
            m_OrthographicCamera.orthographicSize = 11.8f;
            xMaximum = xMaxConst;
            xMinimum = xMinConst;
            horizontalInput = 0;
            verticalInput = 0;
            rb.velocity = new Vector3(0, 0, 0);
            rb.position = new Vector3(xCurrent, -1, -10);
            cameraBig = false;

    } */

    }
}