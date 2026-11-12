var linkedList = new DoublyLinkedList<string>();

linkedList.InsertAtFront("Bruno");
linkedList.InsertAtFront("Marcelo");
linkedList.InsertAtEnd("Renan");
linkedList.InsertAtFront("Everton");

linkedList.Print();
linkedList.PrintInReverse();
linkedList.PrintCount();    

//Item
public class Node<T> 
{ 
    public T? Data { get; set; }

    //Reference to the next element
    public Node<T>? Next { get; set; }

    //Reference to the previous element
    public Node<T>? Previous { get; set; }

    public override string ToString()
    {
        return $"{Data}";
    }
}

//List
public class DoublyLinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private int _count = 0;

    public void InsertAtFront(T data)
    {
        var node = new Node<T>
        {
            Data = data,
        };

        if(_head == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {           
            node.Next = _head;
            _head.Previous = node;
            _head = node;
        }

        _count++;
    }

    public void InsertAtEnd(T data)
    {
        var node = new Node<T>
        {
            Data = data,
        };

        if (_tail == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            node.Previous = _tail;
            _tail.Next = node;
            _tail= node;
        }

        _count++;
    }

    public void Remove(T data)
    {
        //O(n)
        var element = _head;

        while (element != null)
        {
            if (EqualityComparer<T>.Default.Equals(element.Data, data))
                break;

            element = element.Next;
        }

        if (element == null)
            return;

        var previous = element.Previous;//Previous element of the element to be removed
        var next = element.Next; //Next element of the element to be removed

        if (element.Previous == null) //If element has no previous, it means it is the Head
            _head = next;

        if (element.Next == null) //If element has no next, it means it is the Tail
            _tail = previous;

        previous?.Next = next;
        next?.Previous = previous;

        _count--;

        //Avoid memory leak
        element.Previous = null;
        element.Next = null;
    }

    public void Print()
    {
        var element = _head;

        //O(n)
        while (element != null)
        {
            Console.WriteLine(element.Data);
            element = element.Next;
        }
    }

    public void PrintInReverse()
    {
        var element = _tail;

        //O(n)
        while (element != null)
        {
            Console.WriteLine(element.Data);
            element = element.Previous;
        }
    }

    public void PrintCount()
    {
        Console.WriteLine(_count);
    }
}