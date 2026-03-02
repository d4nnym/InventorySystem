using InventorySystem.Blazor.Features.Models.Contracts;
using Microsoft.AspNetCore.Components;
using InventorySystem.Blazor.Features.Models.Services;


namespace InventorySystem.Blazor.Features.Models.Components
{
    partial class ProductModelTable
    {
        private bool _loading = true;
        private string? _error;
        private string searchString1 = "";
        private List<ProductModelDetailResponse> _modelDetails = [];
        private ProductModelDetailResponse selectedItem1 = null!;
        private HashSet<ProductModelDetailResponse> selectedItems = new HashSet<ProductModelDetailResponse>();

        [Inject]
        private ProductModelsApiClient ApiModel { get; set; } = default!;

        private bool FilterFunc1(ProductModelDetailResponse element) => FilterFunc(element, searchString1);

        private bool FilterFunc(ProductModelDetailResponse element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.BrandName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.CategoryName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ModelName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        

        protected override async Task OnInitializedAsync() => await ReloadAync();

        public async Task ReloadAync()
        {
            _loading = true;
            _error = null;


            try
            {
                _modelDetails = (await ApiModel.GetDetailsAsync()).ToList();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
            finally
            {
                _loading = false;

            }
            await InvokeAsync(StateHasChanged);
        }
    }
}
