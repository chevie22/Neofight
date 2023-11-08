using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Canvas canvas;
    public GameObject playerObject;


    private void Start()
    {
        Debug.Log("ObjectInteraction working!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {      
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
