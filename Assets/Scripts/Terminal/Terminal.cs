using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Terminal : MonoBehaviour
{
    private TerminalUI terminalUI;

    [SerializeField]
    private List<string> history;

    private void Start () {
        terminalUI = GetComponent<TerminalUI>();
    }

    public void setCommand(string command) {
        history.Add(command);
        updateOutput();
    }

    public void updateOutput() {
        terminalUI.writeOutput(history);
    }

    public string[] Commands = {
        "setHealth",
        };


}
