using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Entry {
    public string command;

    public short time_hour;
    public short time_minute;
    public short time_second;
}

[Serializable]
public class Terminal : MonoBehaviour
{
    readonly string[] Commands =
    {
        "echo",
        "help",
        "list",
        "exit",
        "quit",
        "stop",
        "clear",
        "sethealth",
    };


    private TerminalUI terminalUI;

    [SerializeField]
    private List<Entry> history;
    private int historyIndex = 0;

    private void Start () {
        terminalUI = GetComponent<TerminalUI>();

        history = new List<Entry>
        {
            new Entry() { command = "<color=yellow>Survival</color>" }
        };
        historyIndex = history.Count;
    }

    private string[] parseCommand (string command) {
        string[] cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        return cmd;
    }

    public void updateOutput () {
        terminalUI.writeOutput(ref history);
    }

    public void setCommand(string commandInput) {
        DateTime now = DateTime.Now;

        history.Add(new Entry() 
        { command = commandInput,
          time_hour = (short) now.Hour,
          time_minute = (short) now.Minute,
          time_second = (short) now.Second
        });
        historyIndex = history.Count;
        updateOutput();

        runCommand(parseCommand(commandInput));
    }

    private void debugMessage(string output) {
        history.Add(new Entry() { command = output });
        updateOutput();
    }

    bool strcmp (string str1, string str2) { return string.Equals(str1, str2); }

    //BUG: writing "-" unhandled
    private void runCommand(string[] cmd) {
        if (cmd.Length < 1) { return; }
        if (strcmp(cmd[0], Commands[0])) { //echo
            if (cmd.Length < 2)
                debugMessage("");
            else
            {
                string output = "";
                for (int i = 1; i < cmd.Length ; i++)
                    output += cmd[i] + " ";
                debugMessage(output);
            }
            return;
        }
        
        if (strcmp(cmd[0], Commands[1]) || strcmp(cmd[0], Commands[2])) //help/list
        {
            debugMessage("Showing all commands:\n");

            string row = "\t";
            for (int i = 0; i < Commands.Length; i++)
            {
                row += Commands[i] + "\t";
                if ((i+1) % 4 == 0 || i == Commands.Length - 1)
                {
                    debugMessage(row + "\n");
                    row = "\t";
                }
            }
            return;
        }

        if (strcmp(cmd[0], Commands[3]) || strcmp(cmd[0], Commands[4])) //quit/exit
        {
            if ((cmd.Length > 1) && cmd[1] == "f")
            {
                Application.Quit();
                Debug.Log("Quit");
            }
            else
            {
                debugMessage("<color=red>Exiting the game in 5 seconds</color>");
                debugMessage("You can cancel by writing <color=yellow>stop</color>");

                StartCoroutine(QuitGame());
            }
            return;
        }

        if (strcmp(cmd[0], Commands[5])) //stop
        {
            StopAllCoroutines();
            debugMessage("Stopped all coroutines");
            return;
        }

        if (strcmp(cmd[0], Commands[6])) //clear
        {
            history.Clear();
            updateOutput();
            return;
        }

        if (strcmp(cmd[0], Commands[7])) //sethealth
        {
            if (cmd.Length < 2)
            {
                debugMessage("<color=yellow>[USAGE]</color>: sethealth <color=yellow>[value]</color>");
                return;
            }

            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.setHealth(int.Parse(cmd[1]));
            return;
        }

        debugMessage("");

    }

    public string getPreviousCommandHistory() {
        if (historyIndex <= 1)
            return "";
        do
        {
            historyIndex--;
        }
        while (history[historyIndex].time_hour == 0 && historyIndex > 0);
        return history[historyIndex].command;
    }

    public string getNextCommandHistory() {
        if (historyIndex == history.Count)
            return "";

        while (history[historyIndex].time_hour == 0 && historyIndex < history.Count)
        {
            historyIndex++;
        }

        /*do
        {
            historyIndex++;
        }
        while (history[historyIndex].time_hour == 0 && historyIndex < history.Count);*/
        return history[historyIndex].command;
    }

    private IEnumerator QuitGame() {
        yield return new WaitForSeconds(5f);
        Application.Quit();
        Debug.Log("Quit");
    }


}
