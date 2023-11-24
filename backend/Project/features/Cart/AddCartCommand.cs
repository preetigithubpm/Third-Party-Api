using MediatR;
using NETCore.MailKit.Core;
using task29August.features.Patients.Command;
using task29August.Models;
using task29August.RequestModel;
using task29August.ResponseModel;
using task29August.repository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace task29August.features.Cart
{
    public class AddCartCommand : AddImagePatient1, IRequest<Response1>
    {

        public class AddCartCommandHandler : IRequestHandler<AddCartCommand, Response1>
        {
            private readonly repository.IEmailService _iemail;
            private readonly IConfiguration _configuration;
            private IWebHostEnvironment _environment;
            private readonly sdirectdbContext _db;

            public AddCartCommandHandler(repository.IEmailService email, IConfiguration configuration, IWebHostEnvironment environment, sdirectdbContext db)
            {
                _iemail = email;
                _configuration = configuration;
                _environment = environment;
                _db = db;
            }

            public async Task<Response1> Handle(AddCartCommand request, CancellationToken cancellationToken)
            {
                Response1 res = new Response1();
                var obj = _db.CartbookDetails.Where(i => i.ProductId == request.Id && i.UserId == request.UserId).FirstOrDefault();
                if (obj != null)
                {
                    obj.Quantity = obj.Quantity + request.Quantity;
                    obj.TotalPrice = request.Price * obj.Quantity;
                    _db.SaveChanges();
                    res.ResponseMessage = "Add to Cart";
                    return res;

                }
                else
                {
                    CartbookDetail cart = new CartbookDetail()
                    {
                        UserId = request.UserId,
                        Price = request.Price,
                        Quantity = request.Quantity,
                        TotalPrice = request.Price,
                        ProductId = request.Id,


                    };
                    _db.CartbookDetails.Add(cart);
                    _db.SaveChanges();
                    res.ResponseMessage = "Add to Cart";
                    return res;


                }

            }
        }
    }
}
