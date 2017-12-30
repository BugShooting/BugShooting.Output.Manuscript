using System.Windows;
using System.Windows.Controls;

namespace BugShooting.Output.Manuscript
{
  partial class Edit : Window
  {
    public Edit(Output output)
    {
      InitializeComponent();

      NameTextBox.Text = output.Name;
      UrlTextBox.Text = output.Url;

      NameTextBox.TextChanged += ValidateData;
      UrlTextBox.TextChanged += ValidateData;
      ValidateData(null, null);

      UrlTextBox.Focus();

    }

    public string OutputName
    {
      get { return NameTextBox.Text; }
    }

    public string Url
    {
      get { return UrlTextBox.Text; }
    }

    private void ValidateData(object sender, RoutedEventArgs e)
    {
      OK.IsEnabled = Validation.IsValid(NameTextBox) &&
                     Validation.IsValid(UrlTextBox);
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = true;
    }

  }
}
