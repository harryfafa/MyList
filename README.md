# MyList

A C# learning project that implements a generic list using a resizable array.

The project focuses on tracking element count separately from array capacity, growing the array when full, and shifting elements during insertion and removal.

## Functional Specification

| Member | Requirement |
|---|---|
| `MyList<T>` | Stores elements of one generic type `T` in an array. |
| `Count` | Returns the number of stored elements. |
| `Capacity` | Returns the backing array length. Initial capacity is 4; capacity doubles when more space is required. |
| Indexer | Gets or sets an element at an index in the range `0 <= index < Count`. Invalid indexes throw `IndexOutOfRangeException`. |
| `Add(item)` | Appends an element and increases `Count` by one. |
| `Insert(index, item)` | Inserts an element at an index in the range `0 <= index <= Count`, shifts later elements right, and increases `Count` by one. |
| `RemoveAt(index)` | Removes the element at an index in the range `0 <= index < Count`, shifts later elements left, decreases `Count` by one, and clears the freed slot. |
| `FindIndex(value)` | Returns the index of the first equal element, or `-1` if no element matches. |
| `Contains(value)` | Returns `true` if an equal element exists; otherwise returns `false`. |
| `Clear()` | Removes all elements, sets `Count` to 0, and resets capacity to 4. |

## Usage Specification

### UC-01: Insert an element and read the list

| Field | Specification |
|---|---|
| Preconditions | A new `MyList<int>` is empty. |
| Operations | Append 10; append 20; insert 15 at index 1. |
| Expected state | Elements are `[10, 15, 20]`; `Count` is 3; `Capacity` is 4. |

~~~csharp
using OOP;

var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Insert(1, 15);

// Expected: 15
Console.WriteLine(numbers[1]);

// Expected: 3
Console.WriteLine(numbers.Count);

// Expected: 4
Console.WriteLine(numbers.Capacity);
~~~

## Run the tests

~~~bash
dotnet test MyList.slnx
~~~

## Implementation Notes

The list starts with a capacity of 4. When it needs more room, it doubles the backing array and copies the existing elements.

| Operation | Time |
|---|---:|
| Indexer get/set | O(1) |
| Add | Amortized O(1); O(n) when capacity grows |
| Insert / RemoveAt | O(n) |
| FindIndex / Contains | O(n) |

This is an educational implementation focused on array-backed collection behavior.
