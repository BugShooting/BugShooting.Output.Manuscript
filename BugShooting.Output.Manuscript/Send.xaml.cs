using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace BugShooting.Output.Manuscript
{
  partial class Send : Window
  {

    public Send(string url, int lastCaseID)
    {
      InitializeComponent();

      UrlLabel.Text = url;
      AttachToCaseID.Text = lastCaseID.ToString();
      ReplyToCaseID.Text = lastCaseID.ToString();
      NewCase.IsChecked = true;

      AttachToCaseID.SelectionChanged += ValidateData;
      AttachToCaseID.SelectionChanged += ValidateData;
      ValidateData(null, null);

    }

    public SendType Type
    {
      get
      {

        if (NewCase.IsChecked.Value)
        {
          return SendType.NewCase;
        }
        else if (AttachToCase.IsChecked.Value)
        {
          return SendType.AttachToCase;
        }
        else if (NewEmail.IsChecked.Value)
        {
          return SendType.NewEmail;
        }
        else
        {
          return SendType.ReplyToCase;
        }
      
      }
    }

    public int CaseID
    {
      get
      {

        if (AttachToCase.IsChecked.Value)
        {
          return Convert.ToInt32(AttachToCaseID.Text);
        }
        else
        {
          return Convert.ToInt32(ReplyToCaseID.Text);
        }
        
      }
    }

    private void ValidateData(object sender, EventArgs e)
    {
      OK.IsEnabled = Validation.IsValid(AttachToCaseID) &&
                     Validation.IsValid(ReplyToCaseID);
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = true;
    }

    private void Type_Changed(object sender, RoutedEventArgs e)
    {

      if (AttachToCase.IsChecked.Value)
      {
        AttachToCaseID.SetValue(Validation.RequiredProperty, true);
        AttachToCaseID.Focus();
      }
      else
      {
        AttachToCaseID.SetValue(Validation.RequiredProperty, false);
      }

      if (ReplyToCase.IsChecked.Value)
      {
        ReplyToCaseID.SetValue(Validation.RequiredProperty, true);
        ReplyToCaseID.Focus();
      }
      else
      {
        ReplyToCaseID.SetValue(Validation.RequiredProperty, false);
      }

      ValidateData(null, null);
    }

    private void AttachToCaseID_GotFocus(object sender, RoutedEventArgs e)
    {
      AttachToCase.IsChecked = true;
      AttachToCaseID.SelectAll();
    }

    private void ReplyToCaseID_GotFocus(object sender, RoutedEventArgs e)
    {
      ReplyToCase.IsChecked = true;
      ReplyToCaseID.SelectAll();
    }

    private void Numeric_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
    }

  }

}
