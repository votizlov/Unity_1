using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float Delay = 0f;
	public float SpawnTime = 2f;
	public GameObject Prefab;

	private float _timer;

	private void OnEnable()
	{
		_timer = Delay;
	}

	private void Update()
	{
		_timer -= Time.deltaTime;
		if(_timer <= 0f)
		{
			GameObject.Instantiate(Prefab, transform.position, transform.rotation);
			_timer = SpawnTime;
		}
	}
}
