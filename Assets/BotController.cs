using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    public float frameNum = 0;
    private Text text;
    public float moveHorizontal = 0f;
    public float moveVertical = 0f;
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
    }

    void eliminate() {
        Destroy(botPenguin);
        Destroy(botSnowball);
        
        StartCoroutine(winningScreen());

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
    IEnumerator winningScreen(){
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
        text.text = "You Win :)";
        //text.text += "\nPress Enter to Play Again";
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