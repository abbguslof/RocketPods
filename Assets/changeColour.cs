using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColour : MonoBehaviour
{
    public Color myColor;
    public float rFloat;
    public float gFloat;
    public float bFloat;
    public float aFloat;

    public Renderer myRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        rFloat = 1;
        gFloat = 1;
        bFloat = 1;
        aFloat = 1;
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            rFloat = 1;
            gFloat = 0.2f;
            bFloat = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            rFloat = 0.7f;
            gFloat = 0f;
            bFloat = 1f;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            rFloat = 0.2f;
            gFloat = 0.4f;
            bFloat = 0.8f;
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            rFloat = 0.3f;
            gFloat = 0.7f;
            bFloat = 0.3f;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            rFloat = 0.6f;
            gFloat = 0.3f;
            bFloat = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rFloat = 0.6f;
            gFloat = 0f;
            bFloat = 0f;
        }

        myColor = new Color(rFloat, gFloat, bFloat, aFloat);
        myRenderer.material.color = myColor;
    }
}
