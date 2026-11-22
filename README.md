# MyList

A C# learning project that implements a generic list using a resizable array.

The project focuses on tracking element count separately from array capacity, growing the array when full, and shifting elements during insertion and removal.

## Functional Specification

| Member | Requirement |
|---|---|
| [Indexer](#indexer) | Gets or sets an element at an index in the range 0 <= index < Count. Invalid indexes throw IndexOutOfRangeException. |
| [**MyList&lt;T&gt;**](#generic-type) | Stores elements of one generic type T in an array. |
| [Count](#count) | Returns the number of stored elements. |
| [Capacity](#capacity) | Returns the backing array length. Initial capacity is 4; capacity doubles when more space is required. |
| [Contains(value)](#contains) | Returns true if an equal element exists; otherwise returns false. |
| [Add(item)](#add) | Appends an element and increases Count by one. |
| [Insert(index, item)](#insert) | Inserts an element at an index in the range 0 <= index <= Count, shifts later elements right, and increases Count by one. |
| [RemoveAt(index)](#removeat) | Removes the element at an index in the range 0 <= index < Count, shifts later elements left, decreases Count by one, and clears the freed slot. |
| [FindIndex(value)](#findindex) | Returns the index of the first equal element, or -1 if no element matches. |
| [Clear()](#clear) | Removes all elements, sets Count to 0, and resets capacity to 4. |

## Usage Specification

The examples below follow the same order as the Functional Specification. Each snippet assumes the OOP namespace is imported.

### Indexer

| Field | Specification |
|---|---|
| Preconditions | The list contains 10 and 20, in that order. |
| Operation | Read index 0, then set index 1 to 25. |
| Expected result | The read value is 10; the list becomes [10, 25]. |

~~~csharp
var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);

var first = numbers[0]; // 10
numbers[1] = 25;
~~~

### Generic Type

| Field | Specification |
|---|---|
| Preconditions | A generic element type is selected. |
| Operation | Create a list of that type and add a value. |
| Expected result | The list stores and returns a value of the selected type. |

~~~csharp
var names = new MyList<string>();
names.Add("Ada");

var firstName = names[0]; // "Ada"
~~~

### Count

| Field | Specification |
|---|---|
| Preconditions | The list is empty. |
| Operation | Add three elements. |
| Expected result | Count is 3. |

~~~csharp
var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);

var count = numbers.Count; // 3
~~~

### Capacity

| Field | Specification |
|---|---|
| Preconditions | A new list has its initial capacity. |
| Operation | Add five elements. |
| Expected result | Capacity grows from 4 to 8. |

~~~csharp
var numbers = new MyList<int>();

for (var i = 0; i < 5; i++)
{
    numbers.Add(i);
}

var capacity = numbers.Capacity; // 8
~~~

### Contains

| Field | Specification |
|---|---|
| Preconditions | The list contains 10 and 20. |
| Operation | Check for 20 and 99. |
| Expected result | The check for 20 returns true; the check for 99 returns false. |

~~~csharp
var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);

var contains20 = numbers.Contains(20); // true
var contains99 = numbers.Contains(99); // false
~~~

### Add

| Field | Specification |
|---|---|
| Preconditions | The list is empty. |
| Operation | Append 10, then append 20. |
| Expected result | Elements are [10, 20]; Count is 2. |

~~~csharp
var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);
~~~

### Insert

| Field | Specification |
|---|---|
| Preconditions | The list contains [10, 20]. |
| Operation | Insert 15 at index 1. |
| Expected result | Elements are [10, 15, 20]; Count is 3. |

~~~csharp
var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Insert(1, 15);
~~~

### RemoveAt

| Field | Specification |
|---|---|
| Preconditions | The list contains [10, 20, 30]. |
| Operation | Remove the element at index 1. |
| Expected result | Elements are [10, 30]; Count is 2. |

~~~csharp
var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
numbers.RemoveAt(1);
~~~

### FindIndex

| Field | Specification |
|---|---|
| Preconditions | The list contains [10, 20, 30, 20]. |
| Operation | Search for 20 and then for 99. |
| Expected result | The first search returns index 1; the second returns -1. |

~~~csharp
var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
numbers.Add(20);

var firstMatch = numbers.FindIndex(20); // 1
var missingMatch = numbers.FindIndex(99); // -1
~~~

### Clear

| Field | Specification |
|---|---|
| Preconditions | The list contains one or more elements. |
| Operation | Clear the list. |
| Expected result | Count is 0 and Capacity is reset to 4. |

~~~csharp
var numbers = new MyList<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Clear();
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
