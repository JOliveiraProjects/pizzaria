using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using Pizzaria.Gateway.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Pizzaria.Gateway.Aggregators
{
    public class CustomerWithOrdersAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<DownstreamResponse> responses)
        {
            CustomerWithOrders customerWithOrders = await responses[0].Content
                .ReadAsAsync<CustomerWithOrders>().ConfigureAwait(false);

            customerWithOrders.Orders = await responses[1].Content
                .ReadAsAsync<List<Order>>().ConfigureAwait(false);

            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new ObjectContent<CustomerWithOrders>(customerWithOrders, 
                    new JsonMediaTypeFormatter())
            };

            return await Task.FromResult(new DownstreamResponse(response));
        }
    }
}
