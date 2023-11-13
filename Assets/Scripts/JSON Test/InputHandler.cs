using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {
    [SerializeField] InputField nameInput;
    [SerializeField] InputField descriptionInput;

    List<InputEntry> entries = new List<InputEntry> ();

    public void AddNameToList () {
        entries.Add (new InputEntry (nameInput.text, descriptionInput.text));
        nameInput.text = "";
    }

}