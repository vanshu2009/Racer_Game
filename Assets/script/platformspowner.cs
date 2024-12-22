using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformspowner : MonoBehaviour
{
    public GameObject platform;
    public Transform lastplatform;
    Vector3 lastposition;
    Vector3 newpos;
    bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        lastposition = lastplatform.position;
        StartCoroutine(spownplatform());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    spownplatform();
        //}
    }
    IEnumerator spownplatform()
    {
        while (!stop)
        {
            generateposition();
            Instantiate(platform, newpos, Quaternion.identity);
            lastposition = newpos;
            yield return new WaitForSeconds(0.1f);
        }
    }
    //void spownplatform()
    //{
    //    generateposition();
    //    Instantiate(platform, newpos, Quaternion.identity);
    //    lastposition = newpos;
    //}
    void generateposition()
    {
        newpos = lastposition;
        int rand = Random.Range(0, 2);
        if (rand > 0)
        {
            newpos.x -= 2f;

        }
        else
        {
        newpos.z -= 2f;
        }
    }
}
