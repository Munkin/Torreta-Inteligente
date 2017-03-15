using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteEstado : IEstadoEnemigo {

	private StatePaternEnemigo enemy;

	public MuerteEstado(StatePaternEnemigo statePaternEnemy)
	{

		enemy = statePaternEnemy;

	}

	public void UpdateState ()
	{
		CheckDistance ();
		RotateToTarget ();
		CheckShoot ();
	}

	public void ToKillState ()
	{

	}

	public void ToPatrolState ()
	{
		enemy.estadoActual = enemy.estadoPatrulla;
	}

	void CheckDistance ()
	{
		float distance =  (enemy.objetivo.position - enemy.transform.position).magnitude;

		if (distance > (enemy.distanciaMaxima+1.5f))
			ToPatrolState ();

	}

	void CheckShoot(){

		if (enemy.tiempoTranscurrido2 > enemy.ratioDisparo) {
		
			enemy.tiempoTranscurrido2 = 0;
			enemy.Shoot ();
		
		}

	}

	void RotateToTarget ()
	{
		enemy.transform.rotation = Quaternion.LookRotation (enemy.objetivo.position-enemy.transform.position);
			
	}

}
