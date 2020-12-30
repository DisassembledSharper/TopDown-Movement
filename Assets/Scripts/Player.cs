//Importação de bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variável pública que o valor poderá ser trocado quando quiser na engine
    public float Speed;
    //Inicialização das variáveis que irão pegar os componentes no Player
    private Rigidbody2D Rig;
    private Animator Ani;

    //Método que é chamado uma vez ao iniciar
    void Start()
    {
        //As variáveis pegam o componente do Player
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
    }
    //Método que é chamado a cada frame
    void Update()
    {
        #region Movement and animation

        //Essa linha irá fazer a movimentação básica do Player
        Rig.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed);

        //Aqui irão modificar as variáveis float no componente Animator
        //Elas recebem a velocidade X e Y do Player
        Ani.SetFloat("Horizontal", Rig.velocity.x);
        Ani.SetFloat("Vertical", Rig.velocity.y);
        //Essa variável do Animator vai receber a velocidade geral do Player
        Ani.SetFloat("Speed", Rig.velocity.magnitude);

        //Se a velocidade X do Player for maior que 0 (indo pra direita) a variável recebe 1
        if (Rig.velocity.x > 0f) Ani.SetInteger("Direction", 1);
        //Ou se a velocidade X do Player for menor que 0 (indo pra esquerda) a variável recebe 3
        else if (Rig.velocity.x < 0f) Ani.SetInteger("Direction", 3);
        //Se a velocidade Y do Player for maior que 0 (indo pra cima) a variável recebe 0
        if (Rig.velocity.y > 0f) Ani.SetInteger("Direction", 0);
        //Ou se a velocidade Y do Player for menor que 0 (indo pra baixo) a variável recebe 2
        else if (Rig.velocity.y < 0f) Ani.SetInteger("Direction", 2);

        #endregion
    }
}
