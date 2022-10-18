using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Level", menuName ="Level")]
public class Level : ScriptableObject
{
    public int levelNumber;
    public int numberOfLightableBlocks;
    public int numberOfAvailableCommands;
    public GameObject map;
}
     