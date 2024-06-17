using RestSharp;
using System.Collections.Generic;

namespace Core.Utilities.RestHelper
{
    public struct RestRequestParameter
    {
        public string BaseUrl { get; set; }
        public string? Authorization { get; set; }
        public Dictionary<string, object>? QueryParameters { get; set; }
        public ContentType? ContentType { get; set; }
        public int? TimeOut { get; set; }
        public List<RestFile> Files { get; set; }
    }

    public class RestFile
    {
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        public string FileName { get; set; }
        public ContentType? ContentType { get; set; }
    }
}
