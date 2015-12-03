using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerController : MonoBehaviour {
	
	public float speed;
	public Text countText1;
	public Text countText2;
	public Text winText1;
	public Text winText2;

	private int count;
	
	void Start (){

		count = 0;
		setCountText ();
		winText1.text = "";
		winText2.text = "";
	}
	
	void FixedUpdate (){

		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		this.transform.Rotate ( Vector3.up * moveHorizontal * speed* 2.0f);*/

		this.transform.Translate ( Vector3.forward * Time.deltaTime * speed);

	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")){

			if(other.gameObject.activeSelf){

				other.gameObject.SetActive (false);
				count = count +1;
				setCountText();
			}
		}
	}

	void setCountText(){
		countText1.text = "Count: " + count.ToString();
		countText2.text = "Count: " + count.ToString();

		if ((count > 6)&&(winText1.text == "")&&(winText2.text == "")){

			winText1.text = "You win!!";
			winText2.text = "You win!!";
		}
	}
}