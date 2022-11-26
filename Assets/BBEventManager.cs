using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBEventManager : MonoBehaviour
{
    public delegate void BoxEscapedEvent ();
    public event BoxEscapedEvent onBoxEscaped;
    public void BoxEscaped () {
        onBoxEscaped();
    }

    public delegate void VictoryEvent ();
    public event VictoryEvent onVictory;
    public void Victory () {
        onVictory();
    }
}
