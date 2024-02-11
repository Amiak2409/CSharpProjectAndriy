
public class CustomStack<T>
{
    public T[] stack;
    public int index = 0;
    public int size = 0;
    public int count = 0;
    public CustomStack(int size)
    {
        stack = new T[size];
        index = size;
        this.size = size;
    }
    public void Push(T item)
    {
        stack[index - 1] = item;
        index--;
        count++;
    }
    public void Pop()
    {
        int index1 = index;
        index--;
        stack[index1] = default(T);
        count--;
    }
    public T Peek()
    {
        return stack[index];
    }
    public void Clear()
    {
        for (int i = 0;i < stack.Length; i++)
        {
            stack[i] = default(T);
        }
    }
    public bool isEmpty()
    {
        if (count == 0)
        {
            return true;
        }
        return false;
    }
    public int Count() 
    {
        return count;
    }
}