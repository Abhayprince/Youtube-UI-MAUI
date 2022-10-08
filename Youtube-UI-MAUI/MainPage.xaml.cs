using System.Collections.ObjectModel;

namespace Youtube_UI_MAUI;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		Tags = new ObservableCollection<Tag>(GetTags());
        Shorts = new ObservableCollection<ShortModel>(GetShorts());
        RandomShorts = new ObservableCollection<ShortModel>(GetShorts().OrderBy(x=> Guid.NewGuid()));

		BindingContext = this;
	}

	public ObservableCollection<Tag> Tags { get; set; }
	public ObservableCollection<ShortModel> Shorts { get; set; }
	public ObservableCollection<ShortModel> RandomShorts { get; set; }

	private static IEnumerable<Tag> GetTags() =>
		new List<Tag>
		{
			new Tag("All"),
			new Tag("Live"),
			new Tag("Gaming"),
			new Tag("Music"),
			new Tag("Universe"),
			new Tag("Dead malls"),
			new Tag("Shopping malls"),
			new Tag("History"),
			new Tag("Navy"),
			new Tag("Trailers"),
			new Tag("Gadgets"),
			new Tag("Wildlife"),
			new Tag("Recently uploaded"),
			new Tag("Watched"),
		};

	private static IEnumerable<ShortModel> GetShorts() =>
		new List<ShortModel>
		{
			new ShortModel("image1.jpg", "Beautiful city view from sea shore", "2M"),
			new ShortModel("image2.jpg", "Bird waiting in the water", "125K"),
			new ShortModel("image3.jpg", "Adorable Dog", "300"),
			new ShortModel("image4.jpg", "Abstract art represented by fire", "1.5M"),
			new ShortModel("image5.jpg", "Stones only", "0"),
		};

}
public record struct Tag(string Name);
public class ShortModel
{
	public string Image {get; set;}
	public string Title {get; set;}
	public string Views { get; set; }

	public string ViewsDisplay => $"{Views} views";

	public ShortModel(string image, string title, string views)
	{
		Image = image;
		Title = title;
		Views = views;
	}
}

