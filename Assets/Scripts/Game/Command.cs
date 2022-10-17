using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Command", menuName = "Command")]
public class Command : ScriptableObject
{
    public int value;
    public Sprite icon;
}
