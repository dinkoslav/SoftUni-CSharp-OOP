namespace Infestation
{
    public class Weapon : Supplement
    {
        private const int WeaponPowerEffect = 0;
        private const int WeaponHealthEffect = 0;
        private const int WeaponAggressionEffect = 0;

        public Weapon()
            : base(WeaponPowerEffect, WeaponHealthEffect, WeaponAggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == "WeaponrySkill")
            {
                this.powerEffect = 10;
                this.aggressionEffect = 3;
            }
        }
    }
}
