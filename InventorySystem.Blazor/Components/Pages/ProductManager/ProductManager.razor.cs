using InventorySystem.Blazor.Features.Brands.Contracts;
using InventorySystem.Blazor.Features.Brands.Services;
using InventorySystem.Blazor.Features.Categories.Contracts;
using InventorySystem.Blazor.Features.Categories.Services;
using InventorySystem.Blazor.Features.Models.Contracts;
using InventorySystem.Blazor.Features.Models.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace InventorySystem.Blazor.Components.Pages.ProductManager;

public partial class ProductManager
{
    [Inject]
    private ProductCategoriesApiClient ApiCategory { get; set; } = default!;
    [Inject]
    private ProductBrandsApiClient ApiBrand { get; set; } = default!;
    [Inject]
    private ProductModelsApiClient ApiModel { get; set; } = default!;

    private Guid? CategoryId;
    private Guid? BrandId;
    private string? _error;

    private bool IsActiveNewCategory;
    private bool IsActiveNewBrand;

    private string _nameCategory = string.Empty;
    private string _nameBrand = string.Empty;
    private string _nameModel = string.Empty;

    private async Task CreateCategory()
    {
        _error = null;

        if (string.IsNullOrWhiteSpace(_nameCategory))
        {
            _error = "Name is required.";
            return;
        }

        try
        {
            await ApiCategory.CreateAsync(new CreateProductCategoryRequest(_nameCategory));

            _nameCategory = string.Empty;

            if (_categoryList is not null)
                await _categoryList.ReloadAsync();

            ToggleNewCategory();
            Snackbar.Add("Categoría creada correctamente", Severity.Success);
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            Console.WriteLine(ex.ToString());
            await InvokeAsync(StateHasChanged);
        }
        finally
        {
            await InvokeAsync(StateHasChanged);
        }
    }

    private async Task CreateBrand()
    {
        _error = null;

        if (string.IsNullOrWhiteSpace(_nameBrand))
        {
            _error = "Name is required.";
            return;
        }

        try
        {
            await ApiBrand.CreateAsync(new CreateProductBrandRequest(_nameBrand));

            _nameBrand = string.Empty;

            if (_brandList is not null)
                await _brandList.ReloadAsync();

            ToggleNewBrand();
            Snackbar.Add("Marca creada correctamente", Severity.Success);
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            Console.WriteLine(ex.ToString());
            await InvokeAsync(StateHasChanged);
        }
        finally
        {
            await InvokeAsync(StateHasChanged);
        }
    }

    private async Task CreateModel()
    {
        _error = null;

        if (string.IsNullOrWhiteSpace(_nameModel) || CategoryId is null || BrandId is null)
        {
            _error = "Name,Category and Brand are required.";
            return;
        }

        try
        {
            await ApiModel.CreateAsync(new CreateProductModelRequest(CategoryId.Value, BrandId.Value, _nameModel));
            if (_productModelTable is null) return;
            await _productModelTable.ReloadAync();
            CategoryId = null;
            BrandId = null;
            _nameModel = string.Empty;
            Snackbar.Add("Modelo creado correctamente", Severity.Success);  
        }
        catch (Exception ex)
        {
            _error = ex.Message;
            await InvokeAsync(StateHasChanged);
        }
        finally
        {
            await InvokeAsync(StateHasChanged);
        }
    }
}
