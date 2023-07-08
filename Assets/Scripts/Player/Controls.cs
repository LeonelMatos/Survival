using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Controls : ScriptableObject
{
    [Title("Player", "", TitleAlignments.Centered)]
    public KeyCode interact = KeyCode.E;

	[Title("Movement", "", TitleAlignments.Centered)]
	public KeyCode run = KeyCode.LeftShift;

	[Title("Terminal", "", TitleAlignments.Centered)]
	public KeyCode terminal = KeyCode.Slash;
}
