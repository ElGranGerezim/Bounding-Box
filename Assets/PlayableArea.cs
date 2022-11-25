using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableArea : MonoBehaviour
{
    private BBEventManager em;
    private void Awake () {
        em = FindObjectOfType<BBEventManager>();
    }

    private void OnTriggerExit2D (Collider2D collision) {
        if(collision.gameObject.CompareTag("Bounder"))
        {
            Debug.Log("Bounder has left play area! Failure!");
            em.BoxEscaped();
        }
    }
}
