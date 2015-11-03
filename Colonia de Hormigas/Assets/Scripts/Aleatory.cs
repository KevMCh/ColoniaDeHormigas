using UnityEngine;
using System.Collections;

public class Aleatory: MonoBehaviour {

	
	public GameObject objt;
	public float speed;

	private Vector3 Sit;
	
	void Start (){
		
		System.Random rnd = new System.Random(System.DateTime.Now.Millisecond + (int) objt.transform.position.x + (int) objt.transform.position.z);
		
		float x = rnd.Next(1, 496);
		float z = rnd.Next(4, 496);

		objt.transform.position = new Vector3(x, 1.8f, z);
		searchRotation ();
	}

	void Update (){

		if(!(isBorder(objt.transform.position.x, objt.transform.position.z))){

			System.Random rnd = new System.Random(System.DateTime.Now.Millisecond + (int) objt.transform.position.x + (int) objt.transform.position.z);

			int value = rnd.Next (-1,20);

			if(value == 0){

				searchRotation();
			}

			move ();

		}else{
		
			searchRotation ();
		}
	}

	void searchRotation(){

		float yR = getRotation ();
			
		objt.transform.Rotate (new Vector3 (0, yR, 0) * Time.deltaTime);

		move ();

	}

	bool isBorder(float x, float z){

		if (((x >= 496) || (x<=1)) ||
		    ((z >= 496) || (z<=4))){

			return true;
		
		} else {

			return false;
		}
	}

	float getRotation(){

		System.Random rnd = new System.Random(System.DateTime.Now.Millisecond + (int) objt.transform.position.x + (int) objt.transform.position.z);

		if ((isBorder(objt.transform.position.x, objt.transform.position.z))) {

			return rnd.Next (1, 180);
		
		} else {

			return rnd.Next (-90, 90);
		}
	}

	void move(){

		objt.transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
