using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Statement", menuName = "Pluggables/DialogueRelated/Statement", order = 1)]
public class Statement : ScriptableObject
{
    [TextArea(3, 5)]
    public string lines;
    public Dialogue NextDialogue; 
}
