using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalUI : MonoBehaviour
{
	[Required]
	public Controls controls;

	private void Update()
	{
		if (Input.GetKey(controls.terminal))
		{
			InstantiateTerminal();
		}
	}

	//TODO:
	//when writing stop other scripts from reading input.

	private void InstantiateTerminal()
	{
		GameObject terminalUI = new GameObject("TerminalUI");

		
	}
}
