using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Rootobject
    {
        public Metadata metaData { get; set; }
        public string[] countryCodes { get; set; }
    }

    public class Metadata
    {
        public string defaultLang { get; set; }
        public string name { get; set; }
        public string[] categoryIds { get; set; }
        public string[] tagIds { get; set; }
        public string residentAGApp { get; set; }
        public string sourceName { get; set; }
        public int sellingMode { get; set; }
        public string remarks { get; set; }
        public DateTime availableFrom { get; set; }
        public DateTime availableBefore { get; set; }
        public Autostatuschange[] autoStatusChange { get; set; }
        public bool eduappUsed { get; set; }
        public bool eduappPurchased { get; set; }
        public string devProductId { get; set; }
        public string distNotifyUrl { get; set; }
        public int validityUnit { get; set; }
        public int validityNum { get; set; }
        public bool includeLessons { get; set; }
        public int typeId { get; set; }
        public string[] teachers { get; set; }
        public int mediaType { get; set; }
        public bool needDelivery { get; set; }
    }

    public class Autostatuschange
    {
        public int status { get; set; }
        public string changeTime { get; set; }
    }
}
