using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour
{
    public GameObject pickupeffect;
    public float movespeed;
    bool movingleft = true;
    bool firstinput = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gamestarted)
        {
            Move();
            checkInput();

        }
        if (transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
        
    }
    void Move()
    {
        transform.position += transform.forward * movespeed * Time.deltaTime;
    }
    void checkInput()
    {
        if (firstinput)
        {
            firstinput = false;
            return;
        }
        if (Input.GetMouseButtonDown(0)){
            changeDirection();
        }

    }
    void changeDirection()
    {
        if (movingleft)
        {
            movingleft = false;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            movingleft = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            GameManager.instance.Incrementscore();
            Instantiate(pickupeffect, other.transform.position, pickupeffect.transform.rotation);
            other.gameObject.SetActive(false);
        }
    }

}
