using System;
using TMPro;
using UnityEngine;

namespace SbSTanks
{
    [Serializable]
    public struct UnitParameters : IParameters
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _damage;
        private Element _element;

        public int Hp { get => _hp; set => _hp = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public Element Element => _element;

        public UnitParameters(Unit unit, int hp, int damage, Element element)
        {
            _hp = hp;
            _damage = damage;
            _element = element;
            unit.TakeDamage += GetDamage;
            unit.OnChangeElement += ChangeElement;
        }

        public void GetDamage(int damage, TextMeshProUGUI healthText)
        {
            _hp -= damage;
            healthText.text = _hp.ToString();
            Debug.Log(_hp);
        }

        public void ChangeElement(TextMeshProUGUI elementText)
        {
            _element.UpdateElement();
            elementText.text = _element.EntityElement.ToString();
            Debug.Log("Change");
        }
    }
}
