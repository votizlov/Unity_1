using Objects;
using UnityEngine;

namespace Animations
{
	public class AnimationBaloonSystem : MonoBehaviour
	{
		public const string DeadTrigger = "DeadTrigger";
		public const string DeadAnimationInteger = "DeadAnimation";

		public Baloon baloon;
		public GameObject dieEffectPrefab;
		public GameObject hitEffectPrefab;
		public Transform bodyTransform;

		private void OnEnable()
		{
			baloon.DieEvent += DeadAnimationPlay;
			baloon.HitEvent += HitAnimationPlay;
		}

		private void OnDisable()
		{
			baloon.DieEvent -= DeadAnimationPlay;
			baloon.HitEvent -= HitAnimationPlay;
		}

		private void DeadAnimationPlay()
		{
			if (dieEffectPrefab != null)
				Instantiate(dieEffectPrefab, bodyTransform.position, bodyTransform.rotation);
		}

		private void HitAnimationPlay()
		{
			if (hitEffectPrefab != null)
				Instantiate(hitEffectPrefab, bodyTransform.position, Quaternion.identity);
		}

		public void OnDestroyObjectAfterAnimation()
		{
			if (dieEffectPrefab != null)
				Instantiate(dieEffectPrefab, bodyTransform.position, bodyTransform.rotation);

			Destroy(gameObject);
		}
	}
}
