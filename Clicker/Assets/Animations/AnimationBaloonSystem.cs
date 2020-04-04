using Objects;
using UnityEngine;

namespace Animations
{
	public class AnimationBaloonSystem : MonoBehaviour
	{
		public const string DeadTrigger = "DeadTrigger";
		public const string DeadAnimationInteger = "DeadAnimation";

		public Baloon baloon;
		public Animator ShipAnimator;
		public GameObject DieEffectPrefab;
		public Transform BodyTransform;

		private void OnEnable()
		{
			baloon.DieEvent += DeadAnimationPlay;
		}

		private void OnDisable()
		{
			baloon.DieEvent -= DeadAnimationPlay;
		}

		private void DeadAnimationPlay()
		{
			if (DieEffectPrefab != null)
				Instantiate(DieEffectPrefab, BodyTransform.position, BodyTransform.rotation);
			var deadAnimationNumber = Random.Range(1, 4);
			ShipAnimator.SetInteger(DeadAnimationInteger, deadAnimationNumber);
		}

		public void OnDestroyObjectAfterAnimation()
		{
			if (DieEffectPrefab != null)
				Instantiate(DieEffectPrefab, BodyTransform.position, BodyTransform.rotation);

			Destroy(gameObject);
		}
	}
}
