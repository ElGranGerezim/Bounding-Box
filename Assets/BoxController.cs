using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EdgeCollider2D))]
public class BoxController : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private int vDirection = 0;
    [SerializeField] private int hDirection = 0;
    [SerializeField] private bool sticky = false;
    [SerializeField] private Vector2 minBorder;
    [SerializeField] private Vector2 maxBorder;
    private Rigidbody2D myRigidbody;
    private EdgeCollider2D myEdgeCollider;
    private bool canGoDown = true;
    private bool canGoUp = true;
    private bool canGoLeft = true;
    private bool canGoRight = true;
    private bool frozen = false;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myEdgeCollider = GetComponent<EdgeCollider2D>();
        AddColliderOnCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (frozen) return;
        CheckBorders();

        // Stop all movement
        vDirection = 0;
        hDirection = 0;
        myRigidbody.velocity = Vector2.zero;

        // Update direction based on input
        if(Input.GetKey(KeyCode.W) && canGoUp) vDirection += 1;
        if(Input.GetKey(KeyCode.S) && canGoDown) vDirection -= 1;
        if(Input.GetKey(KeyCode.A) && canGoLeft) hDirection += 1;
        if(Input.GetKey(KeyCode.D) && canGoRight) hDirection -= 1;

        // If we have directions, move
        if(vDirection != 0) myRigidbody.velocity += Vector2.up * vDirection * speed;
        if(hDirection != 0) myRigidbody.velocity += Vector2.left * hDirection * speed;

        // Update stickiness based on input
        sticky = Input.GetKey(KeyCode.Space);
    }


    private void OnCollisionEnter2D (Collision2D collision) {
        if(sticky && collision.gameObject.CompareTag("Bounder"))
        {
            BounderController bounder = collision.gameObject.GetComponent<BounderController>();
            bounder.Stick(transform);
        }
    }

    private void Awake () {
        BBEventManager em = FindObjectOfType<BBEventManager>();
        em.onBoxEscaped += Freeze;
        em.onVictory += Freeze;
    }

    public void AddColliderOnCamera () {
        if(Camera.main == null)
        { Debug.LogError("Camera.main not found, failed to create edge colliders"); return; }

        var cam = Camera.main;
        if(!cam.orthographic)
        { Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders"); return; }

        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        Vector2 topLeft = new Vector2(bottomLeft.x, topRight.y);
        Vector2 bottomRight = new Vector2(topRight.x, bottomLeft.y);

        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
        myEdgeCollider.points = edgePoints;
    }

    private void CheckBorders () {
        float x = transform.position.x;
        float y = transform.position.y;
        canGoUp = y < maxBorder.y;
        canGoDown = y > minBorder.y;
        canGoLeft = x > minBorder.x;
        canGoRight = x < maxBorder.x;
    }

    private void Freeze () {
        frozen = true;
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.angularVelocity = 0f;
    }
}
