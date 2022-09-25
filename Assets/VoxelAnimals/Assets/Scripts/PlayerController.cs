using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject penguin;
    [SerializeField] private GameObject snowball;
    //[SerializeField] private GameObject water;
    private float movementSpeed = 3;
    private float jumpForce = 300;
    private float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    private int snowpoint = 0;
    private Text text;
    public float frameNum = 0.0f;
    public float newFrameNum = float.MaxValue;
    
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
        frameNum++;
    }

    void ControllPlayer()
    {
        //if (transform.position.y <= 2f) {
           //// transform.position = new Vector3(transform.position.x, 2.07f, transform.position.z);
       // }
        //OnTriggerEnter();
        if (transform.position.y <= 0.7f) {
            eliminate();
        }
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 maxSnowballSize = new Vector3(2.5f, 2.5f, 2.5f);

        
        if (movement != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) {
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
        else if (!Input.GetKey(KeyCode.LeftShift)) {
            anim.SetInteger("Walk", 0);
        }
        else {
            snowpoint = 0;
            snowball.transform.localScale = new Vector3(0, 0, 0);
            //transform.position = new Vector3(transform.position.x, 2.07f, transform.position.z);
            if (movement == Vector3.zero) {
                //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
                anim.SetInteger("Walk", 0);
                //transform.position = new Vector3(transform.position.x, 2.07f, transform.position.z);
            } else {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
                transform.eulerAngles = new Vector3(90, transform.eulerAngles.y, transform.eulerAngles.z);
                movement = new Vector3(moveHorizontal * 2, 0.0f, moveVertical * 2);
                moveHorizontal /= 2;
                moveVertical /= 2;
            }
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (false && Time.time > canJump)
        {
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
        }
    }

    void eliminate() {
        Destroy(penguin);
        Destroy(snowball);
        
        
 
        StartCoroutine(losingScreen());

        //if (Input.GetKeyDown(KeyCode.Return)) {
      //      SceneManager.LoadScene(0);
        //}
        if (newFrameNum > frameNum) {
            newFrameNum = frameNum;
        }
        if (frameNum < newFrameNum + 30000) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                SceneManager.LoadScene(0);        
            }
        }
        this.enabled = false;
    }
    
    //void OnTriggerEnter(Collider other)
    //{
    //    eliminate();  
    //}
    IEnumerator losingScreen(){
        // Load the Arial font from the Unity Resources folder.
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        // Create Canvas GameObject.
        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Get canvas from the GameObject.
        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Create the Text GameObject.
        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        // Set Text component properties.
        text = textGO.GetComponent<Text>();
        text.font = arial;
        text.text = "You Lose :(\nPress Enter to Play Again";
        text.fontSize = 48;
        text.alignment = TextAnchor.MiddleCenter;

        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(600, 200);
        //yield return new WaitForSecondsRealtime(3);
        //my code here after 3 seconds
        yield return new WaitForSecondsRealtime(1.5f);
    
     
    }
}