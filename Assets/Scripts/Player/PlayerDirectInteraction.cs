using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace TestTaskManeraiInc
{
	public class PlayerDirectInteraction : XRDirectInteractor
	{
		protected override void OnHoverEntered(HoverEnterEventArgs args)
		{
			base.OnHoverEntered(args);
			
			if (!args.interactableObject.transform.TryGetComponent(out IDamageable target)) return;
			
			Vector3 direction = (args.interactableObject.transform.position - transform.position).normalized;
			target.TakeDamage(direction);
		}
	}
}