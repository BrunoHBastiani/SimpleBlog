namespace SimpleBlog.Data.Filters
{
    public record PostFilter
    {
        public Guid? UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public PostFilter(Guid? userId, string? title, string? content)
        {
            UserId = userId;
            Title = title;
            Content = content;
        }
    }
}
