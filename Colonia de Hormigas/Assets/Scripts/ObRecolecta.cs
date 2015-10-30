using UnityEngine;
using System.Collections;
using System;

public class ObRecolecta : MonoBehaviour {

	public GameObject objt;
	
	void Start () {

		System.Random rnd = new System.Random(System.DateTime.Now.Millisecond);
		
		//float x = rnd.Next(1, 496);
		//float y = rnd.Next(4, 496);
		
		//objt.transform.position = new Vector3(x, 2.5f, y);
	
	}

	void Update (){
		objt.transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
