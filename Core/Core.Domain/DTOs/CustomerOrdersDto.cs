namespace Core.Domain.DTOs
{
    public class CustomerOrdersDto
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }        
        public required string OrderId { get; set; }
    }
}
