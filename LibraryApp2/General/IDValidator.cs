using System.Windows;

namespace LibraryApp2.General
{
    internal abstract class IDValidator
    {
        internal static bool IsIdValid(int id)
        {
            int sum = 0;
            int len = id.ToString().Length;
            if (len != 9) return false;
            for (int i = 1; i <= len; i++)
            {
                if (i % 2 != 0) sum += id % 10;
                else
                {
                    int num = id % 10 * 2;
                    if (num > 9) num = num % 10 + num / 10;
                    sum += num;
                }
                id /= 10;
            }
            return sum % 10 == 0;
        }
        internal static void InvalidIdMessage() => MessageBox.Show("Try Again", "Invalid ID", MessageBoxButton.OK);
    }
}
