using lab2kornik.Services;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace lab2kornik
{
    public partial class MainPage : ContentPage
    {
        private readonly XmlParserContext _context;
        private readonly XmlToHtmlService _xmlToHtmlService;

        public MainPage()
        {
            InitializeComponent();
            _context = new XmlParserContext(new SaxXmlParserStrategy());
            _xmlToHtmlService = new XmlToHtmlService();
        }

        private async void OnPickFileClicked(object sender, EventArgs e)
        {
            var file = await FilePicker.PickAsync();
            if (file != null)
            {
                fileLabel.Text = file.FullPath;
            }
        }

        private void OnSaxClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileLabel.Text))
            {
                DisplayAlert("Error", "Please select an XML file first.", "OK");
                return;
            }

            _context.SetStrategy(new SaxXmlParserStrategy());
            _context.Parse(fileLabel.Text);
        }

        private void OnDomClicked(object sender, EventArgs e)
        {
            _context.SetStrategy(new DomXmlParserStrategy());
            _context.Parse(fileLabel.Text);
        }

        private void OnLinqClicked(object sender, EventArgs e)
        {
            _context.SetStrategy(new LinqXmlParserStrategy());
            _context.Parse(fileLabel.Text);
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            fileLabel.Text = "No file selected";
            resultLabel.Text = "Results will appear here...";
        }

        private void OnViewHtmlClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fileLabel.Text))
            {
                string htmlContent = _xmlToHtmlService.ConvertXmlToHtml(fileLabel.Text);
                HtmlWebView.Source = new HtmlWebViewSource { Html = htmlContent };
            }
        }

        private async void OnExitClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Exit", "Do you really want to exit?", "Yes", "No");
            if (confirm)
            {
                System.Environment.Exit(0);
            }
        }

    }
}
