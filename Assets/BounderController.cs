using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BounderController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private BBEventManager em;

    private void Awake () {
        em = FindObjectOfType<BBEventManager>();
        em.onVictory += Win;
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Stick (Transform parent) {
        myRigidbody.velocity = Vector2.zero;
    }

    public void Win () {
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.angularVelocity = 0f;
    }
}
