using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Rigidbody rb;
	
	public float speed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveHorizontal(float direction)
	{
		rb.MovePosition (transform.position + transform.right * speed * direction);
	}

	public void moveVertical(float direction)
	{
		rb.MovePosition (transform.position + transform.up * speed * direction);
	}

	void changeColor(myColors newcolor)
	{

	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("Colliso");
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag.Equals ("Food")) {
			col.gameObject.SendMessage ("setTarget", this.gameObject.transform);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag.Equals("Food"))
			col.gameObject.SendMessage("unsetTarget");
	}

	void addSpeed(float speedAdder)
	{
		speed += speedAdder;
	}

	void Enlarge(float sizeAdder)
	{
		transform.localScale += new Vector3 (sizeAdder, sizeAdder, sizeAdder);
	}
}
