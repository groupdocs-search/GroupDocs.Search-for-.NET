using GroupDocs.Search.IndexBrowser.Utils;
using GroupDocs.Search.IndexBrowser.ViewModels;
using GroupDocs.Search.IndexBrowser.XmlStorage;
using System;
using System.IO;
using System.Windows;

namespace GroupDocs.Search.IndexBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string RootElementName = "Root";

        private MainWindow mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var settings = LoadSettings();

            var mainViewModel = new MainViewModel(settings);

            mainWindow = new MainWindow();
            mainWindow.DataContext = mainViewModel;
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            if (mainWindow.DataContext is MainViewModel mainViewModel)
            {
                SaveSettings(mainViewModel.Settings);
            }
        }

        private void SaveSettings(Settings settings)
        {
            try
            {
                var doc = new XmlDocumentWriter();
                var rootWriter = doc.CreateRootWriter(RootElementName);

                settings.Save(rootWriter);

                FileHelper.EnsureFolderExists(Constants.SettingsFilePath);
                doc.Save(Constants.SettingsFilePath);
            }
            catch (Exception)
            {
            }
        }

        private Settings LoadSettings()
        {
            var settings = new Settings();
            try
            {
                FileHelper.EnsureFolderExists(Constants.SettingsFilePath);
                if (File.Exists(Constants.SettingsFilePath))
                {
                    var doc = new XmlDocumentReader(Constants.SettingsFilePath);
                    var rootReader = doc.GetRootReader(RootElementName);

                    settings.Load(rootReader);
                }
            }
            catch (Exception)
            {
            }
            return settings;
        }
    }
}
