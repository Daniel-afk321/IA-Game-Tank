using UnityEngine;
using UnityEngine.AI;

public class TankMovement : MonoBehaviour
{
    //Referência ao componente NavMeshAgent para controlar o movimento do tank
    private NavMeshAgent agent;

    void Start()
    {
        //Obtém o componente NavMeshAgent do tank
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Verifica se o botão esquerdo do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            //Cria um raio a partir da posição do mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Variável para armazenar informações sobre o ponto atingido pelo raio
            RaycastHit hit;
            //Lança o raio e verifica se colidiu com algum objeto
            if (Physics.Raycast(ray, out hit))
            {
                //Chama o método MoveTank passando o ponto atingido como destino do movimento
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
