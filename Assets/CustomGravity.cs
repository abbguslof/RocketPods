using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;

public class CustomGravity : MonoBehaviour
{
    //public GameObject Map;
    //public Rigidbody MapRb;
    public Vector3 ClosestMapPoint;
    private Collider MapCollider;

    private GameObject[] MapColliders;

    public float GravityForce = 9.8f;

    private Collider PlayerCollider;

    private Rigidbody rb;

    private void Awake()
    {
        PlayerCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        //MapCollider = Map.GetComponent<Collider>();

        MapColliders = GameObject.FindGameObjectsWithTag("Map");
    }
    GameObject GetClosestMapPart(GameObject[] list)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in list)
        {
            float dist = Vector3.Distance(t.transform.position, transform.position);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
    private void FixedUpdate()
    {
        customGravity();
    }   
    private void customGravity()
    {
        GameObject ClosestColliderInMap = GetClosestMapPart(MapColliders);

        ClosestMapPoint = ClosestColliderInMap.GetComponent<Collider>().ClosestPoint(transform.position);

        Vector3 dist = ClosestMapPoint - transform.position;

        Vector3 dir = (this.transform.position - ClosestMapPoint).normalized;
        if (dist.magnitude == 0f) return;
        Vector3 acceleration = dist / (dist.magnitude);
        
        Debug.DrawRay(transform.position, dist);
        rb.AddForce(acceleration * GravityForce);
    }
}