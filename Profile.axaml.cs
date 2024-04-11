using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using pr10.models;

namespace pr10;

public partial class Profile : Window
{
    private User _user;
    private List<Product> _products;
    private Database.Database db = new Database.Database();
    private bool isSoorted = false;
    private bool isSort = true;
    private Manufacture currentManufacture;
    private string currentSearch = "";
    private List<Product> newProducts;

    public Profile()
    {
        InitializeComponent();
        db = new Database.Database();
        _products = db.GetAllProducts();
        ListProducts.ItemsSource = _products;
        cbManu.ItemsSource = db.GetAllManufactures();
        newProducts = _products;
    }

    public Profile(User user) : this()
    {
        _user = user;
        NameUser.Text = _user.Name;
    }
    private void LogOut(object? sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }

    private void Sort(object? sender, RoutedEventArgs e)
    {
        isSoorted = true;
        Sort(newProducts);
    }

    private void Sort(List<Product> products)
    {
        if (isSort)
        {
            ListProducts.ItemsSource = products.OrderBy(u => u.Price);
            isSort = false;
        }
        else
        {
            ListProducts.ItemsSource = products.OrderByDescending(u => u.Price);
            isSort = true;
        }
    }

    private void SearchChanged(object? sender, TextChangedEventArgs e)
    {
        currentSearch = tbSearch.Text;
        Filter();
    }

    private void Filter()
    {
        if (currentManufacture != null && currentSearch != "" ) 
        {
            newProducts = _products.Where(u=>u.Name.ToLower().Contains(currentSearch.ToLower()) 
                                             || u.Description.ToLower().Contains(currentSearch.ToLower()) 
                                             && u.Manufacturer.Name.Contains(currentManufacture.Name)).ToList();
        }
        else if (currentSearch != "")
        {
            newProducts = _products.Where(u=>u.Name.ToLower().Contains(currentSearch.ToLower()) 
                                             || u.Description.ToLower().Contains(currentSearch.ToLower())).ToList();
        }
        else if (currentManufacture != null)
        {
            newProducts = _products.Where(u=> u.Manufacturer.Name.Contains(currentManufacture.Name)).ToList();
        }
        ListProducts.ItemsSource = newProducts;
        if (isSoorted)
        {
            isSort = !isSort;
            Sort(newProducts);
        }
    }

    private void SelectedItem(object? sender, SelectionChangedEventArgs e)
    {
        currentManufacture = (Manufacture)cbManu.SelectedItem;
        Filter();
    }
}