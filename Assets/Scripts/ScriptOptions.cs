using UnityEditor;
using UnityEngine;

public class ScriptOptions
{
    //Disables the auto refresh compiling process
    //after every change in the scripts


    //Toggle option in the editor: selects status
    [MenuItem("Compiler/AutoRefresh")]
    static void AutoRefresh() {
        int status = EditorPrefs.GetInt("kAutoRefresh");

        if (status == 1)
        {
            EditorPrefs.SetInt("kAutoRefresh", 0);
            Debug.Log($"Changed current auto compiling process to automatic {status}");
        }
        else
        {
            EditorPrefs.SetInt("kAutoRefresh", 1);
            Debug.Log($"Changed current auto compiling process to manual {status}");
        }
    }


}
