using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PLayer : MonoBehaviour
{
    public int Score = 0;
    float x = 0f;
    float y = 0f;
    public float jumpForce = 2f;
    public float speed = 5f;
    public float Gravity = 0.055f;
    public Rigidbody2D rb;
    public Text coinDisplay;
    public GameObject WinningText;
    bool canJump = false;
    void Update()
    {
        coinDisplay.text = "Coins: " + Score;

        if(Score == 3)
        {
            WinningText.SetActive(true);
        }



        x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            y = jumpForce;
            canJump = false;
        }
        y -= Gravity;

        rb.velocity = new Vector2(x * speed * Time.deltaTime, y);
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "ground")
        {
            Debug.Log("I can jump now");
            canJump = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "coin")
        {
            Score += 1;
            Destroy(collider.gameObject);

            Debug.Log("Collected a coin");
        }
    }
}
