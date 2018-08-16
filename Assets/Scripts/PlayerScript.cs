using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour
{
    public int speed;
    public Rigidbody rb;
    public int jumpStrength;
    public int health;
    public Text HealthText;
    public Text WinText;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (JumpKeyPressed())
        {
            DoJump();
        }
        DoMovement();
        UpdateUIComponents();
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Enemy")
        {
            GetComponent<AudioSource>().Play();
            health = health - 5;
        }

        if (health<=0)
        {
            WinText.text = "You are such a LOSER!";
        }
    }

    bool JumpKeyPressed()
    {
        //TODO: Add support for touch and xbox controller
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }

        return false;
    }

    void DoJump()
    {
        if (rb.position.y < 3)
        {
            Vector3 movement = new Vector3(0f, jumpStrength, 0f);
            rb.AddForce(movement * speed);
        }
    }

    void DoMovement()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    void UpdateUIComponents()
    {
        HealthText.text = "Health: " + health.ToString();
    }
}
