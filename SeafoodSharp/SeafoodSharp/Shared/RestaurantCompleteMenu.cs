namespace SeafoodSharp.Shared;

public class RestaurantCompleteMenu
{
    public List<RestaurantMenuItem> MenuItems { get; set; }

    public RestaurantCompleteMenu()
    {
        MenuItems = new();
    }
}
