using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Text countText;
    public Text winText;


    private Rigidbody rb; //player's body
    private int count;  //score
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetButton("Jump") && rb.velocity.y == 0) // allows player to jump when jump key is pressed and makes sure that player is not already in the air
        {
            rb.AddForce(new Vector3(0.0f, 500.0f, 0.0f)); //applies a force of 10 in the y direction when player jumps
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))    //causes pickup objects to become inactive when the player comes into contact with them.
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Booster"))
        {
            rb.velocity = rb.velocity * 2.35f;
        }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }
}
