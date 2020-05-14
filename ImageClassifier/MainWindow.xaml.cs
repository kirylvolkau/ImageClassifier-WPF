using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.IO;
using System.Net.Http;
using ImageClassifier.Entities;
using Newtonsoft.Json;

namespace ImageClassifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            dialog.Filter = "Image files(*.png, *jpg)|*.jpg;*.png;*.jpeg";
            dialog.InitialDirectory = System.IO.Path.Combine(projectDirectory, "ai-images");
            if (dialog.ShowDialog() == true)
            {
                string filename = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(filename));
                MakePredictionAsync(filename);
            }
        }

        private async void MakePredictionAsync(string filename)
        {
            string url = "";
            string prediction_key = "";
            string content_type = "application/octet-stream";
            var file = File.ReadAllBytes(filename);

            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", prediction_key);
                using(var content = new ByteArrayContent(file))
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(content_type);

                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    List<Prediction> predictions = JsonConvert.DeserializeObject<PredictionResponse>(responseString).Predictions;
                    predictionsListView.ItemsSource = predictions;
                }
            }
        }
    }
}
