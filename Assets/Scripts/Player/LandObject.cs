using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandObject : MonoBehaviour
{
    [SerializeField] private AudioSource landSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!landSound.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
