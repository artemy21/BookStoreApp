using System;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace LibraryApp2.General
{
    internal abstract class ItemImage
    {
        internal static readonly BitmapImage defaultImage
            = new BitmapImage(new Uri(@"\Assets\Items\QuestionMark.png", UriKind.Relative));

        internal static BitmapImage ImageDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg"
            };
            fileDialog.ShowDialog();

            return fileDialog.FileName != "" ? new BitmapImage(new Uri(fileDialog.FileName))
                                             : defaultImage;
        }
    }
}
