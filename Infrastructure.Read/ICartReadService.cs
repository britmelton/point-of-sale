namespace Infrastructure.Read;

    public interface ICartReadService
    {
        public CartDto Find(Guid id);
    }