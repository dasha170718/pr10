using System;

namespace pr10.models;

public class Order
{
    private int id;
    private DateTime date;
    private DateTime deliveryDate;
    private Point? point;
    private User? client;
    private int codeReceive;
    private OrderStatus? statusOrder;
    

    public Order(int id, DateTime date, DateTime deliveryDate, Point? point,
        User? client, int codeReceive, OrderStatus? statusOrder)
    {
        this.id = id;
        this.date = date;
        this.deliveryDate = deliveryDate;
        this.point = point;
        this.client = client;
        this.codeReceive = codeReceive;
        this.statusOrder = statusOrder;
    }

    public int Id => id;


    public DateTime Date => date;

    public DateTime DeliveryDate => deliveryDate;

    public Point? Point => point;

    public User? Client => client;

    public int CodeReceive => codeReceive;

    public OrderStatus? StatusOrder => statusOrder;
}