using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatMenu : MonoBehaviour
{
    private BBEventManager em;
    private Animator myAnimator;
    private void Awake () {
        em = FindObjectOfType<BBEventManager>();
        em.onBoxEscaped += Appear;
        myAnimator = GetComponent<Animator>();
    }

    void Appear () {
        myAnimator.SetTrigger("Appear");
    }
}
