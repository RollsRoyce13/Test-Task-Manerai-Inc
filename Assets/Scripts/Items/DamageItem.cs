using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace TestTaskManeraiInc
{
    public class DamageItem : XRGrabInteractable
    {
        [Header("Custom Events")]
        [SerializeField] private UnityEvent onTargetPunch;
        
        private void OnCollisionEnter(Collision other)
        {
            if (!other.transform.TryGetComponent(out IDamageable target)) return;
            
            Vector3 hitPosition = other.transform.position;
            Vector3 direction = (hitPosition - transform.position).normalized;
			
            target.TakeDamage(direction);
            onTargetPunch?.Invoke();
        }
    }
}