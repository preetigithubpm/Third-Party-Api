using MediatR;
using task29August.features.Patients.Queries;
using task29August.Models;
using task29August.RequestModel;


namespace task29August.features.Cart
{
    public class GetByIdCartQuery : IRequest<List<GetAllModelCart>>
    {
        public int uId { get; set; }
        public class GetByIdCartQueryHandler : IRequestHandler<GetByIdCartQuery, List<GetAllModelCart>>
        {
            private readonly sdirectdbContext db;
            public GetByIdCartQueryHandler(sdirectdbContext db)
            {
                this.db = db;
            }

            public async Task<List<GetAllModelCart>> Handle(GetByIdCartQuery request, CancellationToken cancellationToken)
            {
                GetAllModelCart model = new GetAllModelCart();
                var obj = (from p in db.CartbookDetails
                           join i in db.ImageUpLoadEmployees
                           on p.ProductId equals i.Id
                           where p.UserId == request.uId
                           select new GetAllModelCart
                           {
                               UserId = p.UserId,
                               Price = p.Price,
                               Quantity = p.Quantity,
                               Id = p.ProductId,
                               ImagePath = i.ImgLoc,
                               TotalPrice = p.TotalPrice,


                           }).ToList();
                return obj;
            }
        }
    }
}
