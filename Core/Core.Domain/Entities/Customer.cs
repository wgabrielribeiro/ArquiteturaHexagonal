using Core.Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace Core.Domain.Entities;

public class Customer : Notifiable, IEntity, IValidatable
{
    public Guid Id { get; private set; }
    private readonly IList<Address> _addresses;
    public Customer(
        NameVo name,
        CpfVo cpf,
        EmailVo email,
        string phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Cpf = cpf;
        Email = email;
        Phone = phone;
        _addresses = [];

        Validate();
    }

    public NameVo Name { get; private set; }
    public CpfVo Cpf { get; private set; }
    public EmailVo Email { get; private set; }
    public string Phone { get; private set; }
    public IReadOnlyCollection<Address> Addresses => [.. _addresses];

    public void AddAddress(Address address)
    {
        _addresses.Add(address);
    }

    public override string ToString()
    {
        return Name.ToString();
    }

    public void Validate()
    {
        AddNotifications(
            new Flunt.Validations.Contract()
            .IsTrue(Name.Valid, "Name", "Nome inválido")
            .IsTrue(Cpf.Valid, "Cpf", "Cpf inválido")
            .IsTrue(Email.Valid, "Email", "Email inválido")
                );
    }
}
