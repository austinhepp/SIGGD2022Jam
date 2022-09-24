using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject snowball;
    public float movementSpeed = 3;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    public int snowpoint = 0;
    
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
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 maxSnowballSize = new Vector3(2.5f, 2.5f, 2.5f);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
              if (snowball.transform.localScale.x < maxSnowballSize.x && snowball.transform.localScale.y < maxSnowballSize.y && snowball.transform.localScale.z < maxSnowballSize.z) {
                Vector3 temp = snowball.transform.localScale;
                temp += new Vector3(0.001f, 0.001f, 0.001f);
                snowball.transform.localScale = temp;
                snowpoint = snowpoint + 1;
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
    }
}