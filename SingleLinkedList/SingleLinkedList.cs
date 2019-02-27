using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{

    public class SingleLinkedList<T> : IList<T>
    {
        private class Node<Type>
        {
            public Type Data { get; set; }
            public Node<Type> Next { get; set; }
        }

        Node<T> head;
        Node<T> tail; 
        int count;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                Node<T> node = GetNode(index);
                return node.Data;
            }
            set
            {
                Node<T> node = GetNode(index);
                node.Data = value;
            }
        }

        //получение узла по индексу
        private Node<T> GetNode(int index)
        {
            Node<T> node = head;
            while (index > 0 && node.Next != null)
            {
                node = node.Next;
                index--;
            }

            if (index == 0)
            {
                return node;
            }

            throw new ArgumentOutOfRangeException();
        }

        //добавление
        public void Add(T data)
        {
            Node<T> node = new Node<T>()
            {
                Data = data
            };

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }

            tail = node;

            count++;
        }

        //вставка по индексу
        public void Insert(int index, T data)
        {
            Node<T> node = GetNode(index);

            Node<T> newNode = new Node<T>()
            {
                Data = data,
                Next = node.Next
            };

            node.Next = newNode;
        }

        //удаление
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        //удаление по индексу
        public void RemoveAt(int index)
        {
            
            if (index > 0)
            {
                Node<T> node = GetNode(index - 1);
                Node<T> node2 = GetNode(index);

                if(node2.Next != null)
                {
                    node.Next = node2.Next;
                }
                else
                {
                    node.Next = null;
                }
            }
            else
            {
                Node<T> node = head.Next;
                head = node;
            }
            
        }

        //количество
        public int Count => count;

        //проверка на пустоту
        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }

        //очистка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        //содержание элемента
        public bool Contains(T data)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //индекс первого вхождения элемента
        public int IndexOf(T data)
        {
            var index = 0;
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1;
        }

        //копирование из массива
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length < Count + arrayIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node<T> node = head;
            var i = 0;

            while (node != null)
            {
                array[arrayIndex + i] = node.Data;
                node = node.Next;
                i++;
            }
        }

        //добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>()
            {
                Data = data,
                Next = head
            };

            head = node;

            if (count == 0)
            {
                tail = head;
            }

            count++;
        }
        //реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
