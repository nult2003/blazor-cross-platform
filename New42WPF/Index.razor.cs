namespace New42WPF
{
    public partial class Index
    {
        private string message = "Hey, it's Blazor in WPF!";

        public string Message
        {
            get => message;
            set
            {
                message = value;
                StateHasChanged();
            }
        }

        //protected override void OnInitialized()
        //{
        //    AppState.IndexComponent = this;
        //}
    }
}