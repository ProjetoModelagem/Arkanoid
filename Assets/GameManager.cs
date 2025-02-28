using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public GUISkin layout; // Fonte e estilo do placar na tela

    void Start()
    {
        Debug.Log("Jogo iniciado! Score: " + score + ", Vidas: " + lives);
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Pontos adicionados! Score atual: " + score);
        CheckWinCondition();
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Vida perdida! Vidas restantes: " + lives);

        if (lives <= 0)
        {
            SceneManager.LoadScene("LoserScene");
        }
        else
        {
            ResetBall();
        }
    }

    void CheckWinCondition()
    {

            if (SceneManager.GetActiveScene().name == "Lv1" && score == 160)
            {
                SceneManager.LoadScene("Lv2");
            }
            else if (SceneManager.GetActiveScene().name == "Lv2" && score == 270)
            {
                SceneManager.LoadScene("WinScene");
            }

    }

    void ResetBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball)
        {
            ball.transform.position = Vector3.zero;
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * 5f;
        }
    }

    // Exibir placar na tela
    void OnGUI()
    {
        GUI.skin = layout;

        // Exibir score e vidas
        GUI.Label(new Rect(Screen.width / 2 - 100, 20, 200, 50), "Score: " + score);
        GUI.Label(new Rect(Screen.width / 2 - 100, 50, 200, 50), "Lives: " + lives);

        // Botão de reiniciar jogo
        if (GUI.Button(new Rect(Screen.width / 2 - 35, 80, 70, 30), "RESTART"))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        score = 0;
        lives = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
