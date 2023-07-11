using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TerminalUI : MonoBehaviour
{
	[Required]
	public Controls controls;

	[Required]
	public GameObject terminalPrefab;

	[Required]
	public GameObject canvas;

	private GameObject terminalObject;

	private bool terminal_state = false;

	private GameController gameController;

	private Terminal terminal;

    private void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		terminal = gameObject.GetComponent<Terminal>();
    }

    private void Update()
	{
		if (Input.GetKeyDown(controls.terminal))
		{
			if (!terminal_state)
				InstantiateTerminal();
			else
				KillTerminal();
		}
	}

	//TODO:
	//when writing stop other scripts from reading input.

	private void InstantiateTerminal()
	{
		terminal_state = true;
		terminalObject = Instantiate(terminalPrefab, Vector3.zero, Quaternion.identity);
		terminalObject.transform.SetParent(canvas.transform, false);

		terminal.updateOutput();

		TMP_InputField inputField = terminalObject.transform.GetChild(1).GetComponent<TMP_InputField>();

        inputField.onEndEdit.AddListener(delegate { EnterCommand(); });

		gameController.setInputLock();
	}

	private void KillTerminal() {
		terminal_state = false;
		GameObject.Destroy(terminalObject);

        gameController.setInputLock();
    }

	public void EnterCommand() {
		TMP_InputField inputField = terminalObject.transform.GetChild(1).GetComponent<TMP_InputField>();

		string text = inputField.text;
		inputField.text = "";

		terminal.setCommand(text);
	}

	public void writeOutput(List<string> history) {
		TextMeshProUGUI textBox = terminalObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

		string text = "";

		foreach(string line in history)
		{
			text += line + "\n";
		}

		textBox.SetText(text);
	}

}
