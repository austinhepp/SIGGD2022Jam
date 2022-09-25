using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    [SerializeField] private GameObject botSnowball;
    [SerializeField] private GameObject botPenguin;
    public float movementSpeed = 3;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    public int botSnowpoint = 0;
    public double frameNum = 0;
    public float moveHorizontal = 0f;
    public float moveVertical = 0f;
    
    Animator anim;
    Rigidbody rb;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControllPlayer();
    }

    void ControllPlayer()
    {
        if (transform.position.y <= 0.7f) {
            eliminate();
        }
        if (frameNum % 100 == 0) {
            //moveHorizontal = 100 * Random.Range(-1, 1);//Input.GetAxisRaw("Horizontal");
            //moveVertical = 100 * Random.Range(-1, 1);// Input.GetAxisRaw("Vertical");
        } else {
            moveHorizontal = 0.0f;
            moveVertical = 0.0f;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 maxSnowballSize = new Vector3(2.5f, 2.5f, 2.5f);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
              if (botSnowball.transform.localScale.x < maxSnowballSize.x && botSnowball.transform.localScale.y < maxSnowballSize.y && botSnowball.transform.localScale.z < maxSnowballSize.z) {
                Vector3 temp = botSnowball.transform.localScale;
                temp += new Vector3(0.001f, 0.001f, 0.001f);
                botSnowball.transform.localScale = temp;
                botSnowpoint = botSnowpoint + 1;
                //snowball.transform.localScale = snowball.transform.localScale * 1.5f;
                //Vector3.Scale(snowball.transform.localScale, snowball.transform.localScale + new Vector3(1.5f, 1.5f, 1.5f));
            }
            
        }
        else {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (false && Time.time > canJump)
        {
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
        }
        frameNum++;
    }

    void eliminate() {
        Destroy(botPenguin);
        Destroy(botSnowball);
        this.enabled = false;
    }
}