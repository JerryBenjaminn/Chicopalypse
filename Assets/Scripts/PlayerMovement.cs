using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed; //Luodaan muuttuja, joka ohjaa pelaajan nopeutta. SerializeFieldiä käytetään, kun halutaan muuttujan olevan private, mutta näkyvän Unityn editorissa

    [SerializeField] private Rigidbody2D rb; // Luodaan scriptiin Rididbodylle muuttuja, jotta sitä voidaan kutsua
    private bool facingRight = true; // Luodaan boolean muuttuja, jotta pelaajan suunta voidaan varmentaa
    [SerializeField] private float moveDirection; //Luodaan muuttuja, jotta voidaan luoda peliin controllit
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float jumpInterval;


    private void Awake() //Poistetaan Start()-metodi ja luodaan sen tilanne Awake()-metodi. Awake metodia kutsutaan nopeammin, kuin Start-metodia ja se nopeuttaa pelin aloítusta
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal"); //Sijoitetaan  x-koordinaatin liikkuvuus tiettyyn näppäimeen
        rb.velocity = new Vector2(moveDirection * movementSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
