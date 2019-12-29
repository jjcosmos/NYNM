using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] Transform lookTarget;
    [SerializeField] Vector3 offset;
    
    public float smoothTime = 0.01F;
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        offset = transform.position - lookTarget.transform.position ;
    }
    void LateUpdate()
    {
        // Define a target position above and behind the target transform
        //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));

        // Smoothly move the camera towards that target position
        //transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        transform.position = Vector3.MoveTowards(transform.position, lookTarget.transform.position + offset, 100f);
        //transform.LookAt(lookTarget.transform);
    }
}
