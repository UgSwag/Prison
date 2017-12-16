using prison.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using Newtonsoft.Json;
using GetWeatherApi;
using System.Drawing;




//This is the prison main window classs
namespace prison
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        const string APPID = "b6907d289e10d714a6e88b30761fae22";
        //string City = "Dodoma";

        public void GetWeather(string City)
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = string.Format("http://openweathermap.org/data/2.5/weather?q={0}&appid={1}", City, APPID);
                    var json = web.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<GetWeatherApi.Class1.root>(json);

                    GetWeatherApi.Class1.root output = result;

                    CityName.Text = string.Format("{0}", output.Name);//City Name
                    CountryName.Text = string.Format("{0}", output.sys.Country);//Country Name
                    degreesC.Text = string.Format("{0}\u00B0" + "C", output.Main.Temp);// Current Temperature
                    MaximumTemperature.Text = string.Format("{0}\u00B0" + "C", output.Main.temp_max);// Maximum Temperature
                    MinimumTemperature.Text = string.Format("{0}\u00B0" + "C", output.Main.temp_min);// Minimum Temperature
                    windSpeed.Text = string.Format("{0}" + " " + "m/s", output.wind.Speed); // Wind Speed
                    humidity.Text = string.Format("{0}" + "%", output.Main.Humidity);// Humidity
                    Pressure.Text = string.Format("{0}" + " " + "hpa", output.Main.Pressure); //Pressure
                    description.Text = string.Format("{0}", output.weather.First().description); //Description

                   //WeatherIcon = SetIcon();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter a valid city name or check your internet connections");
            }

        }

        //SEARCH bUTTON CODE
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (WeatherSearch.Text != string.Empty)
                {
                    GetWeather(WeatherSearch.Text);// one day weather
                }
                else
                {
                    MessageBox.Show("Please enter a city name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid city name");
            }

        }

        //tHIS UPDATES the weather icon
        System.Drawing.Image SetIcon()
        {
            string url = "http://api.openweathermap.org/img/w/10d.png"; // image icon
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse()) 
            using(var WeatherIcon = request.GetRequestStream())
            {
                System.Drawing.Image WeatherImg = Bitmap.FromStream(WeatherIcon);
                return WeatherImg;
            }
        }

        public void Getforecast(string City)
        {
        //    int day = 5;
        //    string link = string.Format("http://openweathermap.org/data/2.5/weather?q={0}&appid={1}", City, APPID);
        //    using(WebClient web = new WebClient())
        //    {
        //        var json = web.DownloadString(link);
        //        var Object = JsonConvert.DeserializeObject<WearherInfo.root>(json);

        //        WearherInfo.root forecast = Object;
        //       // Condition.Text = string.Format("{0}", forecast.list[1].weather[0].main); // weather condition
        //       Description.Text = string.Format("{0}", forecast.weather.Description); // weather description
        //       // temp.Text = string.Format("{0}", forecast.temp ); // weather temp
        //       // windSpeed.Text = string.Format("{0}", forecast. ); // weather wind speed
        //    }

        }

        public MainWindow()  
        {
            InitializeComponent();
            ChangingContent.Content = new RecordsViewModel ();
            GetWeather("kampala"); // initializing Getweather method
          
        }

        private void RegesterButton(object sender, RoutedEventArgs e)
        {
            DataContext = new RegesterViewModel();
            ChangingContent.Content = new RegesterViewModel();
        }

        private void Admition_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AdmitionViewModel();
            ChangingContent.Content = new AdmitionViewModel();
        }

        private void Records_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new RecordsViewModel();
            ChangingContent.Content = new RecordsViewModel();
        }

        private void Staff_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new StaffViewModel();
            ChangingContent.Content = new StaffViewModel();
        }

        private void Help_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new HelpViewModel();
            ChangingContent.Content = new HelpViewModel();
        }

        private void SignIn_clicked(object sender, RoutedEventArgs e)
        {
            //DataContext = new SignInModelView();
            //ChangingContent.Content = new SignInModelView();
           // DisabledButton.Visibility = Visibility.Visible;
        }

       
    }
}
