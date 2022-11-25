using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    BBEventManager em;
    private void Awake () {
        em = FindObjectOfType<BBEventManager>();
    }
    private void OnTriggerEnter2D (Collider2D collision) {
        if(collision.gameObject.CompareTag("Bounder"))
        {
            Debug.Log("Bounder has reached goal! Victory!");
            em.Victory();
        }
    }
}
