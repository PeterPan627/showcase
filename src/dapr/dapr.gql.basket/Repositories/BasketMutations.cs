using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace dapr.gql.basket.Repositories
{
    public record UpsertBasketItemInput(int Id, int CustomerId, int ProductId, int Quantity);
    public record UpsertBasketItemResult(int Id, int CustomerId, int ProductId, int Quantity);

    public class BasketMutations
    {
        public async Task<UpsertBasketItemResult> UpsertBasketItemAsync(
            UpsertBasketItemInput input,
            [Service]BasketRepository repository)
        {
            var item = new BasketItem(input.Id, input.CustomerId, input.ProductId, input.Quantity);
            repository.Add(item);
            return await Task.FromResult(new UpsertBasketItemResult(item.Id, item.CustomerId, input.ProductId, input.Quantity));
        }
    }
}