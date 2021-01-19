using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample.Lib
{
    /// <summary>
    /// public: visible from anywhere
    /// </summary>
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

        public bool Delete(int v)   {
            if (_head == null)
                return false;
            else
                return _head.Delete(v);             // start checking from the 1st value => head
        }                                           // 1st value can infer the values after

        public override string ToString()   {
            string ListValueString = "{";
            IntegerNode NodeNow = _head;
            while (NodeNow != null)                 // when it's not the last one
            {
                ListValueString += NodeNow.ToString() + ";";    // conversion & format
                NodeNow = NodeNow.Next;                         // Next: return _next
            }
            ListValueString = ListValueString.Substring(0, ListValueString.Length - 1) + "}";
            return ListValueString;
        }

        public string RemoveDup()    {
            IntegerNode CurrentOne = _head;
            IntegerNode CompareNode = _head;
            int ComparedValue = CompareNode.GetValue;

            if (_head == null)
                return "not cool ... u wrong";
            else
                return _head.RemoveDup(CurrentOne, CompareNode, ComparedValue);             // start checking from the 1st value => head
        }

        // Alternative Merge Method 1:
        public IntegerLinkedList AltMerge_1(IntegerLinkedList ill2)    {
            if (_head == null) {
                if (ill2._head == null && this._head == null)
                    return null;
                return ill2;
            }
            else if (ill2._head == null)     // ill2 isn't the default LinkedList, so must specify
                return this;                // this refers to ill1
            else {
                IntegerLinkedList MergedList = new IntegerLinkedList(_head.GetValue);  // start adding into the list: head of 1st one
                MergedList.Append(ill2._head.GetValue);
                MergedList = _head.AltMerge_1(MergedList, ill2._head);      //  recursion
                return MergedList;
            }
        }
    }


    public class IntegerNode
    {
        int _value;         // internal / private
        IntegerNode _next;

        public IntegerNode(int V)   {                               // CONSTRUCTOR
            _value = V;                 // V is the input variable
            _next = null;               // initialize the next value as a null value
        }

        /// <summary>
        /// Recursion: until pointing at nothing (End of the LinkedList inputting)
        /// </summary>

        public int GetValue
        {
            get { return _value; }
        }

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

        internal IntegerNode Next
        {
            get { return _next; }
        }

        public void Append(int v)   {                               // METHOD
            if (_next == null)
                _next = new IntegerNode(v);
            else
                _next.Append(v);            // _next 变成 List 的 _head
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

        public override string ToString()
        {
            return base.ToString();
        }

        internal string RemoveDup(IntegerNode CurrentOne, IntegerNode CompareNode, int ComparedValue)
        {
            while (CurrentOne.GetValue != ComparedValue)
            {
                while (CurrentOne.GetValue != ComparedValue)
                {
                    CurrentOne = CurrentOne.Next;
                }
                CompareNode = CompareNode.Next;

                if (CurrentOne.GetValue == ComparedValue)
                    CurrentOne.Delete(CurrentOne.GetValue);     // Q: should I use CurrentOne.Delete / _head.Delete?
            }
            return ("Duplicates Removed");
        }

        internal IntegerLinkedList AltMerge_1(IntegerLinkedList mergedList, IntegerNode head2)     // takes in new LinkedList, head of 2 as NODE
        {
            // again, three situations: ill1 shorter, ill2 shorter, same length
            if (_next == null && head2.Next == null)
                return mergedList;
            else if (_next == null)  {
                mergedList.Append(head2.Next._value);            // keep appending value for list 2
                return this.AltMerge_1(mergedList, head2.Next);  // recursion starts
                // shouldn't be _next since _next.Next is nothing / undefined
            }
            else if (head2.Next == null)  {
                mergedList.Append(Next._value);                  // adding values from LList 1 iteratively
                return _next.AltMerge_1(mergedList, head2);      // head2 == 0, so there's recursion
            }
            else  {
                mergedList.Append(Next._value);
                mergedList.Append(head2.Next._value);  // one after the other
                return _next.AltMerge_1(mergedList, head2.Next);
            }
        }
    }
}
