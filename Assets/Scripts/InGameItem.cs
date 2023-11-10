using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/In Game Item")]
public class InGameItem : ScriptableObject
{
    [Header("UI")]
    public string ItemName;
    public string Description;
}
