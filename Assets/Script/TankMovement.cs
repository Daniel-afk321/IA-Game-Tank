using UnityEngine;
using UnityEngine.AI;

public class TankMovement : MonoBehaviour
{
    //Refer�ncia ao componente NavMeshAgent para controlar o movimento do tank
    private NavMeshAgent agent;

    void Start()
    {
        //Obt�m o componente NavMeshAgent do tank
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Verifica se o bot�o esquerdo do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            //Cria um raio a partir da posi��o do mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vari�vel para armazenar informa��es sobre o ponto atingido pelo raio
            RaycastHit hit;
            //Lan�a o raio e verifica se colidiu com algum objeto
            if (Physics.Raycast(ray, out hit))
            {
                //Chama o m�todo MoveTank passando o ponto atingido como destino do movimento
                MoveTank(hit.point);
            }
        }
    }

    void MoveTank(Vector3 destination)
    {
        //Define o destino do NavMeshAgent para o ponto especifico
        agent.SetDestination(destination);
    }
}
