public interface IRecieveDamage
{
    public void ReceiveDamage(float damageRecieve);
}

public interface ISendDamege
{
    float Damage{ get; set; }
    public void SendDamage(IRecieveDamage client);
}
