using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    [SerializeField] private int deathAnimationTimer = 3;

    [SerializeField] private AudioSource deathSoundEffect;


    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deathSoundEffect.isPlaying)
        {
            StartCoroutine(WaitBeforeDisable(deathAnimationTimer));
        }
    }

    IEnumerator WaitBeforeDisable(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }
}
