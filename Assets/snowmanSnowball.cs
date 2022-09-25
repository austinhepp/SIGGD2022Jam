using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowmanSnowball : MonoBehaviour
{
    [SerializeField] private GameObject botTarget;
    [SerializeField] private GameObject botSnowball;
    private Vector3 originalBotPosition;
    // Start is called before the first frame update
    void Start()
    {
        
        originalBotPosition = botTarget.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(botTarget != null && botSnowball != null) {
            if (Vector3.Distance(transform.position, botTarget.transform.position) < 8) {
                
                Vector3 difference = botTarget.transform.position - transform.position;
                //difference = Vector3.Scale(difference.normalized, new Vector3(0.05f, 0.05f, 0.05f));
                //transform.position += difference;
                //transform.position = new Vector3(difference.position.x + transform.position.x, difference.position.y + transform.position.y, difference.position.z + transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, originalBotPosition, Time.deltaTime * 2);
            }
            //else {
                //transform.localScale = new Vector3(0, 0, 0);
                //Destroy(this);
            //}
            if (Vector3.Distance(transform.position, botTarget.transform.position) < 2) {
                float compare1 = transform.localScale.x;
                float compare2 = botSnowball.transform.localScale.x;
                if(compare1 >= compare2) {
                    Vector3 temp = transform.localScale;
                    temp = new Vector3(transform.localScale.x - botSnowball.transform.localScale.x, transform.localScale.y - botSnowball.transform.localScale.y, transform.localScale.z - botSnowball.transform.localScale.z);
                    transform.localScale = temp;

                    Vector3 botTemp = botSnowball.transform.localScale;
                    botTemp = new Vector3(0, 0, 0);
                    botSnowball.transform.localScale = botTemp;
                    
                } else {
                Vector3 botTemp = botSnowball.transform.localScale;
                botTemp = new Vector3(botSnowball.transform.localScale.x - transform.localScale.x, botSnowball.transform.localScale.y - transform.localScale.y, botSnowball.transform.localScale.z - transform.localScale.z);
                botSnowball.transform.localScale = botTemp;

                Vector3 temp = transform.localScale;
                temp = new Vector3(0, 0, 0);
                transform.localScale = temp;
                }
                
                transform.localScale = new Vector3(0, 0, 0);
                Destroy(this);
            }
        }
    }
}
