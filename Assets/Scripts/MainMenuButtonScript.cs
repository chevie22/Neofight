using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button Button = this.GetComponent<Button>();
        Button.onClick.AddListener(MainMenu);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
