using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    [SerializeField] private GameObject snowman;
    GameObject snowmanClone;
    int deep;
    // Start is called before the first frame update
    void Start()
    {
        deep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        deep = deep +1;
    }

    public int getDeep(){
        return deep;
    }
    void OnTriggerStay(Collider other) {
        if(other.gameObject.GetComponent<trigger>()) {
            if(this.deep >= other.gameObject.GetComponent<trigger>().getDeep()){
            snowmanClone = Instantiate(snowman,transform.position + Vector3.down*3 ,Quaternion.identity) as GameObject;
            snowmanClone.tag = "Goodsnowman";
            }
            Object.Destroy(other.gameObject);
            Object.Destroy(gameObject);
        }
    }
}
