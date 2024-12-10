using MediatR;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.DeleteProductImage
{
    public class DeleteProductImageCommandRequest : IRequest<DeleteProductImageCommandResponse>
    {
        public string? ProductId { get; set; }
        public string? ImageId { get; set; }
    }
}
