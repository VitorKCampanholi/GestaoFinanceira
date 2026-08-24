using Blazored.LocalStorage;
using GestaoFinanceira.Data;
using Microsoft.AspNetCore.Components;

namespace GestaoFinanceira.Components.Pages.Painel
{
    public class PageBase : ComponentBase
    {
        [Inject] public ILocalStorageService LocalStorage { get; set; } = null!;
        [Inject] public ApplicationDbContext DB { get; set; } = null!;
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    }
}
