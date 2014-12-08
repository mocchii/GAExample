using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {
	public int movementspeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)){
			rigidbody.MovePosition(rigidbody.position + new Vector3(-1,0,0)*movementspeed * Time.deltaTime);
			
		}else
		if (Input.GetKey(KeyCode.RightArrow)){
			rigidbody.MovePosition(rigidbody.position + new Vector3(1,0,0)*movementspeed * Time.deltaTime);
		}else
		if (Input.GetKey(KeyCode.UpArrow)){
			rigidbody.MovePosition(rigidbody.position + new Vector3(0,1,0)*movementspeed * Time.deltaTime);
		}else
		if (Input.GetKey(KeyCode.DownArrow)){
			rigidbody.MovePosition(rigidbody.position + new Vector3(0,-1,0)*movementspeed * Time.deltaTime);
		}
	}
}
