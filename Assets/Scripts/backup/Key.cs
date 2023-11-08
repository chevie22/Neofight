using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new", menuName = "New Information")]
public class Key : ScriptableObject
{
   public new string name;
   public string description;

   public void Print()
   {
    Debug.Log(name + ": " + description);
   }

}
