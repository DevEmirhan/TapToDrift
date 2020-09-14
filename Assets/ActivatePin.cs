using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePin : MonoBehaviour
{
    private PlayerController playerController;
    public bool isRightt = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (isRightt)
            {
                other.GetComponent<PlayerController>().isRight = true; 
            }
            else
            {
                other.GetComponent<PlayerController>().isRight = false ;
            }
            other.GetComponent<PlayerController>().activePin = this.gameObject;
            other.GetComponent<PlayerController>().AddScore();
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().activePin = null;
            other.GetComponent<PlayerController>().earnPoint = true;
        }
    }
}
