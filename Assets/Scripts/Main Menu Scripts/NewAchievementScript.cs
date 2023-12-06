using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAchievementScript : MonoBehaviour
{
    public CreateAchievement[] newAchievement;
    public TMPro.TextMeshProUGUI title;
    // Start is called before the first frame update
    void Start()
    {
        title.text = newAchievement[0].name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}


