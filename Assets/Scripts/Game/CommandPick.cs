using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPick : MonoBehaviour
{
    [SerializeField] private Command command;
    public void OnClick()
    {
        Command_Manager.Instance.AddCommand(command);
    }
}
