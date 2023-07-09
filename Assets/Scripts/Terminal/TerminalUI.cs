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

	private GameObject terminal;

	private bool terminal_state = false;

	private GameController gameController;

    private void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
		Debug.Log("Opened terminal");
		terminal_state = true;
		terminal = Instantiate(terminalPrefab, Vector3.zero, Quaternion.identity);
		terminal.transform.SetParent(canvas.transform, false);

		TMP_InputField inputField = terminal.transform.GetChild(1).GetComponent<TMP_InputField>();

        inputField.onEndEdit.AddListener(delegate { EnterCommand(); });

		gameController.setInputLock();
	}

	private void KillTerminal() {
		Debug.Log("Closed terminal");
		terminal_state = false;
		GameObject.Destroy(terminal);

        gameController.setInputLock();
    }

	public void EnterCommand() {
		Debug.Log("Sending command");
	}

}
