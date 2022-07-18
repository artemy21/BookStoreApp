using System;
using System.Linq;
using Model.ItemModels;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Model.General
{
    public abstract class ItemTypes
    {
        private static readonly BitmapImage DEFAULT_IMAGE
            = new BitmapImage(new Uri(@"\Items\QuestionMark.png", UriKind.Relative));

        public static Type GetType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName) || !IsTypeValid(typeName)) return null;
            var types = from t in Assembly.GetExecutingAssembly()
                                          .GetTypes()
                        where t.IsClass
                              && t.Namespace == "Model.ItemModels"
                              && t.Name == typeName
                        select t;

            return types?.First();
        }

        public static List<string> GetAllTypes()
        {
            var types = from t in Assembly.GetExecutingAssembly()
                                          .GetTypes()
                        where t.IsClass
                              && t.Namespace == "Model.ItemModels"
                              && t.Name != "AbstractItem"
                        select t;
            types.ToArray();

            return EnumerableToList(types);
        }

        public static AbstractItem GetItem
            (string name, string type, string genre, string author, int amount, double price, BitmapImage image = default)
        {
            Type t = GetType(type);

            AbstractItem item = Equals(image, default(BitmapImage))
                ? (AbstractItem)Activator.CreateInstance(t, new object[] { name, author, genre, amount, price, DEFAULT_IMAGE })
                : (AbstractItem)Activator.CreateInstance(t, new object[] { name, author, genre, amount, price, image });
            return item;
        }

        public static bool IsTypeValid(string itemType) => GetAllTypes().Contains(itemType);

        private static List<string> EnumerableToList(IEnumerable<Type> types)
        {
            var arr = new List<string>();
            foreach (var type in types)
            { arr.Add(type.Name); }
            return arr;
        }
    }
}