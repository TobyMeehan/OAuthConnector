﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    [DataContract]
    public class ApplicationBase : EntityBase
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "icon_url")]
        public string IconUrl { get; set; }

        [DataMember(Name = "download_id")]
        public string DownloadId { get; set; }
    }
}
