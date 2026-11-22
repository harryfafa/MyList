# MyList

A C# learning project that implements a generic list using a resizable array.

The project focuses on how a list can track its element count separately from its array capacity, grow when full, and shift elements during insertion and removal.

## Features

- Generic storage with **MyList<T>**
- **Count** and **Capacity**
- Indexer with index validation
- Add and insert elements
- Remove an element by index
- Search with **FindIndex** and **Contains**
- Clear and reuse the list
- xUnit tests for normal behavior, capacity growth, and invalid indexes

## Example

~~~csharp
using OOP;

var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Insert(1, 15);

Console.WriteLine(numbers[1]);  // 15
Console.WriteLine(numbers.Count);     // 3
Console.WriteLine(numbers.Capacity);  // 4
~~~

## Run the tests

~~~bash
dotnet test MyList.slnx
~~~

## Implementation notes

The list starts with a capacity of 4. When it needs more room, it doubles the backing array and copies the existing elements.

| Operation | Time |
|---|---:|
| Indexer get/set | O(1) |
| Add | Amortized O(1); O(n) when capacity grows |
| Insert / RemoveAt | O(n) |
| FindIndex / Contains | O(n) |

This is an educational implementation and a focused exercise in array-backed collection behavior.
