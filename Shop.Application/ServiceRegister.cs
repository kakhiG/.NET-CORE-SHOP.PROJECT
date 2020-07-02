using Shop.Application.OrdersAdmin;
using Shop.Application.UserAdmin;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            @this.AddTransient<GetOrder>();
            @this.AddTransient<GetOrders>();
            @this.AddTransient<UpdateOrder>();
            @this.AddTransient<CreateUser>();

            return @this;
        }
    }
}