namespace Site.Client.Domain;

public sealed record SliderData
{
    public SliderData()
    {
    }

    public SliderData(string title, string subTitle, string description, string imageSrc)
    {
        Title = title;
        SubTitle = subTitle;
        Description = description;
        ImageSrc = imageSrc;
    }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Description { get; set; }

    public string ImageSrc { get; set; }
}