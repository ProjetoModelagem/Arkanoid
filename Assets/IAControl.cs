using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public float speed = 15.0f;  // Velocidade da IA
    public float boundX = 5.5f;  // Limite esquerdo e direito
    private Rigidbody2D rb2d;    // Corpo rígido 2D da IA
    private GameObject ball;     // Referência à bola

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        ball = GameObject.FindGameObjectWithTag("Bola");
    }

    void Update()
    {
        if (ball == null)
        {
            Debug.LogError("A bola não foi encontrada! Verifique se a tag 'Bola' foi atribuída corretamente.");
            return;
        }

        // Pegar posição da bola apenas no eixo X
        float newX = Mathf.Clamp(ball.transform.position.x, -boundX, boundX);
        float newY = transform.position.y; // Mantém a posição Y fixa

        // Criar a nova posição
        Vector3 newPos = new Vector3(newX, newY, transform.position.z);

        // Mover suavemente em direção à bola no eixo X
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, newPos, step);
    }
}
