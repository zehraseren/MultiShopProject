namespace MS.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommand
    {
        public RemoveAddressCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
