using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowPath : MonoBehaviour
{
    Transform goal;
     float speed = 5.0f;
     float accuracy = 1.0f;
     float rotSpeed = 2.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    //Pegando componentes do outro c�digo com m�todos desse c�digo
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
    }

    //Faz o tank ir para o waypoint 1
    public void GoToHeli()
    {
        g.AStar(currentNode, wps[1]);
        currentWP = 0;
    }

    //Faz o tank ir para o waypoint 6
    public void GoToRuin()
    {
        g.AStar(currentNode, wps[6]);
        currentWP = 0;
    }

    //Faz o tank ir para o waypoint 8
    public void GoToFabri()
    {
        g.AStar(currentNode, wps[8]);
        currentWP = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Se o valor de G for igual a zero ou se o waypoint atual for igual a G, ser� retornado.
        if (g.getPathLength() == 0 || currentWP == g.getPathLength())
        {
            return;
        }

        //O n� que esta mais pr�ximo atualmente.
        currentNode = g.getPathPoint(currentWP);

        //Se a dist�ncia entre a posi��o do ponto de caminho atual e a posi��o do objeto for menor que a definida, o tanque se mover� para o pr�ximo caminho
        if (Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position) < accuracy)
        {
            currentWP++;
        }

        //Se o n�mero de elementos no caminho for maior do que o �ndice do waypoint atual, executa o c�digo.
        if (currentWP < g.getPathLength())
        {
            goal = g.getPathPoint(currentWP).transform;

            //Faz o tank olhar para a dire��o do seu destino
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            //Faz o tank andar para a dire��o determinada e faz tambem a rota��o ser ajustada em dire��o � rota��o desejada, calculada a partir da dire��o especificada.
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            transform.position = Vector3.MoveTowards(transform.position, goal.position, speed * Time.deltaTime);
        }
    }
}
