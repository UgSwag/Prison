using System;
using System.Windows.Input;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using BLL;
using System.Data;
using System.Windows;
using prison.Views;

namespace prison.Commands
{
    class ExportPdfFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        
        public void Execute(object parameter)
        {
            records record = new records();
            record.Admitdatagridview.SelectAllCells();
            record.Admitdatagridview.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, record.Admitdatagridview);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            record.Admitdatagridview.UnselectAllCells();
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Bravo\Desktop\Prisoner'sDetails.xls");
            file.WriteLine(result.Replace(',', ' '));
            file.Close();
            MessageBox.Show("Datagrid created and exported successfully");
        }
    }
}
 