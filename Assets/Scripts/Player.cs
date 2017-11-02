using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private Rigidbody rb;

	private int score = 0;
	public Text ScoreText;


	private bool ismovingright = false;
	[HideInInspector]
	public bool canmove=true;

	[SerializeField]
	float speed=4f;

	[SerializeField]
	GameObject particle;

	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	//controlar la bola con el raton
	void Update () {
		if (Input.GetMouseButtonDown (0)&& canmove) {



			ChangeBoolean();
			ChangeDirection ();
		}
		if (Physics.Raycast (this.transform.position, Vector3.down * 2) == false) {
			FallDown ();
		}
	}

	//Gravedad de la bola
	private void FallDown(){
		canmove = false;
		rb.velocity = new Vector3 (0f, -4f, 0f);
	}


	private void ChangeBoolean()
	{
		ismovingright = !ismovingright;
	}

	private void ChangeDirection(){
		if (ismovingright) {
			rb.velocity = new Vector3 (speed, 0f, 0f);

		} else {
			rb.velocity = new Vector3 (0f, 0f, speed);
		}
	}
	//Hacer desaparecer los cuadrados
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Gem") {
			
			Destroy (col.gameObject);

			GameObject _particle = Instantiate (particle) as GameObject;
			_particle.transform.position = this.transform.position;
			Destroy (_particle, 1f);

		
		}
	}
}