using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingRocket : MonoBehaviour
{
    float originalY;
    float originalX;
    float originalZ;
    public float floatStrengthY = 5f;
    public float floatStrengthX = 2.5f;

    void Start()
    {
        this.originalY = this.transform.position.y;
        this.originalX = this.transform.position.x;
        this.originalZ = this.transform.position.z;
    }
    void Update()
    {
        transform.position = new Vector3(originalX + ((float)Mathf.Cos(Time.time) * floatStrengthX), originalY + ((float)Mathf.Sin(Time.time) * floatStrengthY), originalZ + ((float)Mathf.Cos(Time.time) * 0.5f));
    }
}