using Avalonia.Controls;
using CSVMVP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVMVP.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        public async Task SaveProject()
        {
        }

        public async Task OpenFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = "Comma Separated Value", Extensions = { "csv" } });

            var result = await dialog.ShowAsync(new Window());

            if (result.Any())
            {
                var filePath = result.First();
                var fileContents = File.ReadAllText(filePath);

                var service = new CSVService();
                var csv = service.GetCSVFileFromFileContents(fileContents);
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
