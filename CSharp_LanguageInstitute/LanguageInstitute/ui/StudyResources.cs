using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeSearch;

namespace LanguageInstitute.ui
{
    public partial class StudyResources : MaterialForm
    {
        public StudyResources()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            VideoSearch items = new VideoSearch();
            List<Video> list = new List<Video>();
            foreach (var item in items.SearchQuery(txtSearch.Text, 1))
            {
                Video video = new Video();
                video.Title = item.Title;
                video.Author = item.Author;
                video.Url = item.Url;
                byte[] imageBytes = new WebClient().DownloadData(item.Thumbnail);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    video.Thumbnail = Image.FromStream(ms);
                }
                list.Add(video);
            }
            videoBindingSource.DataSource = list;
        }
    }
}
