using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using pr10.models;

namespace pr10;

public partial class AddorEditProduct : Window
{
    private Product _product;
    private Database.Database db;
    private ProfileAdmin owner;
    private List<Manufacture> _manufactures;
    private List<Provider> _providers;
    private List<UnitMeasurement> _unitMeasurements;
    private List<Category> _categories;
    private bool IsNew = true;
    public AddorEditProduct(ProfileAdmin win)
    {
        InitializeComponent();
        owner = win;
        db = new Database.Database();
        _manufactures= db.GetAllManufactures();
        _providers = db.GetAllProviders();
        _categories = db.GetAllCategories();
        _unitMeasurements = db.GetAllUnitMeasurements();
        ManufacturerComboBox.ItemsSource = _manufactures;
        ProvderComboBox.ItemsSource = _providers;
        UnitComboBox.ItemsSource = _unitMeasurements;
        CategoryComboBox.ItemsSource = _categories;
        Id.IsVisible = false;
        tbId.IsVisible = false;
        
    }
    public AddorEditProduct(Product product,ProfileAdmin win):this(win)
    {
        Id.IsVisible = true;
        tbId.IsVisible = true;
        _product = product;
        LoadProduct();
        IsNew = false;
    }

    public void LoadProduct()
    {
        Id.Text = _product.Id.ToString();
        ArticleTextBox.Text = _product.Article;
        NameTextBox.Text = _product.Name;
        UnitComboBox.SelectedItem = _unitMeasurements.FirstOrDefault(u => u.Id == _product.Unit.Id);
        PriceTextBox.Text = _product.Price.ToString();
        MaxSaleTextBox.Text = _product.MaxSale.ToString();
        ManufacturerComboBox.SelectedItem = _manufactures.FirstOrDefault(u => u.Id == _product.Manufacturer.Id);
        ProvderComboBox.SelectedItem = _providers.FirstOrDefault(u => u.Id == _product.Provider.Id);
        CategoryComboBox.SelectedItem = _categories.FirstOrDefault(u => u.Id == _product.Category.Id);
        CurrentSaleTextBox.Text = _product.CurrentSale.ToString();
        CountTextBox.Text = _product.Count.ToString();
        DescriptionTextBox.Text = _product.Description;
        Button.Content = "Изменить продукт";
    }

    private void Add(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (IsNew)
            {
                _product = new Product(ArticleTextBox.Text,
                    NameTextBox.Text,
                    (UnitMeasurement)UnitComboBox.SelectionBoxItem,
                    Convert.ToUInt16(PriceTextBox.Text),
                    Convert.ToUInt16(MaxSaleTextBox.Text),
                    (Manufacture)ManufacturerComboBox.SelectionBoxItem,
                    (Provider)ProvderComboBox.SelectionBoxItem,
                    (Category)CategoryComboBox.SelectionBoxItem,
                    Convert.ToUInt16(CurrentSaleTextBox.Text),
                    Convert.ToUInt16(CountTextBox.Text),
                    DescriptionTextBox.Text,
                    "picture.png");
                db.InsertProduct(_product);
            }
            else
            {
                Product changeProduct = new Product(
                    _product.Id,
                    ArticleTextBox.Text,
                    NameTextBox.Text,
                    (UnitMeasurement)UnitComboBox.SelectionBoxItem,
                    Convert.ToUInt16(PriceTextBox.Text),
                    Convert.ToUInt16(MaxSaleTextBox.Text),
                    (Manufacture)ManufacturerComboBox.SelectionBoxItem,
                    (Provider)ProvderComboBox.SelectionBoxItem,
                    (Category)CategoryComboBox.SelectionBoxItem,
                    Convert.ToUInt16(CurrentSaleTextBox.Text),
                    Convert.ToUInt16(CountTextBox.Text),
                    DescriptionTextBox.Text,
                    _product.Image);
                db.UpdateProduct(changeProduct);
            }
            owner.Update();
            Close();
        }
        catch (Exception exception)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", exception.Message, ButtonEnum.Ok).ShowAsync();
        }
    }
    private void MaxSaleTextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        TextBox a = (TextBox)sender;
        int pos = a.SelectionStart;
        a.Text = new String(a.Text.Where(char.IsDigit).ToArray());
        a.SelectionStart = pos;
    }

    private void TopLevel_OnClosed(object? sender, EventArgs e)
    {
        owner.Update();
    }
}