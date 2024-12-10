namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            BlogDataManager.GetBlogPosts();
        }

        public List<BlogPost> BlogPosts => BlogDataManager.BlogPosts;
    }
}