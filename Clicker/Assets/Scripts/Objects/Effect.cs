using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
	public ParticleSystem ParticleSystem;

	private void Update()
	{
		if(!ParticleSystem.isPlaying)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
