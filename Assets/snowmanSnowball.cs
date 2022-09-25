using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowmanSnowball : MonoBehaviour
{
    [SerializeField] private GameObject botTarget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = botTarget.transform.position - transform.position;
        if (Vector3.Distance(transform.position, botTarget.transform.position) < 8) {
            transform.position = Vector3.MoveTowards(transform.position, botTarget.transform.position, Time.deltaTime);
        }
    }
}
