using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//Struct para criar a conex�o dos nodes
public struct Link
{
    public enum direction { UNI, BI }
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}
public class WPManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();

    // Start is called before the first frame update
    void Start()
    {
        //Se o tamanho do waypoint for maior que 0
        if (waypoints.Length > 0)
        {
            foreach (GameObject wp in waypoints)
            {
                //Adiciona um n�
                graph.AddNode(wp);
            }
            foreach (Link l in links)
            {
                //Adiciona uma aresta do n� 1 ao n� 2
                graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BI)
                    //Adiciona uma aresta ao contr�rio da anterior
                    graph.AddEdge(l.node2, l.node1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Desenha o graph
        graph.debugDraw();
    }
}
