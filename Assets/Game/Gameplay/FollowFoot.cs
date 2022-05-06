using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFoot : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField] public Transform foot;
    public float moveSpeed = 0.1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(foot.position, transform.position);

        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            //mousePosition.z = 2.6f;
            Vector3 position = Camera.main.ScreenToViewportPoint(mousePosition);
            position.x = 2f;
            transform.position = position;
        }
        /*if (dist > 0f)
        {
            transform.position = Vector2.Lerp(transform.position, foot.position, moveSpeed + 1f);
        }*/
        else
        {
            return;
        }
    }
}
