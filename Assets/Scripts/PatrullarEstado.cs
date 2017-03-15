using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullarEstado : IEstadoEnemigo {

	private readonly StatePaternEnemigo enemy;

	public PatrullarEstado(StatePaternEnemigo statePaternEnemy)
	{
		enemy = statePaternEnemy;
	}

	public void UpdateState (){
		RotateTurret ();
		CheckTime ();
		Look ();
		enemy.TimePath ();
	}

	public void ToKillState (){
		enemy.estadoActual = enemy.estadoMuerto;
	}

	public void ToPatrolState (){
		
	}

	void Look()
	{
		RaycastHit hit;
	
		if (Physics.SphereCast(enemy.inicioDeRay.position,enemy.radioEsfera,enemy.inicioDeRay.forward,out hit,enemy.distanciaMaxima))
		{
			if (hit.collider.gameObject.tag == "player") {
				enemy.objetivo = hit.transform;
				ToKillState ();
			}
				
		}

	}

	void RotateTurret()
	{
		Vector3 rotationNow = Vector3.Lerp (enemy.path [enemy.puntoActual], enemy.path [(enemy.puntoActual+1)%enemy.path.Length], enemy.tiempoTranscurrido / enemy.tiempoGiro);

		enemy.transform.eulerAngles = rotationNow;

	}

	void CheckTime ()
	{

		if (enemy.tiempoTranscurrido >= enemy.tiempoGiro) 
		{

			enemy.puntoActual ++;
			enemy.puntoActual = enemy.puntoActual % enemy.path.Length;
			enemy.tiempoTranscurrido = 0;

		}

	}
}
