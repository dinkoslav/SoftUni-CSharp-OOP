namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        private const int DefaultHealthEffect = 200;
        private const int DefaultCountDown = 3;

        public Injection(string id, int defenseEffect, int attackEffect, int healthEffect = DefaultHealthEffect)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = DefaultCountDown;
        }
    }
}
