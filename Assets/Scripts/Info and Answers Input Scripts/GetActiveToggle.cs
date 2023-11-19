using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GetActiveToggle : MonoBehaviour
{
    public UnityEngine.UI.ToggleGroup toggleGroup; 
    public UnityEngine.UI.Toggle[] toggles;

    void Start()
    {

    }

    void Update()
    {
        Debug.Log(LogSelectedToggle());
    }

    //I wanna return an int depending on what toggle is pressed yawa
    public int LogSelectedToggle()
    {
        // OR

        Toggle selectedToggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if (selectedToggle != null)
            switch (selectedToggle.name)
            {
                case "Choice1Toggle":
                    return 1;
                case "Choice2Toggle":
                    return 2;
                case "Choice3Toggle":
                    return 3;
                case "Choice4Toggle":
                    return 4;
            } return 0; 
    }

    //plan 2 
    Toggle GetSelectedToggle()
    {
        foreach (var t in toggles)
            if (t.isOn) return t;  //returns selected toggle
        return null;           // if nothing is selected return null
    }
}
