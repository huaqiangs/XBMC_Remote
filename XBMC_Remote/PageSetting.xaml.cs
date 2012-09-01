using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Text;

namespace XBMC_Remote
{
    public partial class PageSetting : PhoneApplicationPage
    {
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;

        public PageSetting()
        {
            InitializeComponent();

            try
            {
                string host = (string)userSettings["host"];
                textBoxHost.Text = host;
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                // No preference is saved.
                textBoxHost.Text = "";
            }

            /*
            XmlReader reader = XmlReader.Create("/XBMC_Remote;component/Setting.xml");
            while (reader.Read())
            {
                if (reader.IsStartElement() && reader.Name == "host")
                {
                    textBoxHost.Text = reader.GetAttribute("value");
                }
            }
            reader.Close();
            */
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (userSettings.Contains("host") == true)
                {
                    userSettings.Remove("host");
                }
                userSettings.Add("host", textBoxHost.Text);
                userSettings.Save();
            }
            catch (ArgumentException ex)
            {
                textBoxHost.Text = ex.Message;
            }
            /*
            try
            {
                string host = (string)settings["host"];
                textBoxHost.Text = host;
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                // No preference is saved.
                textBoxHost.Text = "";
            }
            */
            /*
            FileStream fs = new FileStream("/XBMC_Remote;component/Setting.xml", FileMode.Create);
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            XmlWriter writer = XmlWriter.Create(fs, setting);
            writer.WriteStartDocument(); 
            writer.WriteStartElement("setting");
            writer.WriteStartElement("host");
            writer.WriteAttributeString("value", textBoxHost.Text.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();  
            writer.Flush();
            writer.Close();
            */
        }
    }
}