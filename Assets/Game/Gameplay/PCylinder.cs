using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PCylinder : MonoBehaviour
{
    private bool isTest = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTest == false)
        {
            if (collision.gameObject.tag == "RightLeg" && SoccerPlayerController.Ins.v > 0)
            {
                transform.DORotate(new Vector3(0, 0, transform.rotation.z - 30), 1f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RightLeg" && SoccerPlayerController.Ins.v > 0)
        {
            isTest = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "RightLeg")
        {
            transform.DORotate(new Vector3(0, 0, transform.rotation.z+5f), 1f);
        }
    }
}
