using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEstadoEnemigo{

	void UpdateState ();

	void ToKillState ();

	void ToPatrolState ();

}
