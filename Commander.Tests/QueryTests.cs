using Commander.Core.Extensions;
using Commander.Core.Queries;

namespace Commander.Tests;

public sealed class QueryTests
{
    [Fact]
    public void UseQueryForObjectTest()
    {
        var query = new GetToLowerItemTitleQuery();
        var item = new Item(nameof(UseQueryForObjectTest));

        Assert.Equal(nameof(UseQueryForObjectTest).ToLower(), item.Action(query));
    }

    private sealed class Item
    {
        public Item(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }

    private sealed class GetToLowerItemTitleQuery : IQuery<Item, string>
    {
        string IQuery<Item, string>.Execute(Item obj)
        {
            return obj.Title.ToLower();
        }
    }
}