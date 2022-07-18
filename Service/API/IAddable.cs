using System.Windows.Media.Imaging;

namespace Service.API
{
    public interface IAddable
    {
        void Add(string name, string type, string genre, string author, int amount, double price, BitmapImage image);
    }
}
