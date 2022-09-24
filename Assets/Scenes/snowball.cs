using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class snowball : MonoBehaviour {
    [SerializeField] private GameObject mTarget;
    void Update() {
        transform.position = mTarget.transform.position + mTarget.transform.forward + Vector3.up;
    }
}