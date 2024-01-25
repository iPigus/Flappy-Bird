using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float MapSpeed = 2f;
    [SerializeField] GameObject Map;

    [SerializeField] float BackgroundSpeed = 1f;
    [SerializeField] GameObject Background;

    [SerializeField] TextMeshProUGUI ScoreText;

    public static int Score = 0;

    private void Update()
    {
        Map.transform.position += MapSpeed * Time.deltaTime * Vector3.left;
        Background.transform.position += BackgroundSpeed * Time.deltaTime * Vector3.left;

        Score = Mathf.FloorToInt(Mathf.Abs(Map.transform.position.x) / 6f);

        ScoreText.text = "Score : " + Score;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
