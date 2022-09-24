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
        cameraOffset = transform.position - mTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = mTarget.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, 1.0f);
    }
}
