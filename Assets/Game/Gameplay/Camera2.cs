using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private Vector3 offset = new Vector3(1.88f, 2.54f, -3.6f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemy.transform.position + offset;
        if (Enemy.isCheck == true)
        {
            gameObject.SetActive(true);
            
        }
    }
}
