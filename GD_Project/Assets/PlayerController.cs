using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public float aimSensitivity = 3f;
    public Camera cam;
    Rigidbody rb;


    private void Start(){
        rb = GetComponent<Rigidbody>();

        //make mouse cursor not leave game window when it is played
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void FixedUpdate() {
        PlayerMovement();
        PlayerRotation();
    }

    void PlayerMovement(){
        float movX = Input.GetAxisRaw("Horizontal");
        float movZ = Input.GetAxisRaw("Vertical");

        Vector3 movePlayer = new Vector3(movX, 0, movZ);

        transform.Translate(movePlayer * Time.fixedDeltaTime * speed, Space.Self);
    }

    void PlayerRotation(){
        float rotateY = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, rotateY, 0) * aimSensitivity;

        transform.Rotate(rotation);

        float rotateX = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(rotateX, 0, 0) * aimSensitivity;
        cam.transform.Rotate(-camRotation);
    }


    // Start is called before the first frame update
    // void Start()
    // {
    //     rbody = GetComponent<Rigidbody>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    // // moving player in front and back and, left and right.
    //     float movInXaxis = Input.GetAxisRaw("Horizontal");
    //     float movInZaxis = Input.GetAxisRaw("Vertical");

    //    //rotate player left and right
    //     float rotateInYaxis = Input.GetAxisRaw("Mouse X");

    //     //rotate camera up and down
    //     float rotateInXaxis = Input.GetAxisRaw("Mouse Y");

    //     //here we are using vector3 because we have three axis
    //     Vector3 movePlayer = new Vector3(movInXaxis, 0, movInZaxis);
    //     Vector3 rotation = new Vector3(0, rotateInYaxis, 0) * aimSensitivity;
    //     Vector3 upDownRotation = new Vector3(rotateInXaxis, 0, 0) * aimSensitivity;

    //    //to smooth the move we use Time.deltaTime
    //    //change player movement according to rotation
    //     transform.Translate(movePlayer * Time.deltaTime * speed, Space.Self);

    //     //while player rotation form left to right, rbody gives current rotation and Quaternion.Euler() converts rotational vector to Quaternion which represents rotation around the X,Y,Z axis.
    //     rbody.MoveRotation(rbody.rotation * Quaternion.Euler(rotation));

    //     //allow to rotate camera up and down.
    //     // here minus upDownRotation is used to invert the rotation.
    //     cam.transform.Rotate(-upDownRotation);


    // }
}
