using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
	
	//private Rigidbody rb;
	private int count;
	
	void Start (){
		//rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		winText.text = "";
	}
	
	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		
		//rb.AddForce (movement * speed);
		this.transform.Translate ( Vector3.forward * moveVertical * speed);
		this.transform.Rotate ( Vector3.up * moveHorizontal * speed* 2.0f);
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count +1;
			setCountText();
		}
	}

	void setCountText(){
		countText.text = "Count: " + count.ToString();
		if (count > 6) {
			winText.text = "You win!!";
		}
	}
}