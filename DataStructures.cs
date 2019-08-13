public namespace DataStructures{
  class Node
    {
        public int value;
        public Node left;
        public Node right;
    }

    class Tree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v < root.value)
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }

            return root;
        }

        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }

            traverse(root.left);
            traverse(root.right);
        }
    public bool IsExists(Node rootNode, int value)
            {
                return FindByValue(rootNode, value) != null;
            }

            public bool IsLeaf()
            {
                return (this.Left == null) && (this.Right == null);
            }

            public Node FindByValue(Node rootNode, int value)
            {
                if (rootNode == null) return null;
                if (rootNode.Value == value) return rootNode;

                if (value < rootNode.Value)
                {
                    return FindByValue(rootNode.Left, value);
                }

                if (value > rootNode.Value)
                {
                    return FindByValue(rootNode.Right, value);
                }

                return null;
            }

            public string ToString(Node rootNode)
            {
                if (rootNode == null) return string.Empty;
               
                return ToString(rootNode.Left) + " " + rootNode.Value + ToString(rootNode.Right);
            }
    public void PreOrderTraverse(BSTNode<T> node)
            {
                if (node != null)
                {
                    Console.WriteLine(node.Data);
                    PreOrderTraverse(node.left);
                    PreOrderTraverse(node.right);
                }
            }

            public void PostOrderTraverse(BSTNode<T> node)
            {
                if (node != null)
                {
                    PreOrderTraverse(node.left);
                    PreOrderTraverse(node.right);
                    Console.WriteLine(node.Data);
                }
            }

            public void InOrderTraverse(BSTNode<T> node)
            {
                if (node != null)
                {
                    PreOrderTraverse(node.left);
                    Console.WriteLine(node.Data);
                    PreOrderTraverse(node.right);
                }
            }
        }
    public int count_elements(node_in_sbt root)
    {
        int count = 1;
        if (root != null)
        {
            if (root.left != null) count += count_elements(root.left);
            if (root.right != null) count += count_elements(root.right);
        }
        return count;
    }
    public int tree_height_or_depth(node_in_sbt root) 
    {
        int height = 1;
        int left = 1;
        int right = 1;
        if (root != null) 
        {
            if (root.left != null) left += tree_height_or_depth(root.left);
            if (root.right != null) right += tree_height_or_depth(root.right);
        }
        height = Math.Max(left, right);
        return height;
    }
public node_in_sbt GetSuccessor(node_in_sbt delNode)
    {
        node_in_sbt successorParent = delNode;
        node_in_sbt successor = delNode;
        node_in_sbt current = delNode.right;  

        while (current != null)
        {
            successorParent = current;
            successor = current;
            current = current.left;    
        }
        if (successor != delNode.right )  
        {
            successorParent.left = successor.right;  
            successor.right = delNode.right;   
        }
        return successor;
    }
    public bool delete_node(int value_to_delete)
    {
        node_in_sbt current = root_of_the_tree;
        node_in_sbt parent = root_of_the_tree;
        bool isLeftChild = true;
        while (current.data_value != value_to_delete) 
        {
            parent = current;
            if (value_to_delete < current.data_value) 
            {
                isLeftChild = true;
                current = current.left; 
            }
            else
            {
                isLeftChild = false;
                current = current.right; 
            }
            if (current == null)
            {
                return false;
            }
        }
        if ( current.left == null && current.right == null  )  
        {
            if ( current == root_of_the_tree  ) 
                root_of_the_tree = null;
            else if (isLeftChild)
                parent.left = null; 
            else
                parent.right = null;
        }
        else if ( current.right == null )  
        {
            if ( current == root_of_the_tree )  
            {
                root_of_the_tree = current.left; 
            }
            else if (isLeftChild)
            {
                parent.left = current.left;   
            }
            else
            {
                parent.right = current.right;  
            }
        }
        else if (current.left == null)   
        {
            if (current == root_of_the_tree) 
            {
                root_of_the_tree = current.right;  
            }
            else if (isLeftChild)
            {
                parent.left = parent.right;  
            }
            else
            {
                parent.right = current.right;  
            }
        }
        else
        {
            node_in_sbt successor = GetSuccessor(current);
            if (current == root_of_the_tree) 
            {
                root_of_the_tree = successor; 
            }
            else if (isLeftChild)
            {
                parent.left = successor;  
            }
            else
            {
                parent.right = successor;  
            }
            successor.left = current.left; 
        }
        return true;
    }
    }
  public class Heap<T> where T : IComparable
{
    private enum HeapType
    {
        Min,
        Max
    };

    private readonly HeapType _heapType;
    T[] _heap;
    int _count;

    /// <summary>
    /// Create a new heap.
    /// </summary>
    /// <param name="minSize">The minimum number of elements the heap is expected to hold.</param>
    /// <param name="isMaxHeap">If "true", this is a Max Heap, where the largest values rise to the top. Otherwise, this is a Min Heap.</param>
    public Heap(int minSize, bool isMaxHeap = false)
    {
        _heapType = isMaxHeap ? HeapType.Max : HeapType.Min;
        _heap = new T[((int)Math.Pow(2, Math.Ceiling(Math.Log(minSize, 2))))];
    }

    /// <summary>
    /// Current size of the Heap.
    /// </summary>
    public int Count { get { return _count; } }

    /// <summary>
    /// Test to see if the Heap is empty.
    /// </summary>
    public bool IsEmpty { get { return _count == 0; } }

    /// <summary>
    /// Add a new value to the Heap.
    /// </summary>
    /// <param name="val"></param>
    public void Insert(T val)
    {
        if (_count == _heap.Length)
        {
            DoubleHeap();
        }
        _heap[_count] = val;
        ShiftUp(_count);
        _count++;
    }

