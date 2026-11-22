using OOP;
using Xunit;

namespace OOP.Tests;

public class MyListTests
{
    [Fact]
    public void NewList_StartsEmptyWithInitialCapacity()
    {
        var list = new MyList<int>();

        Assert.Equal(0, list.Count);
        Assert.Equal(4, list.Capacity);
    }

    [Fact]
    public void Add_AppendsItemsAndExpandsCapacityWhenFull()
    {
        var list = new MyList<int>();

        for (var i = 1; i <= 4; i++)
            list.Add(i);

        Assert.Equal(4, list.Count);
        Assert.Equal(4, list.Capacity);

        list.Add(5);

        Assert.Equal(5, list.Count);
        Assert.Equal(8, list.Capacity);
        AssertItems(list, 1, 2, 3, 4, 5);
    }

    [Fact]
    public void Indexer_GetsAndSetsOnlyExistingItems()
    {
        var list = MakeList(10, 20, 30);

        Assert.Equal(20, list[1]);
        list[1] = 25;
        AssertItems(list, 10, 25, 30);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(3)]
    public void Indexer_ThrowsForInvalidIndex(int index)
    {
        var list = MakeList(10, 20, 30);

        Assert.Throws<IndexOutOfRangeException>(() => _ = list[index]);
        Assert.Throws<IndexOutOfRangeException>(() => list[index] = 99);
    }

    [Fact]
    public void Insert_WorksAtBeginningMiddleAndEnd()
    {
        var list = MakeList(10, 20, 30);

        list.Insert(0, 5);
        list.Insert(2, 15);
        list.Insert(list.Count, 35);

        AssertItems(list, 5, 10, 15, 20, 30, 35);
    }

    [Fact]
    public void Insert_ExpandsCapacityAndPreservesItems()
    {
        var list = MakeList(1, 2, 3, 4);

        list.Insert(2, 99);

        Assert.Equal(8, list.Capacity);
        AssertItems(list, 1, 2, 99, 3, 4);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(4)]
    public void Insert_ThrowsForInvalidIndexWithoutChangingList(int index)
    {
        var list = MakeList(10, 20, 30);

        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(index, 99));

        AssertItems(list, 10, 20, 30);
    }

    [Fact]
    public void RemoveAt_WorksAtBeginningMiddleAndEnd()
    {
        var first = MakeList(10, 20, 30);
        first.RemoveAt(0);
        AssertItems(first, 20, 30);

        var middle = MakeList(10, 20, 30);
        middle.RemoveAt(1);
        AssertItems(middle, 10, 30);

        var last = MakeList(10, 20, 30);
        last.RemoveAt(2);
        AssertItems(last, 10, 20);
    }

    [Fact]
    public void RemoveAt_WorksWhenListFillsItsCapacity()
    {
        var list = MakeList(1, 2, 3, 4);

        list.RemoveAt(3);

        Assert.Equal(3, list.Count);
        Assert.Equal(4, list.Capacity);
        AssertItems(list, 1, 2, 3);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(3)]
    public void RemoveAt_ThrowsForInvalidIndex(int index)
    {
        var list = MakeList(10, 20, 30);

        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(index));
        AssertItems(list, 10, 20, 30);
    }

    [Fact]
    public void FindIndex_ReturnsFirstMatchOrMinusOne()
    {
        var list = MakeList(10, 20, 30, 20);

        Assert.Equal(1, list.FindIndex(20));
        Assert.Equal(-1, list.FindIndex(99));
    }

    [Fact]
    public void Contains_ReportsWhetherValueExistsAmongUsedItems()
    {
        var list = MakeList(10, 20, 30);

        Assert.True(list.Contains(20));
        Assert.False(list.Contains(99));
        Assert.False(list.Contains(0)); // unused array slots must not count as items
    }

    [Fact]
    public void Clear_ResetsCountAndListCanBeUsedAgain()
    {
        var list = MakeList(10, 20, 30);

        list.Clear();

        Assert.Equal(0, list.Count);
        Assert.Equal(4, list.Capacity);
        Assert.Equal(-1, list.FindIndex(10));
        Assert.False(list.Contains(0));
        Assert.Throws<IndexOutOfRangeException>(() => _ = list[0]);

        list.Add(42);
        AssertItems(list, 42);
    }

    private static MyList<int> MakeList(params int[] values)
    {
        var list = new MyList<int>();
        foreach (var value in values)
            list.Add(value);
        return list;
    }

    private static void AssertItems(MyList<int> list, params int[] expected)
    {
        Assert.Equal(expected.Length, list.Count);

        for (var i = 0; i < expected.Length; i++)
            Assert.Equal(expected[i], list[i]);
    }
}




