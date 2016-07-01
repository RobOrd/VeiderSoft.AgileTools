using CODE.Framework.Wpf.Mvvm;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace VeiderSoft.AgileTools.Main.Models.Home
{
    public class BingViewModel : ViewModel
    {
        private readonly string _feed;
        private readonly string _tempfilename;
        private readonly string _tempcoppyright;
        private bool _loadcalled;

        public Task DownloadAsync()
        {
            return Task.Run(() =>
            {
                DownLoad();
            });
        }
        public ImageSource WPFPhotoOfTheDay
        {
            get
            {
                if (!_loadcalled)
                    throw new InvalidOperationException("Call the DownLoad() method first");
                return new BitmapImage(new Uri(_tempfilename));
            }
        }
        public string CoppyRightData
        {
            get;
            private set;
        }

        public BingViewModel()
        {
            var tempdir = Environment.ExpandEnvironmentVariables("%temp%");
            _tempfilename = Path.Combine(tempdir, "bingphotooftheday.jpg");
            _tempcoppyright = Path.Combine(tempdir, "bingphotooftheday.txt");
            _loadcalled = false;

            //photo of the day data in xml format
            _feed = "http://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=1&mkt=en-US";

            DownLoad();
        }
        public void DownLoad()
        {
            bool downloadneeded = true;
            //if (File.Exists(_tempfilename))
            //{
            //    FileInfo fi = new FileInfo(_tempfilename);
            //    if ((DateTime.UtcNow - fi.LastWriteTimeUtc).TotalHours < 24)
            //    {
            //        downloadneeded = false;
            //    }
            //}

            //if (File.Exists(_tempcoppyright))
            //{
            //    CoppyRightData = File.ReadAllText(_tempcoppyright);
            //    downloadneeded = false;
            //}
            //else downloadneeded = true;

            _loadcalled = true;
            if (!downloadneeded) return;

            var document = XDocument.Load(_feed).Elements().Elements().FirstOrDefault();

            var url = (from i in document.Elements()
                       where i.Name == "url"
                       select i.Value.ToString()).FirstOrDefault();

            var imgurl = "http://www.bing.com" + url;

            var copyright = (from i in document.Elements()
                             where i.Name == "copyright"
                             select i.Value.ToString()).FirstOrDefault();
            var cplink = (from i in document.Elements()
                          where i.Name == "copyrightlink"
                          select i.Value.ToString()).FirstOrDefault();

            CoppyRightData = copyright + "\r\n" + cplink;
            File.WriteAllText(_tempcoppyright, CoppyRightData);

            using (var client = new WebClient())
            {
                client.DownloadFile(imgurl, _tempfilename);
            }
        }
    }
}
