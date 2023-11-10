/*using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    //public Canvas canvas;
    public PlayerMovement playerMovementScript;

    private void Start()
    {
        Debug.Log("ObjectInteraction working!");
    }

    void Update()
    {
        if(playerMovementScript.keyCollected == true)
            {
                this.transform.parent.gameObject.SetActive(false);
                playerMovementScript.keyCollected = false;
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //canvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {      
        if (other.CompareTag("Player"))
        {
            //canvas.gameObject.SetActive(false);
        }
    }
}*/
