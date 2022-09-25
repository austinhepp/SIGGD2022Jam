using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSnowman : MonoBehaviour
{
    [SerializeField] private GameObject snowmanSnowball;
    GameObject snowmanSnowballClone;
    [SerializeField] private GameObject botTarget;
    private float frameNum;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        tag = "Goodsnowman";
        health = 2500;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, botTarget.transform.position) < 8) {
            if (frameNum % 1000 == 0) {
                snowmanSnowballClone = Instantiate(snowmanSnowball, transform.position, Quaternion.identity) as GameObject;
            }
        }
        frameNum++;
    }
}
