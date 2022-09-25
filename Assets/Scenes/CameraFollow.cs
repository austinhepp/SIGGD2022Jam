using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 cameraOffset;
    [SerializeField] private GameObject mTarget;
    // Start is called before the first frame update
    void Start()
    {
        
        if (mTarget == null) {
            this.enabled = false;
        }
        cameraOffset = transform.position - mTarget.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (mTarget == null) {
            this.enabled = false;
        }
        Vector3 newPosition = mTarget.transform.position + cameraOffset;
        if (mTarget == null) {
            this.enabled = false;
        }
        transform.position = Vector3.Slerp(transform.position, newPosition, 1.0f);
        if (mTarget == null) {
            this.enabled = false;
        }
    }
}
