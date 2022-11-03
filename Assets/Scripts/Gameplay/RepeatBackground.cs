using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth = -9f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        // repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < repeatWidth)
        {
            transform.position = startPos;

        }
    }
}