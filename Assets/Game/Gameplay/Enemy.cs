using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleWinG3;
    Rigidbody rb;
    [SerializeField]
    private GameObject camera1;
    [SerializeField]
    private GameObject camera2;
    public static bool isDealth = false;
    public static bool isCheck = false;
    bool isWave = false;
    [SerializeField]
    private GameObject enemyMode;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        particleWinG3.Stop();
    }
    void Update()
    {
        
        if (isCheck == true)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            if (isWave == false)
            {
                camera2.transform.position = enemyMode.transform.position + new Vector3(-2, 2, -4);
            }
            if(isDealth == true)
            {
                /*camera1.SetActive(true);
                camera2.SetActive(false);*/
                camera2.transform.DOMove(camera1.transform.position,0.5f);
                camera2.transform.DORotate(new Vector3(camera1.transform.position.x+4.178f, camera1.transform.position.y+16.79f, camera1.transform.position.z+5.97f), 0.5f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dealth")
        {
            isDealth = true;
            StartCoroutine(CameraFollowPlayer());
            
            //gameObject.SetActive(false);
        }
        if (other.tag == "StopAnim")
        {
            isCheck = true;

        }
        if(other.tag == "Wave")
        {
            isWave = true;
        }
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(0.6f);
        particleWinG3.Play();
        
    }
    IEnumerator CameraFollowPlayer()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(test());
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Foot")
        {
            isCheck = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "StopAnim")
        {
            isCheck = false;

        }

    }
    
}
