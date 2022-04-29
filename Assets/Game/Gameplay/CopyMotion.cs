using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform targetLimit;
    private ConfigurableJoint cj;
    private Quaternion startingRotation;
    // Start is called before the first frame update
    void Start()
    {
        cj = GetComponent<ConfigurableJoint>();
        startingRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        cj.SetTargetRotationLocal(targetLimit.rotation, startingRotation);
        //cj.targetRotation = targetLimit.rotation;
    }
}
