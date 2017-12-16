using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace prison.Views
{
    /// <summary>
    /// Interaction logic for Camera.xaml
    /// </summary>
    public partial class Camera : UserControl, INotifyPropertyChanged
    {
        public FilterInfo CurrentDevice
        {
            get { return _currentDevice; }
            set { _currentDevice = value; this.OnPropertyChanged("CurrentDevice"); }
        }

      

        public ObservableCollection<FilterInfo> PrisonCamera { get; private set; }

        private FilterInfo _currentDevice;



        #region Private fields

        private IVideoSource _CameraSource;
        private Action<object, CancelEventArgs> Closing;
        
        public Camera()
        {
            InitializeComponent();
            this.DataContext = this;
            GetVideoDevices();
            this.Closing += MainWindow_Closing;

        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopCamera();
        }
        private void GetVideoDevices()
        {
            PrisonCamera = new ObservableCollection<FilterInfo>();
            foreach (FilterInfo filterInfo in new FilterInfoCollection(FilterCategory.VideoInputDevice))
            {
                PrisonCamera.Add(filterInfo);
            }
            if (PrisonCamera.Any())
            {
                CurrentDevice = PrisonCamera[0];
            }
            else
            {
                MessageBox.Show("No video sources found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartCamera()
        {
            if (CurrentDevice != null)
            {
                _CameraSource = new VideoCaptureDevice(CurrentDevice.MonikerString);
                _CameraSource.NewFrame += video_NewFrame;
                _CameraSource.Start();
            }
        }

        private void StopCamera()
        {
            if (_CameraSource != null && _CameraSource.IsRunning)
            {
                _CameraSource.SignalToStop();
                _CameraSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
            }
        }

        private void video_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                BitmapImage bi;
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    bi = bitmap.ToBitmapImage();
                }
                bi.Freeze(); // avoid cross thread operations and prevents leaks
                Dispatcher.BeginInvoke(new ThreadStart(delegate { videoPlayer.Source = bi; }));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error on _videoSource_NewFrame:\n" + exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                StopCamera();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            StartCamera();
        }

        private void capture_Click(object sender, RoutedEventArgs e)
        {

        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            StopCamera();
        }
       
    }
    #endregion
}

