using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SbSTanks
{
   // [RequireComponent(typeof(Animator))]
    public class Player : Unit
    {
        public event Action OnGetRandomTarget;

        private bool _hitStatus = false;
        public bool GetHitStatus { get => _hitStatus; set => _hitStatus = value; }

        protected override void OnCollisionEnter(Collision collision)
        {
            ShellHit?.Invoke(collision.gameObject, this);
            _shellController.ReturnShell(collision.gameObject);
        }

        public void Shot(ParticleSystem shootEffect)
        {
            switch (_parameters.Element.EntityElement)
            {
                case (ElementType.FireElement):
                    Debug.Log("FireShoot");
                    LaunchShell(shootEffect);
                    break;
                case (ElementType.GroundElement):
                    Debug.Log("GroundShoot");
                    OnGetRandomTarget.Invoke();
                    break;
                case (ElementType.WaterElement):
                    Debug.Log("WaterShoot");
                    LaunchShell(shootEffect);
                    break;
                default:
                    throw new Exception("Косяк с элементами");
            }
        }

        public void LaunchShell(ParticleSystem shootEffect)
        {
            Debug.Log("Shot!!!!");
            shootEffect.Play();
            var shell = _shellController.GetShell(_parameters.Damage, _shotStartPoint, _parameters.Element);
            var shellRb = shell.GetComponent<Rigidbody>();

            shellRb.AddForce(shell.transform.forward * SHOT_FORCE, ForceMode.Impulse);
            _hitStatus = true;
        }
    }
}
