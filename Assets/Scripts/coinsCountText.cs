using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coinsCountText : MonoBehaviour
{

    public GameObject player;
    public PlayerMovement playerMovementScript;
    public TMPro.TextMeshProUGUI m_MyText;
    // Start is called before the first frame update
    void Start()
    {
        m_MyText.text = "Keys: " + playerMovementScript.coinsCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        m_MyText.text = "Keys: " + playerMovementScript.coinsCount.ToString();
    }

   
}
