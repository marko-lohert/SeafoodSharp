using System.Net.Http.Json;
using SeafoodSharp.Shared;

namespace SeafoodSharp.Client.Pages;

public partial class RestaurantMenu
{
    public RestaurantCompleteMenu Menu { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Menu = await Http.GetFromJsonAsync<RestaurantCompleteMenu>("api/RestaurantMenu/GetCompleteMenu") ?? new RestaurantCompleteMenu();
    }
}
