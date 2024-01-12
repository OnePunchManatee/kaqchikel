using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cubement : MonoBehaviour
{

    public float speed = 10.0f;
    private float horizontalInput;
    private float verticalInput;
    private float yaw;
    private float pitch;
    private float xMaximum = 140;
    private float xMinimum = 5;
    public CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = virtualCamera.transform.position;
        horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //yaw += Input.GetAxis("Mouse X");
        //pitch += -Input.GetAxis("Mouse Y");

        //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (cameraPosition.x <= xMinimum)
        {
            virtualCamera.transform.position = new Vector3((float)(xMinimum + .01), cameraPosition.y, cameraPosition.z);
        }
        if (cameraPosition.x >= xMaximum)
        {
            virtualCamera.transform.position = new Vector3((float)(xMaximum - .01), cameraPosition.y, cameraPosition.z);
        }
    }
}