using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private void OnCollisionEnter2D (Collision2D collision) {
        Debug.Log("I've been hit!");
    }
}
