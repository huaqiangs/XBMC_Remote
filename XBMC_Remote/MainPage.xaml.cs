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
using System.IO.IsolatedStorage;

namespace XBMC_Remote
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 全局WebClient
        private WebClient client = new WebClient();

        // public String JSON_RPC = "http://192.168.1.101/xbmc/jsonrpc.php?SendRemoteKey";
        private String JSON_RPC = "";

        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            
            /*
            // 读取服务器配置
            XmlReader reader = XmlReader.Create("/XBMC_Remote;component/Setting.xml");
            while (reader.Read())
            {
                if (reader.IsStartElement() && reader.Name == "host")
                {
                    JSON_RPC = "http://" + reader.GetAttribute("value") + "/jsonrpc?SendRemoteKey";
                }
            }
            */
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string host = (string)userSettings["host"];
                JSON_RPC = "http://" + host + "/jsonrpc?SendRemoteKey";
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                // No preference is saved.
                textBlockDebug.Text = "Not found";
            }

            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted);
        }

        void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                textBlockDebug.Text = "Successfully.";
            }
            else
            {
                textBlockDebug.Text = "Error";
            }
        }

        private void ButtonUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String data = "{\"jsonrpc\": \"2.0\", \"method\": \"Input.Up\", \"id\": 1}";
                client.Headers[HttpRequestHeader.ContentLength] = data.Length.ToString();
                client.UploadStringAsync(new Uri(JSON_RPC), "POST", data);
            }
            catch { }
        }

        private void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String data = "{\"jsonrpc\": \"2.0\", \"method\": \"Input.Down\", \"id\": 1}";
                client.Headers[HttpRequestHeader.ContentLength] = data.Length.ToString();
                client.UploadStringAsync(new Uri(JSON_RPC), "POST", data);
            }
            catch { }
        }

        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String data = "{\"jsonrpc\": \"2.0\", \"method\": \"Input.Left\", \"id\": 1}";
                client.Headers[HttpRequestHeader.ContentLength] = data.Length.ToString();
                client.UploadStringAsync(new Uri(JSON_RPC), "POST", data);
            }
            catch { }
        }

        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String data = "{\"jsonrpc\": \"2.0\", \"method\": \"Input.Right\", \"id\": 1}";
                client.Headers[HttpRequestHeader.ContentLength] = data.Length.ToString();
                client.UploadStringAsync(new Uri(JSON_RPC), "POST", data);
            }
            catch { }
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String data = "{\"jsonrpc\": \"2.0\", \"method\": \"Input.Select\", \"id\": 1}";
                client.Headers[HttpRequestHeader.ContentLength] = data.Length.ToString();
                client.UploadStringAsync(new Uri(JSON_RPC), "POST", data);
            }
            catch { }
        }

        private void ButtonHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String data = "{\"jsonrpc\": \"2.0\", \"method\": \"Input.Back\", \"id\": 1}";
                client.Headers[HttpRequestHeader.ContentLength] = data.Length.ToString();
                client.UploadStringAsync(new Uri(JSON_RPC), "POST", data);
            }
            catch { }            
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String data = "{\"jsonrpc\": \"2.0\", \"method\": \"Input.Home\", \"id\": 1}";
                client.Headers[HttpRequestHeader.ContentLength] = data.Length.ToString();
                client.UploadStringAsync(new Uri(JSON_RPC), "POST", data);
            }
            catch { }            
        }

        private void ButtonMute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String data = "{\"jsonrpc\": \"2.0\", \"method\": \"Application.SetMute\", \"params\": { \"mute\": \"toggle\" }, \"id\": 1}";
                client.Headers[HttpRequestHeader.ContentLength] = data.Length.ToString();
                client.UploadStringAsync(new Uri(JSON_RPC), "POST", data);
            }
            catch { }
        }

        private void ButtonVolumeDown_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonVolumeUp_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonSetting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageSetting.xaml", UriKind.Relative));
        }

    }
}