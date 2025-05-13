using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace TestTaskManeraiInc
{
	public class PlayerDirectInteraction : XRDirectInteractor
	{
		[Header("Custom Events")]
		[SerializeField] private UnityEvent onTargetPunch;
		
		protected override void OnHoverEntered(HoverEnterEventArgs args)
		{
			base.OnHoverEntered(args);
			
			if (!args.interactableObject.transform.TryGetComponent(out IDamageable target)) return;

			Vector3 hitPosition = args.interactableObject.transform.position;
			Vector3 direction = (hitPosition - transform.position).normalized;
			
			target.TakeDamage(direction);
			onTargetPunch?.Invoke();
		}
	}
}