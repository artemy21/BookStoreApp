using Model.ItemModels;

namespace Service.API
{
    public interface ICartaddable
    {
        void CartAdd(AbstractItem item, int amount);
    }
}
