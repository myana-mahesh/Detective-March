using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSecs : MonoBehaviour {

	public float duration;

	public void Start()
	{
		Destroy (gameObject, duration);
	}
}
