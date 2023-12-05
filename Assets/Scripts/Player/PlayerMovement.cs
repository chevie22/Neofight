using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject explosionAnimationObject;
    [SerializeField] private GameObject playerDeathAnimationObject;
    [SerializeField] private GameObject playerDeathSongObject;
    [SerializeField] private GameObject playerDeathBlurObject;
    [SerializeField] private GameObject playerDeathColorObject;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject test123123;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource landSoundEffect;
    [SerializeField] private AudioSource coinCollectSoundEffect;
    
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 10f;

    private CanvasGroup infoCanvasGroup;


    public int playerHealth = 3;

    private float dirX = 0;

    private Vector3 playerPos;
    private Vector2 explosionPos;
    private bool playerDead = false;

    //keys variable
    public int coinsCount = 0;
    private bool inventory = false;

    //achievement
    [SerializeField] public bool[] achievementUnlock;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        achievementUnlock = new bool[4];
        achievementUnlock[0] = true;
        SaveToJson();

    }

    // Update is called once per frame
    void Update()
    {   
        //open coin info and stop player when info text is open!
        if(Input.GetKeyDown(KeyCode.T) && coinsCount > 0)
        {
            if(inventory == true)
            {
                canvas.gameObject.SetActive(false);
                inventory = false;

            }   
            else{
                Debug.Log("Hi");
                canvas.gameObject.SetActive(true);
                inventory = true;
                rb.velocity = new Vector2(0, rb.velocity.y);
                dirX = 0;
                anim.SetBool("running", false);
                //infoCanvasGroup.alpha = 0;
            }
            
        }

        if(gameObject.transform.position.y <= -25)
        {
            playerDead = true;
        }

        if(playerHealth <= 0)
        {
            playerDead = true;
        }

        if (playerDead == true)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
            Instantiate(playerDeathAnimationObject, transform.position, transform.rotation);
            Instantiate(playerDeathSongObject, transform.position, transform.rotation);
            Instantiate(playerDeathBlurObject, transform.position, transform.rotation);
            playerDeathColorObject.SetActive(true);
            menuUI.SetActive(true);
        }

        playerPos = transform.position; 

        //player movement
        if(!inventory){
            dirX = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            Jump();
            
        }

        anim.SetBool("grounded", IsGrounded());
        //d();

        anim.SetFloat("Velocity", rb.velocity.y);
    }

    private void Jump()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            jumpSoundEffect.Play();
        }

    }


    private void UpdateAnimationState()
    {
        //play animations if idle or running

        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }

    }

    private bool IsGrounded()
    {
        //center, size, angle, direction, distance
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Keys"))
        {
            coinsCount++;
            Destroy(other.gameObject);
            coinCollectSoundEffect.Play();
        }
    }

    public void SaveToJson()
    {
        AchievementJson data = new AchievementJson();
        data.achievementUnlock = new bool[4];
        for(int i = 0; i < 4; i++)
        {
            data.achievementUnlock[i] = achievementUnlock[i];
        }

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath + "/json/AchievementJSON.json", json);
    }
}

