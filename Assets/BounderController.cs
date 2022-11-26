using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class BounderController : MonoBehaviour
{
    [SerializeField] private AudioClip[] bounceEffects;
    [SerializeField] private AudioClip deathSFX;
    private Rigidbody2D myRigidbody;
    private AudioSource myAudioSource;
    private BBEventManager em;
    private bool frozen = false;

    private void Awake () {
        em = FindObjectOfType<BBEventManager>();
        em.onVictory += Win;
        em.onBoxEscaped += Die;
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Update () {
        if(frozen)
        {
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.angularVelocity = 0f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Stick (Transform parent) {
        myRigidbody.velocity = Vector2.zero;
    }

    public void Win () {
        frozen = true;
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.angularVelocity = 0f;
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if(Random.Range(0, 11) > 5 && !frozen)
        {
            int soundIndex = Random.Range(0, bounceEffects.Length);
            myAudioSource.PlayOneShot(bounceEffects[soundIndex]);
        }
    }

    private void Die () {
        AudioSource.PlayClipAtPoint(deathSFX, transform.position, 1);
        Destroy(gameObject);
    }
}
