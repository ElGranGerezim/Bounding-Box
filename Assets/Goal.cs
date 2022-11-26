using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Goal : MonoBehaviour
{
    BBEventManager em;
    private AudioSource myAudioSource;

    private void Awake () {
        em = FindObjectOfType<BBEventManager>();
        myAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D (Collider2D collision) {
        if(collision.gameObject.CompareTag("Bounder"))
        {
            Debug.Log("Bounder has reached goal! Victory!");
            myAudioSource.Play();
            em.Victory();
        }
    }
}
