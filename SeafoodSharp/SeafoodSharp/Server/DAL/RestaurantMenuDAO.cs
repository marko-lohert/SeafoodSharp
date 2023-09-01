using SeafoodSharp.Shared;

namespace SeafoodSharp.Server.DAL;

public class RestaurantMenuDAO
{
    public RestaurantCompleteMenu GetCompleteMenu()
    {
        // Mock data (prepared for the presentation).

        RestaurantCompleteMenu menu = new();

        menu.MenuItems.Add(new RestaurantMenuItem("Deep-fired calamari", "Deep-fired fresh calamari", new Price(10, "€"), "Main Dish"));
        menu.MenuItems.Add(new RestaurantMenuItem("Grilled calamari", "Grilled fresh calamari", new Price(10, "€"), "Main Dish"));
        menu.MenuItems.Add(new RestaurantMenuItem("Shrimp risotto", "Creamy shrimp risotto", new Price(15, "€"), "Main Dish"));
        menu.MenuItems.Add(new RestaurantMenuItem("Salmon", new Price(20, "€")));
        menu.MenuItems.Add(new RestaurantMenuItem("Tuna steak", new Price(25, "€")));

        return menu;
    }
}
