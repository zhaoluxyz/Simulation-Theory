using UnityEngine;
using System.Collections;
using System.Threading; 

public class scptKeyboardStuff : MonoBehaviour {

	public bool isPickedUp = false;
	public float speed = 5f; 

	ParticleSystem[] _emitters; 

	void Start()
	{
		_emitters = GameObject.FindObjectsOfType<ParticleSystem> ();
	}

	void FixedUpdate () {
		transform.Rotate(0, 1, 0, Space.World);
		foreach (ParticleSystem p in _emitters)
			p.transform.Rotate (0, 3, 0, Space.World); 
	}

	IEnumerator Pickup()
	{
		var time = 0f; 
		var increment = new Vector3 (0, speed * Time.deltaTime, 0);

		Debug.Log ("going down"); 
		while (time < 0.35f)
		{
			time += Time.deltaTime;
			transform.Translate (-increment * 2, Space.World);
			yield return null;
		}

		Debug.Log ("going up"); 
		while (time < 6f)
		{
			speed *= 2;
			time += Time.deltaTime;
			transform.Translate (increment * speed, Space.World);
			yield return null; 
		}
			
		Destroy (gameObject); 
	}		

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			Debug.Log ("picked up"); 
			StartCoroutine (Pickup ());
			/* Not needed because of using a Coroutine.
			new Thread(() =>			
				StartCoroutine(Pickup())
			).Start();
			*/
			isPickedUp = true; 
		}
	}
}
