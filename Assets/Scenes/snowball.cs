using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class snowball : MonoBehaviour {
    [SerializeField] private GameObject mTarget;
    void Update() {
        transform.position = mTarget.transform.position + Vector3.Scale(mTarget.transform.forward, transform.localScale + new Vector3(0.3f, 0.3f, 0.3f)) + Vector3.Scale(new Vector3(0, 0.5f, 0), transform.localScale);
    }
}