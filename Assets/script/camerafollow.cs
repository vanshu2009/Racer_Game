using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;
    Vector3 distance;
    public float smoothValue;
    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y >= 0)
        {
            Follow();
        }
        
    }
    void Follow()
    {
        Vector3 currentpos = transform.position;
        Vector3 targetpos = target.position - distance;
        transform.position = Vector3.Lerp(currentpos, targetpos, smoothValue * Time.deltaTime); 
    }
}
