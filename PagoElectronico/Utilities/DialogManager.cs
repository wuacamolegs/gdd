using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Utilities
{
    public class DialogManager
    {
         public static string ShowDialogWithPassword(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 100, Top = 20, Width = 400, Text = text };
            TextBox textBox = new TextBox() { Left = 150, Top = 50, Width = 200, UseSystemPasswordChar = true };
            Button confirmation = new Button() { Text = "OK", Left = 150, Width = 100, Top = 70 };
            Button cancel = new Button() { Text = "Cancel", Left = 250, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { textBox.Text = ""; prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;
            prompt.ShowDialog();
            return textBox.Text;
        }

        public static string ShowDialogCommonText(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 100, Top = 20, Width = 400, Text = text };
            TextBox textBox = new TextBox() { Left = 150, Top = 50, Width = 200};
            Button confirmation = new Button() { Text = "OK", Left = 150, Width = 100, Top = 70 };
            Button cancel = new Button() { Text = "Cancel", Left = 250, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { textBox.Text = "cancel"; prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;
            prompt.ShowDialog();
            return textBox.Text;
        }
    }
}

