CustomQueue<int> queue = new CustomQueue<int>(3);
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());
class CustomQueue<T>
{
    private T[] queue;
    private int index = 0;
    private int rindex = 0;
    private int count = 0;
    private int size = 0;

    public CustomQueue(int size)
    {
        this.size = size;
        queue = new T[size];
    }

    public void Enqueue(T item)
    {
        queue[index] = item;
        index++;
    }
    public T Dequeue()
    {
        T item2 = queue[rindex];
        queue[rindex] = default(T);
        rindex++;
        return item2;
    }
    public T Peek()
    {
        T item2 = queue[index];
        rindex++;
        return queue[rindex];
    }
    public bool IsEmpty()
    {
        return count == 0;
    }
    public int Count()
    {
        return count;
    }
    public void Clear()
    {
        queue = new T[size];
    }
}

