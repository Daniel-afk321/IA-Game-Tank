using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshManager : MonoBehaviour
{
    //Um array pegando os agentes
    GameObject[] agents;

    private void Start()
    {
        //Procurando os agentes pela tag do tipo IA
        agents = GameObject.FindGameObjectsWithTag("IA");
    }

    private void Update()
    {
        //Onde o mouse clicar
        if (Input.GetMouseButtonDown(0))
        {
            //Cria uma linha que bate com os componentes da cena
            RaycastHit hit;

            //Física que pega a posição que o mouse está 
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                foreach(GameObject a in agents)
                {
                    //Cria o destino em que o agente irá
                    a.GetComponent<AIControl>().agent.SetDestination(hit.point);
                }
            }
        }
    }
}
