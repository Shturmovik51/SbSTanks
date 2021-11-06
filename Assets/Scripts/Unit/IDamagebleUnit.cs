namespace SbSTanks
{
    public interface IDamagebleUnit
    {
        IParameters Parameters { get; }
        public void TakingDamage(int damage);
    }
}