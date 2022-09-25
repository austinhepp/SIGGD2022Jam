using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSnowman : MonoBehaviour
{
    [SerializeField] private GameObject snowmanSnowball;
    GameObject snowmanSnowballClone;
    [SerializeField] private GameObject botTarget;
<<<<<<< Updated upstream
    private float frameNum;
    public int health;
=======
    private float frameNum = 500f;
    public float health;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        tag = "Goodsnowman";
        health = 2500;
    }

    // Update is called once per frame
    void Update()
    {
        if (botTarget != null) {
            if (Vector3.Distance(transform.position, botTarget.transform.position) < 8) {
                if (frameNum % 1000 == 0) {
                    snowmanSnowballClone = Instantiate(snowmanSnowball, new Vector3(transform.position.x, transform.position.y + 4.2f, transform.position.z), Quaternion.identity) as GameObject;
                }
            }
            frameNum++;
        }
    }
}
