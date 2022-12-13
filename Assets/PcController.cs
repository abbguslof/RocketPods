using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PcController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject Model;

    public int speed;
    public int rotSpeed;
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(rb.transform.up * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.eulerAngles = new Vector3(rb.transform.eulerAngles.x, rb.transform.eulerAngles.y + rotSpeed, rb.transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.eulerAngles = new Vector3(rb.transform.eulerAngles.x, rb.transform.eulerAngles.y - rotSpeed, rb.transform.eulerAngles.z);
        }

        model.transform.position = new Vector3(-(ball.transform.position - closestPoint).normalized.x + ball.transform.position.x, -(ball.transform.position - closestPoint).normalized.y + ball.transform.position.y, -(ball.transform.position - closestPoint).normalized.z + ball.transform.position.z);
    }
}
