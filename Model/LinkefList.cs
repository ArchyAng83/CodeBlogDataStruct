using System;
using System.Collections;

namespace CodeBlogDataStruct.Model
{
    /// <summary>
    /// Односвязный список.
    /// </summary>
    
    public class LinkefList<T> : IEnumerable
    {
        /// <summary>
        /// Первый элемент списка.
        /// </summary>
        public Item<T> Head { get; private set; }

        /// <summary>
        /// Последний элемент списка.
        /// </summary>
        public Item<T> Tail { get; private set; }

        /// <summary>
        /// Кол-во элементов в списке
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Пустой список.
        /// </summary>
        public LinkefList()
        {
            Clear();
        }

        /// <summary>
        /// Создать список с начальным элемнетом.
        /// </summary>       
        public LinkefList(T data)
        {            
            SetHeadAndTail(data);
        }

        /// <summary>
        /// Добавить элемент в список.
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if(Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
            
        }

        /// <summary>
        /// Удалить первое вхождение данных в список.
        /// </summary>
        /// <param name="data"></param>
        public void Delete(T data)
        {
            if(Head != null)
            {
                if(Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previous = Head;
                while(current.Next != null)
                {
                    if(current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        /// <summary>
        /// Добавить данные в начало списка.
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }

        /// <summary>
        /// Вставить данные после искомого значения.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {                
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data);
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                /* Надо решить для себя, если список пустой,
                 * либо ничего не вставлять, либо вставить данные */
                SetHeadAndTail(target);
                Add(data);
            }

        }

        /// <summary>
        /// Очистка списка.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);

            Head = item;
            Tail = item;
            Count = 1;
        }

        /// <summary>
        /// Получить перечисления всех элементов списка.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            return "Linked list" + Count + " элементов";
        }
    }
}
