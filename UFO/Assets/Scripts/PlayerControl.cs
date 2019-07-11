using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private int count;
    public float speed;
    public Text countText;
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  

        count = 0;     
        SetCountText();
        winText.text = "";
    }

    private void Update() {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    
    private void FixedUpdate() 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            
        rb.AddForce(movement * speed);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 12)
        {
            winText.text = "You win!";
        }

    }
}
