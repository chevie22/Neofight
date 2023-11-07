using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Player : MonoBehaviour
{
    public PlayerMovement playerMovementScript;



    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerMovementScript.playerHealth -= 1;

        }
    }

}
