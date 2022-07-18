using Service.DS;
using Model.ItemModels;

namespace Service.Services
{
    internal abstract class StorageService
    {
        public static DoubleHashing<int, AbstractItem> HashTable { get; }
        public static BinarySearchTree<string, AbstractItem> Tree { get; }

        static StorageService()
        {
            HashTable = new DoubleHashing<int, AbstractItem>(30);
            Tree = new BinarySearchTree<string, AbstractItem>();
        }
    }
}
