using Moral;


namespace Interfaces
{
    public interface IMoral
    {
        float Damage { get; }
        float MoralAmount { get; set; }
        MoralStatus MoralStatus { get; set; }
        
    }
}
