using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSizedQueue<T> : Queue<T>
{
    private readonly object obj = new object();

    public int Size { get; private set; }

    public FixedSizedQueue(int size)
    {
        Size = size;
    }

    public new void Enqueue(T obj)
    {
        base.Enqueue(obj);
        lock (this.obj)
        {
            while (base.Count > Size)
            {
                base.Dequeue();
            }
        }
    }
}
