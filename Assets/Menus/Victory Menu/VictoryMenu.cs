using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{
    private BBEventManager em;
    private Animator myAnimator;
    private void Awake () {
        em = FindObjectOfType<BBEventManager>();
        em.onVictory += Appear;
        myAnimator = GetComponent<Animator>();
    }

    void Appear () {
        myAnimator.SetTrigger("Appear");
    }
}
