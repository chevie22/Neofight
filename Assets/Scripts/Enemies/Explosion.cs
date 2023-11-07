using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int deathAnimationTimer = 3;
    
    private bool hit;
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool deactive;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private GameObject enemyObject;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        if (deathSoundEffect.isPlaying)
        {
            StartCoroutine(WaitBeforeDisable(deathAnimationTimer));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            boxCollider.enabled = false;


            deathSoundEffect.Play();
            anim.SetTrigger("explosion");
            deactive = true;
        }
    }

    IEnumerator WaitBeforeDisable(int time)
    {
        if(deactive)
        {
            yield return new WaitForSeconds(time);
            enemyObject.SetActive(false);
        }
    }

}
