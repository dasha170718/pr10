using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using pr10.models;

namespace pr10;

public partial class MainWindow : Window
{
    private Database.Database db;
    private List<User> _users;
    private int countLog = 0;
    public MainWindow()
    {
        InitializeComponent();
        db = new Database.Database();
        _users = db.GetAllUsers();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        countLog++;
        var login = LoginBOX.Text;
        var password = PasswordBOX.Text;
        if(login==null) return;
        if(password == null) return;
        foreach (var user in (_users))
        {
            if (user.Login != login || user.Password != password) continue;
            if (user.Role.Name == "Администратор")
            {
                new ProfileAdmin(user).Show();
                Close();
                return;
            }
            new Profile(user).Show();
            Close();
            return;

        }
        
        MessageBoxManager.GetMessageBoxStandard("Ошибка входа", "Неправильно введен пароль или логин!", ButtonEnum.Ok).ShowAsync();
        
    }

    private void LogAsGuest(object? sender, RoutedEventArgs e)
    {
        new Profile().Show();
        Close();
    }
}