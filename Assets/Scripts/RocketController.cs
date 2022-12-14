using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Transform PlayerModel;
    public Rigidbody SphereColliderRb;

    public float steering = 80f;
    public float speed = 3;
    float currentspeed;
    float rotate, currentRotate;
    void Start()
    {
        
    }
    void Update()
    {
        // Flyttar efter Rullande bollen :)
        transform.position = SphereColliderRb.transform.position;
        SphereColliderRb.transform.localPosition = new Vector3(0, 0, 0);
        PlayerModel.position = transform.position;

        // lol
        if (Input.GetKey(KeyCode.W))
        {
            SphereColliderRb.AddForce(PlayerModel.forward * speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            SphereColliderRb.AddForce(-PlayerModel.forward * speed, ForceMode.Acceleration);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            float amount = Mathf.Abs((Input.GetAxis("Horizontal")));
            Steer(dir, amount);
        }

        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f); rotate = 0f;

        // Rotera efter Marken

        RaycastHit hitOn;
        RaycastHit hitNear;

        Physics.Raycast(transform.position + (transform.up * .1f), Vector3.down, out hitOn, 10f);
        Physics.Raycast(transform.position + (transform.up * .1f), Vector3.down, out hitNear, 20f);

        PlayerModel.up = Vector3.Lerp(PlayerModel.up, hitNear.normal, Time.deltaTime * 8.0f);
        PlayerModel.Rotate(0, transform.eulerAngles.y, 0);
    }
    void FixedUpdate()
    {
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
    }
    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }
}
