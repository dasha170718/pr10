namespace pr10.models;

public class FullOrder
{
    private int id;
    private Order order;
    private Product product;
    private int countProduct;

    public FullOrder(int id, Order order, Product product,int countProduct)
    {
        this.id = id;
        this.order = order;
        this.product = product;
        this.countProduct = countProduct;
    }

    public int Id => id;

    public Order Order => order;

    public Product Product => product;

    public int CountProduct => countProduct;
}