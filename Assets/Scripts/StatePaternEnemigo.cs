using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePaternEnemigo : MonoBehaviour {


	[SerializeField]
	private GameObject prfabBala;

	[SerializeField]
	private float velocidadBala;


	public Transform inicioDeRay;
	public float radioEsfera;
	public float distanciaMaxima;
	public float ratioDisparo;



	[HideInInspector] public IEstadoEnemigo estadoActual;
	[HideInInspector] public PatrullarEstado estadoPatrulla;
	[HideInInspector] public MuerteEstado estadoMuerto;
	[HideInInspector] public Transform objetivo;


	public float tiempoTranscurrido;
	public float tiempoTranscurrido2;
	public int puntoActual;

	public float tiempoGiro;

	public Vector3[] path = new Vector3[2];

	void Awake ()
	{

		estadoPatrulla = new PatrullarEstado (this);
		estadoMuerto = new MuerteEstado (this);

	}

	// Use this for initialization
	void Start () {
		estadoActual = estadoPatrulla;
	}
	
	// Update is called once per frame
	void Update () {
		tiempoTranscurrido2 += Time.deltaTime;
		estadoActual.UpdateState ();
	}

	public void Shoot()
	{
		GameObject tempBullet = Instantiate (prfabBala, inicioDeRay.position, inicioDeRay.rotation);
		tempBullet.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward*velocidadBala, ForceMode.Impulse);
	}

	public void TimePath ()
	{
		tiempoTranscurrido += Time.deltaTime;
	}

	private void OnDrawGizmos()
	{
		Vector3 startPosition = inicioDeRay.transform.position;

		Vector3 endPosition = startPosition + (transform.forward * distanciaMaxima);
		Debug.DrawLine (startPosition, endPosition);
		Gizmos.DrawWireSphere (endPosition, radioEsfera);
	}
}