    /// <summary>
    /// View the value currently at the top of the Heap.
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        if (_heap.Length == 0) throw new ArgumentOutOfRangeException("No values in heap");
        return _heap[0];
    }

    /// <summary>
    /// Remove the value currently at the top of the Heap and return it.
    /// </summary>
    /// <returns></returns>
    public T Remove()
    {
        T output = Peek();
        _count--;
        _heap[0] = _heap[_count];
        ShiftDown(0);
        return output;
    }

    /// <summary>
    /// Move an element up the Heap.
    /// </summary>
    /// <param name="heapIndex"></param>
    private void ShiftUp(int heapIndex)
    {
        if (heapIndex == 0) return;
        int parentIndex = (heapIndex - 1) / 2;
        bool shouldShift = DoCompare(parentIndex, heapIndex) > 0;
        if (!shouldShift) return;
        Swap(parentIndex, heapIndex);
        ShiftUp(parentIndex);
    }

    /// <summary>
    /// Move an element down the Heap.
    /// </summary>
    /// <param name="heapIndex"></param>
    private void ShiftDown(int heapIndex)
    {
        int child1 = heapIndex * 2 + 1;
        if (child1 >= _count) return;
        int child2 = child1 + 1;

        int preferredChildIndex = (child2 >= _count || DoCompare(child1, child2) <= 0) ? child1 : child2;
        if (DoCompare(preferredChildIndex, heapIndex) > 0) return;
        Swap(heapIndex, preferredChildIndex);
        ShiftDown(preferredChildIndex);
    }

    /// <summary>
    /// Swap two items in the underlying array.
    /// </summary>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    private void Swap(int index1, int index2)
    {
        T temp = _heap[index1];
        _heap[index1] = _heap[index2];
        _heap[index2] = temp;
    }

    /// <summary>
    /// Perform a comparison between two elements of the heap.
    /// This method encapsulates the min/max behavior of the heap so the rest of the class can remain blissfully ignorant.
    /// </summary>
    /// <param name="initialIndex"></param>
    /// <param name="contenderIndex"></param>
    /// <returns></returns>
    private int DoCompare(int initialIndex, int contenderIndex)
    {
        T initial = _heap[initialIndex];
        T contender = _heap[contenderIndex];
        int value = initial.CompareTo(contender);
        if (_heapType == HeapType.Max) value = -value;
        return value;
    }

    /// <summary>
    /// Increase the size of the underlying storage.
    /// </summary>
    private void DoubleHeap()
    {
        var copy = new T[_heap.Length * 2];
        for (int i = 0; i < _heap.Length; i++)
        {
            copy[i] = _heap[i];
        }
        _heap = copy;
    }
}
}
public class ChainingHashTable<K, V>
    {
        private const double _alpha = 3.0;

        private int _size = 3;

        private List<KeyValuePair<K, V>>[] _table;
        private int _count = 0;

        public ChainingHashTable()
        {
            _table = new List<KeyValuePair<K, V>>[_size];
        }

        public int Count { get { return _count; } }

        private int HashFunction(K key)
        {
            return Math.Abs(key.GetHashCode()) % _size;
        }

        private bool Saturated { get { return ((double)_count / (double)_size) > _alpha; } }

        private void Rehash()
        {
            _size = (_size * 2).NextPrime();

            List<KeyValuePair<K, V>>[] newTable = new List<KeyValuePair<K, V>>[_size];

            for (int i = 0; i < _table.Length; i++)
            {
                List<KeyValuePair<K, V>> row = _table[i];

                if (row != null)
                {
                    foreach (KeyValuePair<K, V> kvp in row)
                    {
                        int location = HashFunction(kvp.Key);

                        if (newTable[location] == null)
                        {
                            newTable[location] = new List<KeyValuePair<K, V>>();
                        }

                        newTable[location].Add(kvp);
                    }
                }
            }

            _table = newTable;
        }

        public V this[K key]
        {
            get
            {
                return Get(key);
            }

            set
            {
                Set(key, value);
            }
        }

        public void Set(K key, V value)
        {
            Remove(key);
            _count++;

            if (Saturated)
            {
                Rehash();
            }

            int location = HashFunction(key);

            if (_table[location] == null)
            {
                _table[location] = new List<KeyValuePair<K, V>>();
            }

            _table[location].Add(new KeyValuePair<K, V>(key, value));
        }

        public V Get(K key)
        {
            int location = HashFunction(key);
            List<KeyValuePair<K, V>> row = _table[location];

            if (row != null)
            {
                foreach (KeyValuePair<K, V> kvp in row)
                {
                    if (kvp.Key.Equals(key))
                    {
                        return kvp.Value;
                    }
                }
            }

            return default(V);
        }

        public bool Remove(K key)
        {
            int location = HashFunction(key);
            List<KeyValuePair<K, V>> row = _table[location];

            if (row != null)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    KeyValuePair<K, V> kvp = row[i];
                    if (kvp.Key.Equals(key))
                    {
                        row.RemoveAt(i);
                        _count--;
                        return true;
                    }
                }
            }

            return false;
        }

        public void Print()
        {
            Console.WriteLine("================================");
            Console.WriteLine(String.Format("Count: {0}, Size: {1}, Alpha: {2}", Count, _size, _alpha));
            for (int i = 0; i < _size; i++)
            {
                List<KeyValuePair<K, V>> row = _table[i];
                Console.Write(String.Format("{0}: ", i));

                if (row != null)
                {
                    Console.Write(String.Join(", ", row.Select(kvp => String.Format("<{0}: {1}>", kvp.Key.ToString(), kvp.Value.ToString()))));
                }

                Console.WriteLine();
            }
            Console.WriteLine("================================\n");
        }
    }
}


}
