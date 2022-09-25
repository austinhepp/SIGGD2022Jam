using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class snowball : MonoBehaviour {
    [SerializeField] private GameObject mTarget;
    [SerializeField] private GameObject botSnowball;
    [SerializeField] private GameObject botTarget;

    void Update() {
        if (mTarget != null && botTarget != null && botSnowball != null) {
            transform.position = mTarget.transform.position + Vector3.Scale(mTarget.transform.forward, transform.localScale + new Vector3(0.3f, 0.3f, 0.3f)) + Vector3.Scale(new Vector3(0, 0.5f, 0), transform.localScale);
            if (Vector3.Distance(botSnowball.transform.position, transform.position) < 2) {
                collide();
            }
        }
    }
    void collide() {
        float compare1 = transform.localScale.x;
        float compare2 = botSnowball.transform.localScale.x;
        if(compare1 >= compare2) {
            Vector3 temp = transform.localScale;
            temp = new Vector3(transform.localScale.x - botSnowball.transform.localScale.x, transform.localScale.y - botSnowball.transform.localScale.y, transform.localScale.z - botSnowball.transform.localScale.z);
            transform.localScale = temp;

            Vector3 difference = botTarget.transform.position - mTarget.transform.position;
            difference = Vector3.Scale(difference.normalized, temp * 4);
            botTarget.transform.position += difference;
        
        

            Vector3 botTemp = botSnowball.transform.localScale;
            botTemp = new Vector3(0, 0, 0);
            botSnowball.transform.localScale = botTemp;
        
        } else {
            Vector3 botTemp = botSnowball.transform.localScale;
            botTemp = new Vector3(botSnowball.transform.localScale.x - transform.localScale.x, botSnowball.transform.localScale.y - transform.localScale.y, botSnowball.transform.localScale.z - transform.localScale.z);
            botSnowball.transform.localScale = botTemp;

            Vector3 difference = mTarget.transform.position - botTarget.transform.position;
            difference = Vector3.Scale(difference.normalized, botTemp * 4);
            mTarget.transform.position += difference;

            Vector3 temp = transform.localScale;
            temp = new Vector3(0, 0, 0);
            transform.localScale = temp;
        }
    }
<<<<<<< Updated upstream

    void OnTriggerStay(Collider other) {
        if(other.tag == "Goodsnowman") {
<<<<<<< HEAD
            other.GetComponent<GoodSnowman>().health += (int) mTarget.GetComponent<PlayerController2>().getSnowpoint();
            mTarget.GetComponent<PlayerController2>().setSnowpoint(0);
            transform.localScale = new Vector3(0.0f,0.0f,0.0f);
=======
            Debug.Log("auth!");
=======
    void OnTriggerStay(Collider other) {
        if(other.tag == "Goodsnowman") {
>>>>>>> Stashed changes
            other.GetComponent<GoodSnowman>().health += mTarget.GetComponent<PlayerController>().getSnowpoint();
            mTarget.GetComponent<PlayerController>().setSnowpoint(0);
            transform.localScale = new Vector3(0,0,0);
>>>>>>> f85b156c50b8ec9c72db6fa5a2c1a08f081b1197
        }
    }
}