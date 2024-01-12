using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject objecto;
    private Rigidbody rb;
    public Camera[] cameras;
    //private int currentCameraIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = objecto.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.transform.position.z > -40)
        {
            // Disable the current camera
            cameras[0].enabled = false;

            // Increment the camera index or reset it to 0 if it exceeds the array length
            //currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Enable the new current camera
            cameras[1].enabled = true;
            PlayerMovement.freeze = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Disable the current camera
                cameras[1].enabled = false;
                Vector3 newPosition = objecto.transform.position + new Vector3(1f, 0f, -5f);
                objecto.transform.position = newPosition;

                // Increment the camera index or reset it to 0 if it exceeds the array length
                //currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

                // Enable the new current camera
                cameras[0].enabled = true;
                PlayerMovement.freeze = false;
            }
        }


    }
}
