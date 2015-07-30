using UnityEngine;
using System.Collections;

public class animate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		m_Pivot = transform.position;
	}

	float x = 1f;
	float speed = .05f;
	
	float y = 1;

	bool up = true;
	// Update is called once per frame
	void Update () {
		/*if (up) {
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
		}*/
		figureEight ();
	}

	//Figure eight properties
	float m_Speed = 1f;
	float m_XScale = 1;
	float m_YScale = 1;
	
	private Vector3 m_Pivot;
	private Vector3 m_PivotOffset;
	private float m_Phase;
	private bool m_Invert  = false;
	private float m_2PI = Mathf.PI * 2;
	//Figure eight.
	//http://forum.unity3d.com/threads/making-an-object-move-in-a-figure-8-programatically.38007/
	void figureEight() {
		m_PivotOffset = Vector3.up * 2 * m_YScale;
		
		m_Phase += m_Speed * Time.deltaTime;
		if(m_Phase > m_2PI)
		{
			m_Invert = !m_Invert;
			m_Phase -= m_2PI;
		}
		if(m_Phase < 0) m_Phase += m_2PI;
		
		transform.position = m_Pivot + (m_Invert ? m_PivotOffset : Vector3.zero);
		float _x = transform.position.x + (Mathf.Sin (m_Phase) * m_XScale);
		float _y = transform.position.y + (Mathf.Cos(m_Phase) * (m_Invert ? -1 : 1) * m_YScale);
		Vector3 _temp = new Vector3 (_x, _y, 0);
		transform.position = _temp;
	}
}
