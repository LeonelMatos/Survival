using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Locks all external input. Used at the terminalUI for writing
    public bool INPUT_LOCK { get; private set; }

    private void Awake () {
        INPUT_LOCK = false;
    }

    public void setInputLock() {
        INPUT_LOCK = INPUT_LOCK ? false : true;
        Debug.Log("Changed input lock state to " + INPUT_LOCK);
    }

    public void defineInputLock(bool state) {
        INPUT_LOCK = state;
    }
}
