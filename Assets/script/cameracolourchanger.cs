using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracolourchanger : MonoBehaviour
{
    public Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("colorchanger"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator colorchanger()
    {
        while (true)
        {
            int randcolor = Random.Range(0, 5);
            Camera.main.backgroundColor = colors[randcolor];
            yield return new WaitForSeconds(10f);
        }
    }
}
