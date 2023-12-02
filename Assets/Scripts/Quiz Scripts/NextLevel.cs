using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    public PlayerMovement PMS;
    [SerializeField] private GameObject keyRequiredText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && PMS.coinsCount == 5)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            keyRequiredText.SetActive(true);
        }

        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        keyRequiredText.SetActive(false);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && PMS.coinsCount == 5)
        {
            SceneManager.LoadScene(3);
        }
        else{Debug.Log("You need 5 keys to enter!");}
    }*/
}
