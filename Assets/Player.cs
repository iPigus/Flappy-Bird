using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    const float minPosY = 5.4f;

    new Rigidbody2D rigidbody;

    [SerializeField] float JumpForce = 10f;
    [SerializeField] float MaxRotation = 25f;

    [SerializeField] GameObject LoseScreen;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI HighestScoreText;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        Rotate();

        if(Mathf.Abs(transform.position.y) >= minPosY) Death();
    }

    void Jump()
    {
        rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    void Rotate()
    {
        rigidbody.rotation = rigidbody.velocity.y > 0 ? Mathf.Lerp(0, MaxRotation, rigidbody.velocity.y / 10) : Mathf.Lerp(0, -MaxRotation, -rigidbody.velocity.y / 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death();
    }

    void Death()
    {
        Time.timeScale = 0f;
        LoseScreen.SetActive(true);
        ScoreText.text = "Your score : " + GameManager.Score;

        int previousHighestScore = PlayerPrefs.GetInt("HighScore", 0);

        if (previousHighestScore >= GameManager.Score)
        {
            HighestScoreText.text = "Highest score : " + previousHighestScore;
        }
        else
        {
            HighestScoreText.text = "New highest score!";
            PlayerPrefs.SetInt("HighScore", GameManager.Score);
        }
    }
}
