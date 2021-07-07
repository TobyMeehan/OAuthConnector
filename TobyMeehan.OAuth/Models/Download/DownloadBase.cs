using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TobyMeehan.OAuth.Models
{
    [DataContract]
    public class DownloadBase : EntityBase
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "short_description")]
        public string ShortDescription { get; set; }

        [DataMember(Name = "long_description")]
        public string LongDescription { get; set; }

        [DataMember(Name = "version")]
        public string VersionString { get; set; }

        public Version Version => Version.Parse(VersionString);

        [DataMember(Name = "authors")]
        public List<UserBase> Authors { get; set; }
    }
}
