using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class movementEnemy : MonoBehaviour {
	
	public GameObject[] HitosPatronMovimiento;
	public float Speed;
	public Text winText;
	
	private Transform thisTransform;
	private Rigidbody thisRigidbody;
	private int HitoSiguiente;
	private double [] dist;
	private bool Terrestre;

	private void swap(int i, int j){
		
		GameObject tmp = HitosPatronMovimiento[i];
		HitosPatronMovimiento[i] = HitosPatronMovimiento[j];
		HitosPatronMovimiento[j] = tmp;
	}

	private void order(){
		
		for (int i = HitoSiguiente; i < HitosPatronMovimiento.Length - 1; i++){
			
			for (int k = i, j = i + 1; j <HitosPatronMovimiento.Length; j++){
				
				if (dist[j] < dist[k]){
					
					k = j;
				}
				
				if (k != i){
					
					swap(i, k);
				}
			}
		}
	}

	private void sortCubes(){
		
		for (int i=0; i<HitosPatronMovimiento.Length; i++) {
			
			dist[i] = Math.Sqrt(Math.Pow ((this.transform.position.x - HitosPatronMovimiento[i].transform.position.x), 2) + Math.Pow ((this.transform.position.z - HitosPatronMovimiento[i].transform.position.z), 2));
		}
		
		order ();
		
	}

	private void setCountText(){
		
		if (HitoSiguiente >= 6) {
			winText.text = "You lose!!";
		}
	}

	private bool goCube(Vector3 PosicionHito){

		//Calculamos la distancia entre la hormiga y el cubo más cercano
		sortCubes ();

		//Calculamos la distancia entre el hito y el objeto
		Vector3 VectorHaciaObjetivo = PosicionHito - thisTransform.position;

		this.transform.LookAt(HitosPatronMovimiento[HitoSiguiente].transform);

		if (Terrestre){

			//Si estamos en modo 'Terrestre', calculamos la distancia ignorando el eje Y
			VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 0, VectorHaciaObjetivo.z);
		
		}
		
		//Con esta condición comprobamos si el objetivo aún no ha llegao a las coordenadas del hito
		if (Math.Abs(VectorHaciaObjetivo.x) > 0.2F ||
		    Math.Abs(VectorHaciaObjetivo.y) > 0.2F ||
		    Math.Abs(VectorHaciaObjetivo.z) > 0.2F){

			//Calculamos el vector de movimiento hacia el hito
			VectorHaciaObjetivo.Normalize();
			VectorHaciaObjetivo *= Speed;
			VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x,
			                                  VectorHaciaObjetivo.y,
			                                  VectorHaciaObjetivo.z);

			//Movemos el objeto hacia el hito
			thisTransform.Translate(VectorHaciaObjetivo * Time.deltaTime, Space.World);
			
			//El objetivo aún no ha llegado al hito
			return false;
		
		}else{

			//El objetivo ha llegado al hito
			return true;
		}
	}

	void Start(){

		Speed = 10;
		Terrestre = true;

		thisTransform = transform;
		thisRigidbody = GetComponentInParent<Rigidbody>();

		dist = new double[12];

		HitoSiguiente = 0;
		winText.text = "";
	}

	void Update(){

		//Activamos o desactivamos la gravedad en función de la variable 'Terrestre'
		thisRigidbody.useGravity = Terrestre;
		
		try{

			//Movemos al objeto hacia el siguiente hito
			if (goCube(HitosPatronMovimiento[HitoSiguiente].transform.position)){
					
				//Calculamos cual será el próximo hito si no hay empezamos de nuevo el circuito de hitos
				if (HitoSiguiente != HitosPatronMovimiento.Length - 1){

					HitoSiguiente++;

				}else{

					HitoSiguiente = 0;
				}
			}
		
		}catch{

				HitoSiguiente++;
		}
	}

	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.CompareTag ("Pick Up")){
			HitoSiguiente = HitoSiguiente +1;
			other.gameObject.SetActive (false);
		}

		setCountText ();
	}
}