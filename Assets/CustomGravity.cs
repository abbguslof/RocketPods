using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public Vector3 ClosestPointOnMapCollider;
    public GameObject[] MapParts;

    public float GravityForce = 9.8f;
    public Rigidbody PlayerRB;

    private void Awake()
    {
        PlayerRB = GetComponent<Rigidbody>();

        MapParts = GameObject.FindGameObjectsWithTag("Map");
    }
    GameObject GetClosestMapObject(GameObject[] list)
    {
        GameObject ClosestObject = null;
        float MinimumDistance = Mathf.Infinity;
        Vector3 CurrentPosition = transform.position;
        foreach (GameObject CurrentObject in list)
        {
            float Distance = Vector3.Distance(CurrentObject.transform.position, transform.position);
            if (Distance < MinimumDistance)
            {
                ClosestObject = CurrentObject;
                MinimumDistance = Distance;
            }
        }
        return ClosestObject;
    }
    private void FixedUpdate()
    {
        customGravity();
    }
    private void customGravity()
    {
        GameObject ClosestColliderPartInMap = GetClosestMapObject(MapParts);
        ClosestPointOnMapCollider = ClosestColliderPartInMap.GetComponent<Collider>().ClosestPoint(transform.position);

        Vector3 Distance = ClosestPointOnMapCollider - transform.position;
        Vector3 Direction = (this.transform.position - ClosestPointOnMapCollider).normalized;
        if (Direction.magnitude == 0f) return;
        Vector3 Acceleration = Distance / (Distance.magnitude);

        PlayerRB.AddForce(Acceleration * GravityForce * 1000 + (10 * Distance));
    }
}
