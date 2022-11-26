using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayableArea : MonoBehaviour
{
    private BBEventManager em;
    private AudioSource myAudioSource;
    private void Awake () {
        em = FindObjectOfType<BBEventManager>();
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D (Collider2D collision) {
        if(collision.gameObject.CompareTag("Bounder"))
        {
            Debug.Log("Bounder has left play area! Failure!");
            Invoke("PlayDefeat", 1);
            em.BoxEscaped();
        }
    }

    private void PlayDefeat () {
        myAudioSource.Play();
    }
}
