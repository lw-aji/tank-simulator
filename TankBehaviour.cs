using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehaviour : MonoBehaviour
{
    private Transform myTransform;
    private string verticalRotationState; 
    public float speed;
    public GameObject zRotation;
    public GameObject xRotation;

    public float verticalAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            zRotation.transform.Rotate(Vector3.back * speed * Time.deltaTime, Space.Self); //rotasi horizontal searah jarum jam
        }
        else if(Input.GetKey(KeyCode.U))
        {
            zRotation.transform.Rotate(Vector3.forward * speed * Time.deltaTime, Space.Self); //rotasi horizontal berlawanan jarum jam
        }

        verticalAngle = 360 - xRotation.transform.localEulerAngles.x;
        //State
        if(verticalAngle == 360 || verticalAngle == 0)
        {
            verticalRotationState = "aman";
        }
        else if (verticalAngle > 0 && verticalAngle < 15)
        {
            verticalRotationState = "aman";
        }
        else if (verticalAngle > 15 && verticalAngle < 16)
        {
            verticalRotationState = "atas";
        }
        else if (verticalAngle > 350)
        {
            verticalRotationState = "bawah";
        }

        if(verticalRotationState == "aman")
        {
            if(Input.GetKey(KeyCode.Y))
            {
                xRotation.transform.Rotate(Vector3.left * speed * Time.deltaTime, Space.Self); //rotasi vertikal atas
            }
            else if(Input.GetKey(KeyCode.H))
            {
                xRotation.transform.Rotate(Vector3.right * speed * Time.deltaTime, Space.Self); //rotasi vertikal bawah
            }
        }
        else if(verticalRotationState == "bawah")
        {
            xRotation.transform.localEulerAngles = new Vector3(
                -0.5f, xRotation.transform.localEulerAngles.y, xRotation.transform.localEulerAngles.z
            );
        }
        else if(verticalRotationState == "atas")
        {
            xRotation.transform.localEulerAngles = new Vector3(
                -14.5f, xRotation.transform.localEulerAngles.y, xRotation.transform.localEulerAngles.z
            );
        }

        
    }
}
