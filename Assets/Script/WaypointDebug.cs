using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WaypointDebug : MonoBehaviour {

	// Esta função é usada para renomear os objetos com a tag "wp" na cena.
	// Os objetos são renomeados com o formato "WP" seguido de um número sequencial de três dígitos.
	// O contador 'i' é usado para garantir a numeração correta dos objetos.
	void RenameWPs(GameObject overlook)
	{
		GameObject[] gos;
	    gos = GameObject.FindGameObjectsWithTag("wp"); 
	    int i = 1;
	    foreach (GameObject go in gos)  
	    { 
	     	if(go != overlook)
	     	{
	     		go.name = "WP" + string.Format("{0:000}",i); 
	     		i++; 
	     	} 
	    }	
	}
	//Esta função é executada quando o objeto que contém esse script é destruído.
	void OnDestroy()
	{
		RenameWPs(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		if(this.transform.parent.gameObject.name != "WayPoint") return;
		RenameWPs(null);
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<TextMesh>().text = this.transform.parent.gameObject.name;
	}
}
