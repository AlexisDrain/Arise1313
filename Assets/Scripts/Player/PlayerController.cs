using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float roationSpeed = 1.8f;
    public float forwardSpeed = 7f;
    public float maxVelocity = 7f;

    [Header("ReadOnly")]
    public int _isRotating = 0;

    [Header("SFX")]
    public AudioSource audioSourceFootsteps;

    public AudioClip deathByFall;

    private Rigidbody myRigidbody;
    private CapsuleCollider myCapsuleCollider;
    //private Animator girlAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myCapsuleCollider = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {

        if (GameManager.playerInBed == true || GameManager.playerInNovelOrSayonara == true || GameManager.playerInNotebook == true
            || GameManager.playerInFoodQuestionnaire == true) {
            myRigidbody.velocity = new Vector3(0f, 0f, 0f);
            return;
        }

        // regular movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0) {
            transform.eulerAngles += new Vector3(0, h * roationSpeed, 0);
            _isRotating = (int)h;
        } else {
            _isRotating = 0;
        }

        if (v != 0) {
            myRigidbody.AddForce(v * transform.forward * forwardSpeed, ForceMode.Impulse);
        } else {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
        }
        // max speed
        Vector3 velocityClamped = Vector3.ClampMagnitude(myRigidbody.velocity, maxVelocity);
        myRigidbody.velocity = new Vector3(velocityClamped.x, myRigidbody.velocity.y, velocityClamped.z);
        
        if(transform.position.y < -15f) {
            GameManager.SpawnLoudAudio(deathByFall, Vector2.one, 0.4f);
            GameManager.KillPlayer();
        }
    }
}
