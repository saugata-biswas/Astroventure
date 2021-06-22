using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Dialogue", menuName = "Pluggables/DialogueRelated/Dialogue", order =0)]
public class Dialogue : ScriptableObject
{
    public string speaker;
    [TextArea(3, 5)]
    public string narration;
    public Statement[] choice;
}
