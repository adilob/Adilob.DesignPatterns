
using Adilob.DesignPatterns.API.Application.ChainOfResponsability;
using Adilob.DesignPatterns.API.Infrastructure.Customers;
using Adilob.DesignPatterns.API.Infrastructure.Deliveries;
using Adilob.DesignPatterns.API.Infrastructure.Integrations;
using Adilob.DesignPatterns.API.Infrastructure.Orders;
using Adilob.DesignPatterns.API.Infrastructure.Payments.Services;
using Adilob.DesignPatterns.API.Infrastructure.Payments;
using Adilob.DesignPatterns.API.Infrastructure.Products;
using Adilob.DesignPatterns.API.Infrastructure.Proxies;

namespace Adilob.DesignPatterns.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddMemoryCache();
			builder.Services.AddHttpContextAccessor();

			builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IPaymentFraudCheckService, PaymentFraudCheckService>();
			builder.Services.AddScoped<IOrderHandler, CheckForFraudHandler>();
			builder.Services.AddScoped<IOrderHandler, ValidateCustomerHandler>();
			builder.Services.AddScoped<IOrderHandler, ValidateStockHandler>();
			builder.Services.AddScoped<IPostOrderHandler, PostOrderHandler>();
			builder.Services.AddScoped<CustomerRepositoryProxy>();

			builder.Services.AddTransient<IPaymentService, CreditCardService>();
			builder.Services.AddTransient<IPaymentService, PaymentSlipService>();
			builder.Services.AddTransient<IExternalPaymentSlipService, ExternalPaymentSlipService>();
			builder.Services.AddTransient<ICoreCrmIntegrationService, CoreCrmIntegrationService>();
			builder.Services.AddTransient<IAntiFraudFacade, AntiFraudFacade>();
			builder.Services.AddTransient<IDeliveryService, NationalDeliveryService>();
			builder.Services.AddTransient<IDeliveryService, InternationalDeliveryService>();
			builder.Services.AddTransient<IPaymentServiceFactory, PaymentServiceFactory>();
			builder.Services.AddTransient<IOrderAbstractFactory, NationalOrderAbstractFactory>();
			builder.Services.AddTransient<IOrderAbstractFactory, InternationalOrderAbstractFactory>();

			builder.Services.AddSingleton<IOrderFactorySelector, OrderFactorySelector>();
			builder.Services.AddSingleton<PaymentMethodsFactory>();

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
