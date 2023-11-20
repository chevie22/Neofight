using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GetActiveToggle : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    //return int depending on what toggle was pressed
    public int GetSelectedToggle()
    {
        Toggle[] toggles = GetComponentsInChildren<Toggle>();
        foreach (var t in toggles)
            if (t.isOn)
            {
                switch (t.name)
                {
                    case "Choice1Toggle":
                        return 1;
                    case "Choice2Toggle":
                        return 2;
                    case "Choice3Toggle":
                        return 3;
                    case "Choice4Toggle":
                        return 4;

                }
            }  
        return 0;         
    }
}
