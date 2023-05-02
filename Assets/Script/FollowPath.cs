using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowPath : MonoBehaviour
{
    Transform goal;
    public float speed = 5.0f;
    public float accuracy = 1.0f;
    public float rotSpeed = 2.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    //Pegando componentes do outro código com métodos desse código
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
        g.AStar(currentNode, wps[9]);
        currentWP = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Se o G for zero ou o waypoint atual for igual a G, retornará
        if (g.getPathLength() == 0 || currentWP == g.getPathLength())
            return;


        //O nó que estará mais próximo neste momento
        currentNode = g.getPathPoint(currentWP);


        //se estivermos mais próximo bastante do nó o tanque se moverá para o próximo
        if (Vector3.Distance(g.getPathPoint(currentWP).transform.position,transform.position) < accuracy)
        {
            currentWP++;
        }

        //Se o tamanho do caminho for maior que o waypoint atual
        if (currentWP < g.getPathLength())
        {
            goal = g.getPathPoint(currentWP).transform;

            //Faz o tank olhar para a direção do seu destino
            Vector3 lookAtGoal = new Vector3(goal.position.x,this.transform.position.y,goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            //Faz o tank andar para a direção determinada e também uma curva ao ir ao local
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * rotSpeed);
        }
    }
}
