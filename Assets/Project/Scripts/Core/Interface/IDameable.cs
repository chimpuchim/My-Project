public interface IRecieveDamage
{
    public void RecieveDamage(float damageRecieve);
}

public interface ISendDamege
{
    float Damage{ get; set; }
    public void SendDamege(IRecieveDamage client);
}
