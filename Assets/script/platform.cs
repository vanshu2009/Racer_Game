using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public GameObject diamond;
   
    // Start is called before the first frame update
    void Start()
    {
        int randDiamond = Random.Range(0, 5);
        Vector3 diamondpos = transform.position;
        diamondpos.y += 1f;
        if (randDiamond < 1)
        {
            GameObject diamondInstance=Instantiate(diamond, diamondpos, diamond.transform.rotation);
            diamondInstance.transform.SetParent(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.2f);
        }
    }
    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
