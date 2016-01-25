using UnityEngine;
using System.Collections;

public enum myColors
{
	Blue,
	Green
}

public class GameController : MonoBehaviour {

	public Player player1;
	public Player player2;
	//private myColors mycolor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A))
			player1.moveHorizontal (-1);
		if (Input.GetKey (KeyCode.D))
			player1.moveHorizontal (1);
		if (Input.GetKey (KeyCode.W))
			player1.moveVertical (1);
		if (Input.GetKey (KeyCode.S))
			player1.moveVertical (-1);

		if (Input.GetKey (KeyCode.LeftArrow))
			player2.moveHorizontal (-1);
		if (Input.GetKey (KeyCode.RightArrow))
			player2.moveHorizontal (1);
		if (Input.GetKey (KeyCode.UpArrow))
			player2.moveVertical (1);
		if (Input.GetKey (KeyCode.DownArrow))
			player2.moveVertical (-1);
	}
}
