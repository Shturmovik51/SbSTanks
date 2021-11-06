using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SbSTanks
{
   // [RequireComponent(typeof(Animator))]
    public class Player : Unit
    {
        private bool _hitStatus = false;
        public bool GetHitStatus { get => _hitStatus; set => _hitStatus = value; }

        protected override void OnCollisionEnter(Collision collision)
        {
            ShellHit?.Invoke(collision.gameObject, this);
            _shellController.ReturnShell(collision.gameObject);
        }

        public void Shot()
        {
            var shell = _shellController.GetShell(_parameters.Damage, _shotStartPoint);
            var shellRb = shell.GetComponent<Rigidbody>();

            shellRb.AddForce(shell.transform.forward * SHOT_FORCE, ForceMode.Impulse);
            _hitStatus = true;

            switch (Parameters.Element.EntityElement)
            {
                case (ElementType.FireElement):
                    FireElementShoot();
                    break;
                case (ElementType.GroundElement):
                    GroundElementShoot();
                    break;
                case (ElementType.WaterElement):
                    WaterElementShoot();
                    break;
                default:
                    throw new System.Exception("Косяк с элементами");
            }
        }

        public void FireElementShoot()
        {
            Debug.Log("Fire");
        }

        public void GroundElementShoot()
        {
            Debug.Log("Ground");
        }

        public void WaterElementShoot()
        {
            Debug.Log("Water");
        }
    }
}
