using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public KeyCode moveRight = KeyCode.D;      // Move a raquete para cima
    public KeyCode moveLeft = KeyCode.A;    // Move a raquete para baixo
    public float speed = 10.0f;             // Define a velocidade da raquete
    public float boundX = 3f;            // Define os limites em Y
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
    }

    void Update () {

    var vel = rb2d.linearVelocity;                // Acessa a velocidade da raquete
    if (Input.GetKey(moveRight)) {             // Velocidade da Raquete para ir para direita
        vel.x = speed;
    }
    else if (Input.GetKey(moveLeft)) {      // Velocidade da Raquete para ir para esquerda
        vel.x = -speed;                    
    }
    else {
        vel.x = 0;                          // Velociade para manter a raquete parada
    }
    rb2d.linearVelocity = vel;                    // Atualizada a velocidade da raquete

    var pos = transform.position;           // Acessa a Posição da raquete
    if (pos.x > boundX) {                  
        pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    else if (pos.x < -boundX) {
        pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
    }
    transform.position = pos;               // Atualiza a posição da raquete
   
}


}