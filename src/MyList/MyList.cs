namespace OOP;

public class MyList<T>
{
    private T[] _items = new T[4];
    private int _count = 0;

    public T this[int index]
    {
        get
        {
            IsExistIndex(index);
            return _items[index];
        }

        set
        {
            IsExistIndex(index);
            _items[index] = value;
        }
    }

    private void IsExistIndex(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is out of MyList range. Count: {this.Count}");
        }
    }

    public int Capacity => _items.Length;

    public int Count => _count;

    public void Add(T item)
    {
        EnsureCapacity(this.Count + 1);
        _items[Count] = item;
        _count += 1;
    }

    public void Insert(int index, T item)
    {
        if(index < 0 || index > this.Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is out of MyList range. Count: {this.Count}");
        }

        EnsureCapacity(this.Count + 1);
        for(int i = Count; i >= index; i--)
        {
            _items[i] = (i == index) ? item : _items[i - 1];
        }
        _count += 1;
    }

    public void RemoveAt(int index)
    {
        IsExistIndex(index);

        for(int i = index; i < this.Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        _count--;
        _items[_count] = default!;
    }

    public int FindIndex(T value)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (object.Equals(_items[i], value))
            {
                return i;
            }
        }
        return -1;
    }

    public bool Contains(T value)
    {
        for(int i = 0; i < this.Count; i++)
        {
            if (object.Equals(_items[i], value))
                return true;
        }
        return false;
    }

    public void Clear()
    {
        T[] newMyList = new T[4];
        _items = newMyList;
        _count = 0;
    }

    private void EnsureCapacity(int value)
    {
        if (Capacity >= value)
            return;

        T[] newItems = new T[(_items.Length) * 2];
        for (int i = 0; i < _items.Length; i++)
        {
            newItems[i] = _items[i];
        }
        _items = newItems;
    }
}