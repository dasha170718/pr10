using System;
using Avalonia.Media.Imaging;
using SkiaSharp;

namespace pr10.models;

public class Product
{
    private int id;
    private string article;
    private string name;
    private UnitMeasurement? unit;
    private int price;
    private int maxSale;
    private Manufacture? manufacturer;
    private Provider? provider;
    private Category? category;
    private int currentSale;
    private int? count;
    private string description;
    private string image;
    private bool isStock = false;
    private Bitmap BitmapImage;

    public Product(int id,string article, string name, UnitMeasurement? unit, int price, int maxSale, Manufacture? manufacturer,
        Provider? provider, Category? category, int currentSale, int? count, string description, string image)
    {
        this.id = id;
        this.article = article;
        this.name = name;
        this.unit = unit;
        this.price = price;
        this.maxSale = maxSale;
        this.manufacturer = manufacturer;
        this.provider = provider;
        this.category = category;
        this.currentSale = currentSale;
        this.count = count;
        this.description = description;
        this.image = image;
        if (image != null) this.image.Replace("data/", "");
        else this.image = "picture.png";
        //BitmapImage = new Bitmap(ImagePath);
        if (count > 0) isStock = true;
    }
    public Product(string article, string name, UnitMeasurement? unit, int price, int maxSale, Manufacture? manufacturer,
        Provider? provider, Category? category, int currentSale, int? count, string description, string image)
    {
        this.article = article;
        this.name = name;
        this.unit = unit;
        this.price = price;
        this.maxSale = maxSale;
        this.manufacturer = manufacturer;
        this.provider = provider;
        this.category = category;
        this.currentSale = currentSale;
        this.count = count;
        this.description = description;
        this.image = image;
        if (count > 0) isStock = true;
    }

    public Bitmap IMAGE => BitmapImage;

    public int Id => id;

    public string Article => article;

    public string Name => name;

    public UnitMeasurement? Unit => unit;

    public int Price => price;

    public int MaxSale => maxSale;

    public Manufacture? Manufacturer => manufacturer;

    public Provider? Provider => provider;

    public Category? Category => category;

    public int CurrentSale => currentSale;

    public int? Count => count;

    public string Description => description;

    public string ImagePath => $"data/{image}";
    public string Image => image;
    public bool IsStock => isStock;
    
}