using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace TestTaskManeraiInc
{
    [RequireComponent(typeof(PunchPosition))]
    [RequireComponent(typeof(PunchScale))]
    public class Head : XRBaseInteractable, IDamageable
    {
        [Header("References")]
        [SerializeField] private ParticleSystem bloodParticles;
        
        private PunchPosition _punchPosition;
        private PunchScale _punchScale;

        protected override void Awake()
        {
            base.Awake();
            
            _punchPosition = GetComponent<PunchPosition>();
            _punchScale = GetComponent<PunchScale>();
        }

        public void TakeDamage(Vector3 hitDirection)
        {
            _punchPosition.Punch(hitDirection);
            _punchScale.Punch();

            PlayBloodEffect(hitDirection);
        }

        private void PlayBloodEffect(Vector3 hitDirection)
        {
            if (bloodParticles == null)
                throw new ArgumentNullException(nameof(bloodParticles));

            Debug.Log(hitDirection);
            
            bool isLeftDirection = hitDirection.x > 0;

            bloodParticles.transform.rotation = isLeftDirection
                ? Quaternion.Euler(0f, 90f, 0f)
                : Quaternion.Euler(0f, -90f, 0f);
            
            bloodParticles.Play();
        }
    }
}
