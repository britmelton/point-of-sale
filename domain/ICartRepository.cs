namespace Domain;

public interface ICartRepository
{
    void CreateCart(Cart cart);
    Cart Find(Guid id);
    void Update(Cart cart);
}