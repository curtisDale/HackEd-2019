using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpLookControl : MonoBehaviour {
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5;
	public float smoothAmount;
	GameObject player;


	void Start () {
		player = this.transform.parent.gameObject;
	}
	

	void Update () {
		var md = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		md = Vector2.Scale(md, new Vector2(sensitivity * smoothAmount, sensitivity * smoothAmount));
		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothAmount);
		smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothAmount);
		mouseLook += smoothV;
        
		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
		                   
	}
}
