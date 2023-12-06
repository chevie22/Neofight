using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Explosion_Chevie : MonoBehaviour
{
    private Rigidbody2D playerObjectRb;

    public GameObject explosionAnimationObject;
    public GameObject playerObject;
    public SpriteRenderer catSr;

    //achievement
    [SerializeField] public GameObject panel;
    public CreateAchievement[] newAchievement;
    public TMPro.TextMeshProUGUI title; 


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
            explosionAnimationObject.transform.position = transform.position;
            explosionAnimationObject.SetActive(true);
            Destroy(transform.parent.gameObject);
            playerObjectRb.velocity = new Vector2(playerObjectRb.velocity.x, 8.5f);
            ///JSON
            //index 2 achievement = cat slayer
            LoadFromJson(2);

            //Instantiate(explosionAnimationObject, transform.position, transform.rotation);

            

            //catSr.color = new Color(255, 255, 255, 0);
            //this.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    //achievements JSON
    //just copy paste
    //the index is the achievement index
    public void LoadFromJson(int index)
    {
        //load json file
        string json = File.ReadAllText(Application.dataPath + "/json/AchievementJSON.json");
        AchievementJson data = JsonUtility.FromJson<AchievementJson>(json);

        bool[] loadData;
        bool[] loadNotify;
        loadData = new bool[4];
        loadNotify = new bool[4];
        for(int i = 0; i < 4; i++)
        {
            loadData[i] = data.achievementUnlock[i];
            loadNotify[i] = data.achievementNotify[i];
        }
        loadData[index] = true;

        if (loadData[index] && !loadNotify[index])
        {
            Debug.Log("open panel");
            Animator animator = panel.GetComponent<Animator>();
            if(animator != null)
            {
                //pop notification of new achievement
                title.text = newAchievement[index].name;
                animator.SetBool("open", true);
                loadNotify[index] = true;
                
                //wait for a few seconds before pop-up disappear
                StartCoroutine(AchievementNotify(5, animator));
            }

        }

        SaveToJson(loadData, loadNotify);
    }

    public void SaveToJson(bool[] loadData, bool[]loadNotify)
    {
        AchievementJson data = new AchievementJson();
        data.achievementUnlock = new bool[4];
        data.achievementNotify = new bool[4];

        for(int i = 0; i < 4; i++)
        {
            data.achievementUnlock[i] = loadData[i];
            data.achievementNotify[i] = loadNotify[i];
        }

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath + "/json/AchievementJSON.json", json);
    }

    IEnumerator AchievementNotify(float waitTime, Animator animator)
    {
        yield return new WaitForSeconds(waitTime); 
        Debug.Log("open animator"); 
        animator.SetBool("open", false);
        Destroy(transform.parent.gameObject);
    }
}
