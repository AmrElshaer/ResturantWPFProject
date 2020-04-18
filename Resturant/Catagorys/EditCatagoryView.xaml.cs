using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Resturant.Catagorys
{
    /// <summary>
    /// Interaction logic for EditCatagoryView.xaml
    /// </summary>
    public partial class EditCatagoryView : UserControl
    {
        public EditCatagoryView()
        {
            InitializeComponent();
        }
        private void UploadImage(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.* ";
            if (dlg.ShowDialog() == true)
            {
                string appPath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                var fileNameToSave = DateTime.Now.ToFileTime() + System.IO.Path.GetExtension(dlg.SafeFileName);
                var imagePath = System.IO.Path.Combine(appPath + fileNameToSave);

                if (!Directory.Exists(appPath))
                {
                    Directory.CreateDirectory(appPath);
                }

                File.Copy(dlg.FileName, imagePath);

                this.ImageViewer.Source = new BitmapImage(new Uri(imagePath));


            }
        }
    }
}
