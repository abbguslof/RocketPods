using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FPCROCKET : MonoBehaviour
{
    public Rigidbody SphereColliderRb;

    public Transform Camera;
    public float mouseSensitivity = 100f;
    public Transform PlayerModel;

    public float speed = 50f;
    float Xrotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MoveCharacter();
        LookCamera();
    }

    public void LookCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        Camera.transform.localRotation = Quaternion.Euler(Xrotation, 0, 0f);
        PlayerModel.Rotate(new Vector3(0, 1, 0) * mouseX);
    }
    public void AddForce(Rigidbody Body, Vector3 Direction, float Speed)
    {
        if (Body.velocity.magnitude <= 500)
        {
            Body.AddForce(Direction * speed, ForceMode.Acceleration);
        }
    }
    public void MoveCharacter()
    {
        // Flyttar efter Rullande bollen :)
        transform.position = SphereColliderRb.transform.position;
        SphereColliderRb.transform.localPosition = new Vector3(0, 0, 0);
        PlayerModel.position = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            AddForce(SphereColliderRb, PlayerModel.forward, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            AddForce(SphereColliderRb, -PlayerModel.right, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            AddForce(SphereColliderRb, -PlayerModel.forward, speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            AddForce(SphereColliderRb, PlayerModel.right, speed);
        }

    }
}
