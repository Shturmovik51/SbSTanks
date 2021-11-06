using UnityEngine;

namespace SbSTanks
{
    public interface IDamagebleUnit
    {
        IParameters Parameters { get; }
        Transform UnitTransform { get; }
        public void TakingDamage(int damage);
    }
}