using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample.Lib
{
    public class IntegerLinkedList
    {
        private IntegerNode _head;      // IntegerNode is a variable type 

        public IntegerLinkedList()
        {
            _head = null;           // 空的List，第一个加入空List，为第一个值
        }

        public IntegerLinkedList(int v)    {
            _head = new IntegerNode(v);
           
            /* this._v = v;     
             * // "this."  refers    to the current instantiation of this class
                             // if _v and v is different, so "this." is optional    */
        }

        public int Count {
            get
            {
                // method: constructor in Class Integernode

                if (_head == null)
                    return 0;
                else
                    return _head.Count;     // see property in Integernode Class
            } 
        }
        public int Sum {
            get {
                if (_head == null)
                    return 0;               // nothing is before
                else
                    return _head.Sum;       // see property in Integernode Class
            } 
        }

        public void Append(int v)   {

            if (_head == null)
                _head = new IntegerNode(v);
            else
                _head.Append(v);                    // jump to the property in IntegerNode
        }

        public void Remove(int v)   {

            if (_head == null)
                throw new IndexOutOfRangeException();
            else
                _head.Remove(v);                    // start checking from the 1st value => head
        }                                           // 1st value can infer the values after

        public bool Delete(int v)
        {
            if (_head == null)
                return false;
            else
                return _head.Delete(v);             // start checking from the 1st value => head
        }                                           // 1st value can infer the values after

        public override string ToString()
        {
            return base.ToString(); 
        }
    }

    public class IntegerNode
    {
        int _value;
        IntegerNode _next;

        public IntegerNode(int V)   {                               // CONSTRUCTOR
            _value = V;                 // V is the input variable
            _next = null;                // initialize the next value as a null value
        }

        /// <summary>
        /// Recursion: until pointing at nothing (End of the LinkedList inputting)
        /// </summary>

        public int Count    {                                       // PROPERTY: get; set
            get {
                if (_next == null)          // base case
                    return 0;
                else
                    return _next.Count;     // recursion
            }
        }

        public int Sum
        {
            get {
                if (_next == null)                  // base case
                    return _value;
                else
                    return _value + _next.Sum;      // recursion
            }
        }

        public void Append(int v)   {                               // METHOD
            if (_next == null)
                _next = new IntegerNode(v);
            else
                _next.Append(v);
        }

        public void Remove(int v)     {
            
            // 1. Iteration
            IntegerNode NodeNow = this;  // .this is _head since this function is used on _head
            while (NodeNow != null)      // when it didn't run through all the members
            {
                if (_value == v)
                    NodeNow._next = NodeNow._next._next;
                else
                    NodeNow = NodeNow._next;    // check next value
            }
        }

        public bool Delete (int v)
        {
            // 2. Recursion
            if (_next == null)
                return false;
            else    {
                if (_next._value == v)  {
                    _next = _next._next;    // jumped over
                    return true; }
                else
                    return _next.Delete(v); // recursion: wraps in, do the above again for the next var
            }
        }

        // Override

        public override string ToString()   {
            string StringValue = string.Empty;


        }


    }
}
