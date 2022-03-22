﻿using Jvedio.Core.Attributes;
using Jvedio.Core.Enums;
using Jvedio.Entity.CommonSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Jvedio.Entity
{

    [Table(tableName: "metadata_video")]
    public class Video : MetaData
    {


        public Video() : this(true) { }

        public Video(bool _initDefaultImage = true)
        {
            if (_initDefaultImage)
                initDefaultImage();
        }

        // 延迟加载图片
        public void initDefaultImage()
        {
            SmallImage = GlobalVariable.DefaultSmallImage;
            BigImage = GlobalVariable.DefaultBigImage;
            GifUri = new Uri("pack://application:,,,/Resources/Picture/NoPrinting_G.gif");
        }


        [TableId(IdType.AUTO)]
        public long MVID { get; set; }
        public long DataID { get; set; }
        public string VID { get; set; }
        public VideoType VideoType { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Publisher { get; set; }
        public string Plot { get; set; }
        public string Outline { get; set; }
        public int Duration { get; set; }

        [TableField(exist: false)]
        public List<string> SubSectionList { get; set; }

        private string _SubSection;
        public string SubSection
        {
            get { return _SubSection; }
            set
            {
                _SubSection = value;
                SubSectionList = value.Split(GlobalVariable.Separator).ToList();
                if (SubSectionList.Count >= 2) HasSubSection = true;
                OnPropertyChanged();
            }
        }
        [TableField(exist: false)]
        public bool HasSubSection { get; set; }
        public string PreviewImagePaths { get; set; }
        public string ScreenShotPaths { get; set; }
        public string GifImagePath { get; set; }
        public string BigImagePath { get; set; }
        public string SmallImagePath { get; set; }
        public string ImageUrls { get; set; }

        public string WebType { get; set; }
        public string WebUrl { get; set; }
        public string ExtraInfo { get; set; }


        private BitmapSource _smallimage;

        [TableField(exist: false)]
        public BitmapSource SmallImage { get { return _smallimage; } set { _smallimage = value; OnPropertyChanged(); } }

        private BitmapSource _bigimage;
        [TableField(exist: false)]
        public BitmapSource BigImage { get { return _bigimage; } set { _bigimage = value; OnPropertyChanged(); } }
        private Uri _GifUri;

        [TableField(exist: false)]
        public Uri GifUri { get { return _GifUri; } set { _GifUri = value; OnPropertyChanged(); } }


        [TableField(exist: false)]
        public List<TagStamp> TagStamp { get; set; }
        [TableField(exist: false)]
        public string TagIDs { get; set; }

        public static string parseImagePath(string path)
        {

            // todo 测试
            string basePicPath = @"D:\soft\Jvedio\Pic";

            //if (path.StartsWith("*PicPath*")) return Path.GetFullPath(GlobalVariable.BasePicPath + path.Replace("*PicPath*", ""));
            if (path.StartsWith("*PicPath*")) return System.IO.Path.GetFullPath(basePicPath + path.Replace("*PicPath*", ""));
            else return path;
        }

    }
}