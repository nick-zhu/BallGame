using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rd;
	private int count;

	public float speed;
	public Text countText;
	public Text winText;

	void Start () {
		rd = GetComponent<Rigidbody> ();
		count = 0;
		winText.text = "";
		SetText ();
	}
	

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rd.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			SetText ();
		}
	}

	void SetText () {
		countText.text = "Total count: " + count.ToString();
		if (count >= 12) {
			winText.text = "YOU WIN";
		}
	}

}
