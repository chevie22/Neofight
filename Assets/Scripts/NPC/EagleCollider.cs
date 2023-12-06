using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleCollider : MonoBehaviour
{
    public GameObject player;
    private bool collided = false;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(collided)
            {
                canvas.gameObject.SetActive(true);
                collided = false;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                collided = true;
            }

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
            canvas.gameObject.SetActive(true);
            canvas.gameObject.SetActive(false);
            collided = false;  
        }
    }
}
