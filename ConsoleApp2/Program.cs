using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp5
{
    class AStack
    {
        private int[] arr;

        public AStack()
        {
            this.arr = null;
        }

        public bool IsEmpty() // O(1)
        {
            return arr == null;
        }

        public void Push(int x) //O(n)
        {
            if (arr == null)
            {
                arr = new int[1];
                arr[0] = x;
            }
            else
            {
                int[] temp = arr;
                arr = new int[temp.Length + 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    arr[i] = temp[i];
                }
                arr[arr.Length - 1] = x;
            }
        }

        public int Pop() //O(n)
        {
            if (arr == null)
                return -1;
            int[] temp = arr;
            arr = new int[temp.Length - 1];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = temp[i];
            }
            return temp[temp.Length - 1];
        }

        public int Top() //O(1)
        {
            if (arr == null)
                return -1;
            return arr[arr.Length - 1];
        }

        public override string ToString() //O(n)
        {
            string s = "";
            for (int i = 0; i < arr.Length; i++)
            {
                s += arr[i];
                s += " ";
            }
            return s;
        }
    }

    class IntStack
    {

        private IntNode node;

        public IntStack()
        {
            this.node = null;
        }

        public bool IsEmpty() //O(1)
        {
            return node == null;
        }

        public void Push(int x)//O(1)
        {
            node = new IntNode(x, node);
        }

        public int Pop()// O(1)
        {
            int first = node.GetInfo();
            node = node.GetNext();
            return first;
        }

        public int Top() //O(1)
        {
            return node.GetInfo();
        }

        public override string ToString() //O(n)
        {
            IntNode temp = node;
            string s = "";
            while (temp != null)
            {
                s += temp.GetInfo();
                s += " ";
                temp = temp.GetNext();
            }
            return s;
        }
    }

    class IntNode
    {
        private int info;
        private IntNode next;


        public IntNode(int info)
        {
            this.info = info;
            this.next = null;
        }


        public IntNode(int info, IntNode next)
        {
            this.info = info;
            this.next = next;
        }


        public int GetInfo()
        {
            return info;
        }


        public IntNode GetNext()
        {
            return next;
        }


        public void SetInfo(int info)
        {
            this.info = info;
        }


        public void SetNext(IntNode next)
        {
            this.next = next;
        }


        public override string ToString()
        {
            string s = "";
            s += this.info;
            return s;
        }
    }

    class Queue<T> // FIFO
    {
        private Node<T> head;
        private Node<T> tail;

        public Queue(Queue<T> que)
        {
            Queue<T> temp = que;
            if (temp.IsEmpty())
                head = tail = null;
            else
                head = tail = new Node<T>(temp.Remove());
            while (!temp.IsEmpty())
            {
                tail = new Node<T>(temp.Remove(), tail);
            }
        }
        public Queue()
        {
            head = tail = null;
        }

        public void Insert(T item)
        {
            if (head == null)
                head = tail = new Node<T>(item);
            else
            {
                tail = new Node<T>(item, tail);
            }
        }

        public Queue<T> Copy(Queue<T> que)
        {
            Queue<T> tempque1 = new Queue<T>();
            Queue<T> tempque2 = new Queue<T>();
            while (!que.IsEmpty())
            {
                tempque1.Insert(que.Head());
                tempque2.Insert(que.Remove());
            }
            while (!tempque1.IsEmpty())
            {
                que.Insert(tempque1.Remove());
            }
            return tempque2;
        }

        public T Remove() // tail = 1->2->head = 3
        {
            T temp;
            if (tail == head)
            {
                temp = head.GetInfo();
                head = tail = null;
                return temp;
            }

            Node<T> temp_tail = tail;
            while (temp_tail.GetNext() != head)
                temp_tail = temp_tail.GetNext();

            temp = head.GetInfo();
            head = temp_tail;
            head.SetNext(null);
            return temp;
        }

        public Queue<T> Reverse(Queue<T> queue)
        {
            if (queue.IsEmpty())
            {
                return queue;
            }
            T x = queue.Remove();
            queue = Reverse(queue);
            queue.Insert(x);
            return queue;
        }

        public bool IsEmpty()
        {
            return tail == null;
        }
        public T Head()
        {
            return head.GetInfo();
        }



        public override string ToString()
        {
            string s = "";
            string res = "[";
            Node<T> temp = tail;
            while (temp != null)
            {
                s += temp.GetInfo() + " ";
                temp = temp.GetNext();
            }
            for (int i = s.Length - 1; i >= 0; i--)
                res += s[i];
            return res + ']';
        }
    }
    class StackNode<T> // LIFO
    {

        private Node<T> node;

        public StackNode()
        {
            this.node = null;
        }

        public bool IsEmpty() //O(1)
        {
            return node == null;
        }

        public void Push(T x)//O(1)
        {
            node = new Node<T>(x, node);
        }

        public T Pop()// O(1)
        {
            T first = node.GetInfo();
            node = node.GetNext();
            return first;
        }

        public T Top() //O(1)
        {
            return node.GetInfo();
        }

        public StackNode<T> Reverse(StackNode<T> number) //O(1)
        {
            StackNode<T> stack = new StackNode<T>();

            while (!number.IsEmpty())
                stack.Push(number.Pop());
            return stack;

        }

        public override string ToString() //O(n)
        {
            Node<T> temp = node;
            string s = "[";
            while (temp != null)
            {
                s += temp.GetInfo();
                s += " ";
                temp = temp.GetNext();
            }
            s += "]";
            return s;
        }
    }

    class Node<T>
    {
        private T info;
        private Node<T> next;


        public Node(T info)
        {
            this.info = info;
            this.next = null;
        }


        public Node(T info, Node<T> next)
        {
            this.info = info;
            this.next = next;
        }


        public T GetInfo()
        {
            return info;
        }


        public Node<T> GetNext()
        {
            return next;
        }


        public void SetInfo(T info)
        {
            this.info = info;
        }


        public void SetNext(Node<T> next)
        {
            this.next = next;
        }


        public override string ToString()
        {
            string s = "[";
            s += this.info;
            Node<T> temp = next;
            while (temp != null)
            {
                s += " - " + temp.GetInfo();
                temp = temp.GetNext();
            }
            return s + "]";
        }
    }

    class MySet
    {
        private Node<int> set;

        public MySet()
        {
            set = null;
        }

        private void Insert(int num, Node<int> node)
        {
            if (node == null)
            {
                set = new Node<int>(num, set);
                return;
            }
            if (node.GetInfo() == num)
            {
                return;
            }

            Insert(num, node.GetNext());
        }
        public void InsertTo(int num)
        {
            Insert(num, set);
        }
        private bool Belong(int num, Node<int> node)
        {
            if (node == null)
            {
                return false;
            }
            if (node.GetInfo() == num)
            {
                return true;
            }
            return Belong(num, node.GetNext());
        }
        public bool BelongTo(int num)
        {
            return Belong(num, set);
        }

        private Node<int> InsertOrdered(int num)
        {
            if (set == null)
                return new Node<int>(num);
            if (num > set.GetInfo())
                return new Node<int>(num, set);

            Node<int> pointer = set;
            while (pointer != null)
            {
                if (pointer.GetNext() == null || num > pointer.GetNext().GetInfo())
                {
                    Node<int> temp = new Node<int>(num);
                    temp.SetNext(pointer.GetNext());
                    pointer.SetNext(temp);
                    return set;
                }
                pointer = pointer.GetNext();
            }
            return set;
        }
        public void InsertOrderedToBS(int num)
        {
            set = InsertOrdered(num);
        }
        private bool IsOrdered(Node<int> node)
        {
            if (node == null || node.GetNext() == null)
            {
                return true;
            }
            while (node.GetNext() != null)
            {
                if (node.GetInfo() < node.GetNext().GetInfo())
                {
                    return false;
                }
                node = node.GetNext();
            }
            return true;
        }
        public bool IsOrderedToBS()
        {
            return IsOrdered(set);
        }
        public bool IsSame(MySet otherSet)
        {
            while (set != null)
            {
                if (!otherSet.BelongTo(set.GetInfo()))
                    return false;
                set = set.GetNext();
            }
            return true;
        }

        public override string ToString()
        {
            Node<int> temp = set;
            Node<int> node = null;
            while (temp != null)
            {
                node = new Node<int>(temp.GetInfo(), node);
                temp = temp.GetNext();
            }
            set = node;
            return $"{set.GetInfo()} {set.GetNext()}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node = new Node<int>(5);
            node = new Node<int>(1, node);
            node = new Node<int>(7, node);
            node = new Node<int>(1, node);
            node = new Node<int>(8, node);
            // 8 - 1 - 7 - 1 - 5 - null
            Node<int> node1 = ArrMove(node, 6);
            Console.WriteLine(node1);
        }

        static public Node<int> QueueMove(Node<int> node, int n) // Homework
        {
            Queue<int> q = new Queue<int>();
            Node<int> rev1 = null;
            Node<int> rev2 = null;
            Node<int> res = null;
            int l = 0;
            while (node != null)
            {
                q.Insert(node.GetInfo());
                l++;
                node = node.GetNext();
            }
            while (n > l)
            {
                n -= l;
            }
            while(l-n != 0)
            {
                rev1 = new Node<int>(q.Remove(), rev1);
                l--;
            }
            while(rev1!= null)
            {
                res = new Node<int>(rev1.GetInfo(), res);
                rev1 = rev1.GetNext();
            }
            while(!q.IsEmpty())
            {
                rev2 = new Node<int>(q.Remove(), rev2);
            }
            while(rev2 != null)
            {
                res = new Node<int>(rev2.GetInfo(), res);
                rev2 = rev2.GetNext();
            }
            return res;

        }
        static public Node<int> ArrMove(Node<int> node, int n) // Homework
        {
            Node<int> temp = node;
            int l = 0;
            while (temp != null)
            {
                l++;
                temp = temp.GetNext();
            }
            while (n > l)
            {
                n -= l;
            }
            int[] arr = new int[l];
            for (int i = l-1; i >= 0; i--)
            {
                arr[i] = node.GetInfo();
                node = node.GetNext();
            }
            Node<int> res = null;
            for (int j = n; j < l; j++)
            {
                res = new Node<int>(arr[j], res);
            }
            for (int k = 0; k < n; k++)
            {
                res = new Node<int>(arr[k], res);
            }
            return res;
        }

        public class MySet<T>
        {
            private Node<T> set;

            public MySet()
            {
                set = null;
            }

            private void Insert(T num, Node<T> node)
            {
                if (node == null)
                {
                    set = new Node<T>(num, set);
                    return;
                }
                if (node.GetInfo().Equals(num))
                {
                    return;
                }

                Insert(num, node.GetNext());
            }
            public void InsertTo(T num)
            {
                Insert(num, set);
            }
            private bool Belong(T num, Node<T> node)
            {
                if (node == null)
                {
                    return false;
                }
                if (node.GetInfo().Equals(num))
                {
                    return true;
                }
                return Belong(num, node.GetNext());
            }
            public bool BelongTo(T num)
            {
                return Belong(num, set);
            }

            public bool IsSame(MySet<T> otherSet)
            {
                while (set != null)
                {
                    if (!otherSet.BelongTo(set.GetInfo()))
                        return false;
                    set = set.GetNext();
                }
                return true;
            }
            public override string ToString()
            {
                Node<T> temp = set;
                Node<T> node = null;
                while (temp != null)
                {
                    node = new Node<T>(temp.GetInfo(), node);
                    temp = temp.GetNext();
                }
                set = node;
                return $"{set.GetInfo()} {set.GetNext()}";
            }
        }

        public class OrderedPair
        {
            private int num;
            private char letter;
            public OrderedPair(int num, char letter)
            {
                this.num = num;
                this.letter = letter;
            }
            public int GetNum()
            {
                return num;
            }
            public int GetLetter()
            {
                return letter;
            }

            public bool IsSame(OrderedPair other)
            {
                if ((other.GetNum() == num) && (other.GetLetter() == letter))
                    return true;
                return false;
            }
            public override string ToString()
            {
                return $"q{num} = {letter}";
            }
        }
        public class TransitRule
        {
            private OrderedPair transit_reason;
            private int result;
            public TransitRule(OrderedPair transit_reason, int result)
            {
                this.transit_reason = transit_reason;
                this.result = result;
            }
            public OrderedPair GetTransitReason()
            {
                return transit_reason;
            }
            public int TransitTo()
            {
                return result;
            }
            public override string ToString()
            {
                return $"{transit_reason} goes to q{result}";
            }
        }

        public class TransitFunction
        {
            private TransitRule[] rules;
            public TransitFunction(TransitRule[] rules)
            {
                this.rules = rules;
            }
            public TransitRule FindTransitRule(int num, char letter)
            {
                OrderedPair pair = new OrderedPair(num, letter);
                for (int i = 0; i < rules.Length; i++)
                {
                    if (rules[i].GetTransitReason().IsSame(pair))
                        return rules[i];
                }
                return null;
            }
            public override string ToString()
            {
                string s = "";
                s += rules[0];
                for (int i = 1; i < rules.Length; i++)
                {
                    s += " /// ";
                    s += rules[i];
                }
                return s;
            }

        }

        public class ASAD
        {
            private int now;
            private MySet<char> letters;
            private MySet<int> states;
            private int first_state;
            private MySet<int> getting_states;
            private TransitFunction function;
            public ASAD(int first_state, MySet<char> letters, MySet<int> states, MySet<int> getting_states, TransitFunction function)
            {
                this.now = first_state;
                this.first_state = first_state;

                this.letters = letters;
                this.states = states;
                this.first_state = first_state;
                this.getting_states = getting_states;
                this.function = function;
            }
            public TransitRule ChangingState(char letter)
            {
                TransitRule transit = function.FindTransitRule(now, letter);
                now = -1;
                if (transit != null)
                {
                    now = transit.TransitTo();
                }
                return transit;
            }
            public bool MakingPath(string word)
            {
                Queue<TransitRule> queue = new Queue<TransitRule>();
                TransitRule transit = null;
                for (int i = 0; i < word.Length; i++)
                {
                    transit = function.FindTransitRule(now, word[i]);
                    queue.Insert(transit);
                }
                for (int i = 0; i < word.Length; i++)
                {
                    transit = function.FindTransitRule(now, word[i]);
                    now = transit.TransitTo();
                }
                if (getting_states.BelongTo(transit.TransitTo()))
                    return true;
                return false;
            }

            public void PrintThePath(Queue<TransitRule> queue)
            {
                string s = "";
                TransitRule transit = null;
                while (queue != null)
                {
                    transit = queue.Remove();
                    s += $"{transit} -> ";
                }

                if (getting_states.BelongTo(transit.TransitTo()))
                    s += "true";
                else
                    s += "false";
                Console.WriteLine(s);
            }
        }

    }
}
