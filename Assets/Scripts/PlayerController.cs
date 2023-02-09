using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 1f;
    public Rigidbody rig;
    public int score;
    public TextMeshProUGUI scoreText;

    bool isGrounded;
    

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        Vector3 vel = rig.velocity;
        vel.y = 0;

        if ((vel.x != 0) || (vel.z != 0))
        {
            transform.forward = vel;

        }
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (transform.position.y <= -5)
        {
            GameOver();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // If we collided with a ground surface, we are grounded.
        if (collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
