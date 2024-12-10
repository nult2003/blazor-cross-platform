using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

public static class BlogDataManager
{
    private static readonly string url = "https://devblogs.microsoft.com/dotnet/feed/";
    public static List<BlogPost> BlogPosts = new List<BlogPost>();

    public static void GetBlogPosts()
    {
        var posts = new List<BlogPost>();
        using var reader = XmlReader.Create(url);
        var feed = SyndicationFeed.Load(reader);
        foreach (var item in feed.Items)
        {
            var post = new BlogPost();
            post.PublishDate = item.PublishDate.DateTime;
            var creators = item.ElementExtensions.ReadElementExtensions<string>("creators", "http://purl.org/dc/elements/1.1/");
            if (creators != null && creators.Count > 0)
            {
                post.Author = creators.FirstOrDefault<string>();
            }

            // title
            post.Title = item.Title.Text;
            post.Description = item.Summary.Text;
            posts.Add(post);
        }

        BlogPosts.Clear();
        BlogPosts.AddRange(posts);
    }
}