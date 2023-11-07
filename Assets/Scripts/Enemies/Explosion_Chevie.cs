using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Chevie : MonoBehaviour
{
    private Rigidbody2D playerObjectRb;

    [SerializeField] private GameObject explosionAnimationObject;
    [SerializeField] private GameObject playerObject;


    // Start is called before the first frame update
    void Start()
    {
        playerObjectRb = playerObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerObjectRb.velocity = new Vector2(playerObjectRb.velocity.x, 8.5f);
            Instantiate(explosionAnimationObject, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }
    }
}
