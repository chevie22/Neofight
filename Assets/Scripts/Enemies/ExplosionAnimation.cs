using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    Animator animator;

    [SerializeField] private int deathAnimationTimer = 3;
    [SerializeField] public GameObject panel;

    [SerializeField] private AudioSource deathSoundEffect;


    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        animator = panel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathSoundEffect.isPlaying)
        {
            StartCoroutine(WaitBeforeDisable(deathAnimationTimer, animator));
        }
    }

    IEnumerator WaitBeforeDisable(int time, Animator animator)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("hi!!!!!!!!!!!!!!!!!!!"); 
        animator.SetBool("open", false);
        Destroy(gameObject);
    }
}
