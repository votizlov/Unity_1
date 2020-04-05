using UnityEngine;

namespace Objects
{
	public class Spawner : MonoBehaviour
	{
		public float delay = 0f;
		public float spawnTime = 2f;
		public GameObject prefab;

		private float _timer;

		private void OnEnable()
		{
			_timer = delay;
		}

		private void Update()
		{
			_timer -= Time.deltaTime;
			if(_timer <= 0f)
			{
				var transform1 = transform;
				GameObject.Instantiate(prefab, transform1.position, transform1.rotation);
				_timer = spawnTime;
			}
		}
	}
}
