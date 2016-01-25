using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	public float rotationSpeed;
	public float speed;

	private Transform target;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.LookAt (target.position, transform.up);
			transform.RotateAround (target.position, transform.right, Time.deltaTime*rotationSpeed);	
			rb.MovePosition(transform.position + transform.forward * speed);
		}
	}

	void setTarget( Transform newtarget)
	{
		target = newtarget;
		transform.SetParent (target);
	}

	void unsetTarget()
	{
		target = null;
		transform.SetParent (null);
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("Colliso");
		if (col.gameObject.tag.Equals ("Player"))
			Destroy (this.gameObject);
	}
}
