using Core.Domain.Entities;
using Core.Domain.ValueObjects;
using Flunt.Notifications;

namespace Tests.UnitTests.UnitsTests;
public class OrderTests : Notifiable
{
    private Product _teclado;
    private Product _mouse;
    private Product _monitor;
    private Customer _customer;
    private Order _order;
    
    [SetUp]
    public void Setup()
    {
        //Simular dados
        var name = new NameVo("João", "Silva");
        var cpf = new CpfVo("234234233");
        var email = new EmailVo("exemplo@hotmail.com");

        _teclado = new Product("Teclado", "Teclado Microsoft", "teclado.jpg", 100, 10);
        _mouse = new Product("Mouse", "Mouse Microsoft", "mouse.jpg", 100, 10);
        _monitor = new Product("Monitor", "Monitor Microsoft", "monitor.jpg", 100, 10);

        _customer = new Customer(name, cpf, email, "119546456");
        _order = new Order(_customer);
    }

    [Test]
    public void OrderTests_CreateOrder_WhenValidReturnTrue()
    {
        Assert.That(true, Is.EqualTo(_order.Valid));
    }

    [Test]
    public void OrderTests_CreateOrder_ShouldSubstract5FromStock()
    {
        _order.AddItem(_monitor, 5);
        Assert.That(5, Is.EqualTo(_monitor.StockQuantity));
    }
    
    
}