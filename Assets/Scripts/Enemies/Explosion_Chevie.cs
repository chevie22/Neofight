using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

            ////JSON
            //index 2 achievement = first kill
            LoadFromJson(2);
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

        bool[] load;
        load = new bool[4];
        for(int i = 0; i < 4; i++)
        {
            load[i] = data.achievementUnlock[i];
        }
        load[index] = true;

        SaveToJson(load);
    }

    public void SaveToJson(bool[] load)
    {
        AchievementJson data = new AchievementJson();
        data.achievementUnlock = new bool[4];

        for(int i = 0; i < 4; i++)
        {
            data.achievementUnlock[i] = load[i];
        }

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath + "/json/AchievementJSON.json", json);
    }
}
