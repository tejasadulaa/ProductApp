using ProductApp_1165395.ModelsVM;
namespace ProductApp_1165395.DataLayer
{
    public interface ICartRepository
    {
        void AddItemToCart(CartItem item);
        Task<List<CartItem>> GetCart();
        void StoreCart(List<CartItem> CList);
    }
}
