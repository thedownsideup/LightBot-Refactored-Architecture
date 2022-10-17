using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandController : MonoBehaviour
{
    [SerializeField] Command command;

    public void OnClick()
    {
        Remove();
    }

    private void Remove()
    {
        Command_Manager.Instance.RemoveCommand(command);
    }
}
