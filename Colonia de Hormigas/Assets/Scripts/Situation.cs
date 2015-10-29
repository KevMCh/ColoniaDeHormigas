using UnityEngine;
using System.Collections;

public class Situation : MonoBehaviour {

	public GameObject objt;
	
	void Start () {

		System.Random rnd = new System.Random();
		
		float x = rnd.Next(1, 496);
		float y = rnd.Next (4, 496);
		
		objt.transform.position = new Vector3(x, 0.69f, y);
	
	}
}
