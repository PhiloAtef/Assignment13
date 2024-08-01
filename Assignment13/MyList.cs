using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment13
{
    internal class MyList<T> : List<T>
    {
        public new bool Exists(Predicate<T> pred)
        {
            foreach (var item in this)
            {
                if (pred(item)) return true;
            }
            return false;
        }

        public new T Find(Predicate<T> pred)
        {
            foreach (var item in this)
            {
                if (pred(item)) return item;
            }
            return default;
        }

        public new MyList<T> FindAll(Predicate<T> pred)
        {
            MyList<T> list = new MyList<T>();
            foreach (var item in this)
            {
                if (pred(item)) list.Add(item);
            }
            return list;
        }

        public new int FindIndex(Predicate<T> pred)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (pred(this[i])) return i;
            }

            return -1;
        }

        public new T FindLast(Predicate<T> pred)
        {
            for (int i = this.Count - 1; i >= 0; i--)
                if (pred(this[i])) return this[i];

            return default;
        }

        public new int FindLastIndex(Predicate<T> pred)
        {
            for (int i = this.Count - 1; i >= 0; i--)
                if (pred(this[i])) return i;

            return -1;
        }

        public new void ForEach(Action<T> action)
        {
            foreach (var item in this) action(item);
        }

        public new bool TrueForAll(Predicate<T> pred)
        {
            foreach (var item in this)
            {
                if (!pred(item)) return false;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "{";
            foreach (var item in this)
                s += item + ", ";
            s += "}";
            return s;
        }
    }
}