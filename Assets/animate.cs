using UnityEngine;
using System.Collections;

public class animate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	float x = 1f;
	float speed = .05f;
	
	float y = 1;

	bool up = true;
	// Update is called once per frame
	void Update () {
		if (up) {
			x += speed;
			y += speed;
		} else {
			x -= speed;
			y -= speed;
		}

		Debug.Log (x);

		if (x >= 8) {
			up = false;
		} else if (x <= 0) {
			up = true;
		}

		if (up) {
			transform.position = new Vector3 (Mathf.Sin (x), y, 1);
		} else {
			transform.position = new Vector3 (Mathf.Sin (x) * -1, y, 1);
		}
	}
}
