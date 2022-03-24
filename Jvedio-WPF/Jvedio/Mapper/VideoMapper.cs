﻿using Jvedio.Core.SimpleORM;
using Jvedio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jvedio.Mapper
{
    public class VideoMapper : BaseMapper<Video>
    {


        public static string[] SelectFields = {
            "metadata.DataID",
            "DBId",
            "Title",
            "Size",
            "Path",
            "Hash",
            "Country",
            "ReleaseDate",
            "ReleaseYear",
            "ViewCount",
            "DataType",
            "Rating",
            "RatingCount",
            "FavoriteCount",
            "Genre",
            "Tag",
            "Grade",
            "Label",
            "ViewDate",
            "FirstScanDate",
            "LastScanDate",
            "CreateDate",
            "UpdateDate",
            "(select group_concat(TagID,',') from metadata_to_tagstamp where metadata_to_tagstamp.DataID=metadata.DataID)  as TagIDs ",
            $"(select group_concat(ActorName,'{GlobalVariable.Separator}') from actor_name_to_metadatas where actor_name_to_metadatas.DataID=metadata.DataID) as ActorNames" ,
            "(select group_concat(NameFlag,',') from actor_name_to_metadatas where actor_name_to_metadatas.DataID=metadata.DataID) as NameFlags",

            "VID",
            "MVID",
            "VideoType",
            "Director",
            "Studio",
            "Publisher",
            "Plot",
            "Outline",
            "Duration",
            "SubSection",
            "ImageUrls",
            "PreviewImagePath",
            "ScreenShotPath",
            "GifImagePath",
            "BigImagePath",
            "SmallImagePath",
            "WebType",
            "WebUrl",
        };

        public Video SelectVideoByID(long dataid)
        {
            SelectWrapper<Video> wrapper = new SelectWrapper<Video>();

            wrapper.Select(SelectFields).Eq("metadata.DataID", dataid);
            string sql = $"{wrapper.toSelect(false)} FROM metadata_video " +
                        "JOIN metadata " +
                        "on metadata.DataID=metadata_video.DataID " + wrapper.toWhere(false);
            List<Dictionary<string, object>> list = select(sql);
            List<Video> videos = toEntity<Video>(list, typeof(Video).GetProperties(), false);
            if (videos.Count > 0) return videos[0];
            return null;
        }

        public int deleteVideoByIds(List<string> idList)
        {
            if (idList == null || idList.Count == 0) return 0;
            int c1 = GlobalMapper.metaDataMapper.deleteByIds(idList);
            int c2 = GlobalMapper.videoMapper.deleteByIds(idList);
            StringBuilder builder = new StringBuilder();
            string ids = string.Join(",", idList);
            builder.Append("begin;");
            builder.Append($"delete from metadata_to_translation where DataID in ({ids});");
            builder.Append($"delete from metadata_to_tagstamp where DataID in ({ids});");
            builder.Append($"delete from actor_name_to_metadatas where DataID in ({ids});");
            builder.Append($"delete from common_custom_list_to_metadata where DataID in ({ids});");
            builder.Append("commit;");
            GlobalMapper.videoMapper.executeNonQuery(builder.ToString());
            if (c1 == c2 && idList.Count == c1) return c1;
            else
            {
                // todo 日志

            }
            return 0;

        }
    }
}
