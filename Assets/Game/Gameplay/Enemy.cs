using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleWinG3;
    Rigidbody rb;
    [SerializeField]
    private GameObject camera2;
    public static bool isDealth = false;
    public static bool isCheck = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        particleWinG3.Stop();
    }
    private void LateUpdate()
    {
        if (isCheck == true)
        {
            //camera2.SetActive(true);
            //camera2.transform.position = gameObject.transform.position /*+ offset*/;
        }
    }
    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dealth")
        {
            isDealth = true;
            particleWinG3.Play();
            gameObject.SetActive(false);
        }
        if(other.tag == "StopAnim")
        {
            isCheck = true;
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Foot")
        {
            //isCheck = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Foot")
        {
            isCheck = false;
        }
    }
}
