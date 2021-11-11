using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SbSTanks
{
    public abstract class Unit : MonoBehaviour, IDamagebleUnit, IUnit
    {
        public Action<int, TextMeshProUGUI> TakeDamage { get; set; }
        public Action<TextMeshProUGUI> OnChangeElement;
        public Transform UnitTransform { get; private set; }
        public Action<GameObject, IDamagebleUnit> ShellHit { get; set; }

        [SerializeField] protected UnitParameters _parameters;
        [SerializeField] protected Transform _shotStartPoint;
        [SerializeField] protected TextMeshProUGUI _unitHealthText;
        [SerializeField] protected TextMeshProUGUI _unitElementText;
        [SerializeField] protected GameObject _brokenTank;
        [SerializeField] protected Button _tankButton;
        [SerializeField] protected GameObject _tankRenderers;

        protected ShellController _shellController;
        protected StepController _stepController;
        protected bool _isDead;
        protected const float SHOT_FORCE = 180f;


        public bool IsDead => _isDead;
        public IParameters Parameters { get => _parameters; }
        public Transform GetShotPoint { get => _shotStartPoint; }
        public Transform Transform { get => gameObject.transform; }

        public void Init(UnitInitializationData data, ShellController shellController, StepController stepController)
        {
            var newElement = new Element();
            _parameters = new UnitParameters(this, data.hp, data.damage, newElement);
            _shellController = shellController;
            _stepController = stepController;
            UnitTransform = transform;
            _unitHealthText.text = _parameters.Hp.ToString();
            _unitElementText.text = _parameters.Element.EntityElement.ToString();
        }

        protected abstract void OnCollisionEnter(Collision collision);

        public void TakingDamage(int damage)
        {
            Debug.Log("Auch!");
            TakeDamage?.Invoke(damage, _unitHealthText);
            
            int.TryParse(_unitHealthText.text, out int res);
            if (res <= 0)
            {
                UnitDeath();
            }
        }

        public void ChangingElement()
        {
            OnChangeElement?.Invoke(_unitElementText);
        }

        private void UnitDeath()
        {
            _brokenTank.SetActive(true);
            _tankButton.interactable = false;
            _tankRenderers.SetActive(false);
            _isDead = true;
        }
    }
}
