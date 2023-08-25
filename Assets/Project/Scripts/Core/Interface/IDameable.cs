public interface IRecieveDamage
{
    public void RecieveDamage(int damageRecieve);
}

public interface ISendDamege
{
    float Damage{ get; set; }
    public void SendDamege(int damageSend, IRecieveDamage client);
}
