using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody rb;

    private Animation thisAnimation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        
        if (transform.position.y > 4)
        {
            pos.y = 4;
            transform.position = pos;
            rb.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            thisAnimation.Play();
        }

        if (transform.position.y < -4)
        {
            GameManager.thisManager.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            GameManager.thisManager.GameOver();
        }
    }
}
