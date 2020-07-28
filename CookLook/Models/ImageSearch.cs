using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookLook.Models
{

    public class Url
    {
        public string Type { get; set; }
        public string Template { get; set; }
    }

    public class Request
    {
        public string Title { get; set; }
        public string TotalResults { get; set; }
        public string SearchTerms { get; set; }
        public int Count { get; set; }
        public int StartIndex { get; set; }
        public string InputEncoding { get; set; }
        public string OutputEncoding { get; set; }
        public string Safe { get; set; }
        public string Cx { get; set; }
        public string SearchType { get; set; }
    }

    public class NextPage
    {
        public string Title { get; set; }
        public string TotalResults { get; set; }
        public string SearchTerms { get; set; }
        public int Count { get; set; }
        public int StartIndex { get; set; }
        public string InputEncoding { get; set; }
        public string OutputEncoding { get; set; }
        public string Safe { get; set; }
        public string Cx { get; set; }
        public string SearchType { get; set; }
    }

    public class Queries
    {
        public IList<Request> Request { get; set; }
        public IList<NextPage> NextPage { get; set; }
    }

    public class Context
    {
        public string Title { get; set; }
    }

    public class SearchInformation
    {
        public double SearchTime { get; set; }
        public string FormattedSearchTime { get; set; }
        public string TotalResults { get; set; }
        public string FormattedTotalResults { get; set; }
    }

    public class Image
    {
        public string ContextLink { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ByteSize { get; set; }
        public string ThumbnailLink { get; set; }
        public int ThumbnailHeight { get; set; }
        public int ThumbnailWidth { get; set; }
    }

    public class Item
    {
        public string Kind { get; set; }
        public string Title { get; set; }
        public string HtmlTitle { get; set; }
        public string Link { get; set; }
        public string DisplayLink { get; set; }
        public string Snippet { get; set; }
        public string HtmlSnippet { get; set; }
        public string Mime { get; set; }
        public string FileFormat { get; set; }
        public Image Image { get; set; }
    }

    public class ImageSearch
    {
        public string Kind { get; set; }
        public Url Url { get; set; }
        public Queries Queries { get; set; }
        public Context Context { get; set; }
        public SearchInformation SearchInformation { get; set; }
        public IList<Item> Items { get; set; }
    }

}
