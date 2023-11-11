using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPortal : MonoBehaviour
{
    public PlayerMovement PMScript;
    public GameObject player;
    public GameObject exit;
    public GameObject canvas;
    private Vector3 exitPos;
    private bool collided = false;
    void Start()
    {
        exitPos = exit.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && collided)
        {
            player.transform.position = exitPos;
            canvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collided = true;  
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collided = false;  
        }
    }
}