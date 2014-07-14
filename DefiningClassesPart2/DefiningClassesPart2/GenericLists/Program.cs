using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericLists
{
    public class GenericList<T> where T : IComparable
    {
        private T[] elements;
        private int counter = 0;
 
        public GenericList(int capacity)
        {
            this.elements = new T[capacity];
        }
 
        public void Add(T element)
        {
            if (counter >= elements.Length)
            {
                GrowsCapacity();
            }
            elements[counter] = element;
            counter++;
        }
 
        private void GrowsCapacity()
        {
            T[] tempArray = new T[elements.Length * 2];
            Array.Copy(elements, 0, tempArray, 0, elements.Length);
            elements = tempArray;
        }
 
        public void Delete(T point)
        {
            int index = Array.IndexOf(elements,point);
            T[] tempArray = (T[])elements.Clone();
            elements = new T[tempArray.Length];
            Array.Copy(tempArray, index + 1, elements, index, elements.Length - index - 1);
            counter--;      
        }
 
        public int FindByValue(T element)
        {
            int myIndex = Array.IndexOf(elements, element);
            return myIndex;
        }
 
        public void InsertElement(int position, T element)
        {
            if (counter == elements.Length)
            {
                GrowsCapacity();
            }
            Array.Copy(elements, position, elements, position + 1, elements.Length - position-1);
            elements[position] = element;
            counter++;
        }
 
        public void Clear()
        {
            int length;
            length = elements.Length;
            elements = new T[length];
        }
 
        public override string ToString()
        {
            string concatenated = string.Join(",", elements.Select(x => x.ToString()).ToArray());
            return concatenated;
        }
 
        public T this[int index]
        {
            get
            {
                if (index >= counter)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
                }
                T result = elements[index];            
                return result;
            }
        }

        public T Min<T>() where T : IComparable<T>
        {
            dynamic min = elements[0];
            for (int i = 1; i < this.elements.Length; i++)
            {
                if (this.elements[i].CompareTo(min) >= 0)
                {
                    min = this.elements[i];
                }
            }
            return min;
        }

        public T Max<T>() where T : IComparable<T>
        {
            dynamic max = elements[0];
            for (int i = 1; i < this.elements.Length; i++)
            {
                if (this.elements[i].CompareTo(max) <= 0)
                {
                    max = this.elements[i];
                }
            }
            return max;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> listsOfThings = new GenericList<string>(10);
            listsOfThings.Add("hey");
            listsOfThings.Add("pesho");
            listsOfThings.Add("kiro");
            listsOfThings.Add("academy");
            listsOfThings.InsertElement(5, "bla");
        }
    }
}
