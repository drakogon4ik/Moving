using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            IntNode node = new IntNode(-1, null);
            node = new IntNode(2, node);
            node = new IntNode(5, node);
            node = new IntNode(0, node);
            node = new IntNode(100, node);
            // 100 0 5 2 -1
            PrintChain(MinMaxO(node));
        }



        static void PrintChain(IntNode node)
        {
            while (node != null)
            {
                Console.Write(node.GetInfo());
                Console.Write("->");
                node = node.GetNext();
            }
            Console.WriteLine("null");
        }


        static IntNode MinMaxO(IntNode node)
        {
            IntNode resnode = null;
            int min = node.GetInfo();
            int max = node.GetInfo();
            while (node.GetNext() != null)
            {
                if (node.GetInfo() == 0)
                {
                    resnode = new IntNode(min, resnode);
                    resnode = new IntNode(max, resnode);
                    node = node.GetNext();
                    min = node.GetInfo();
                    max = node.GetInfo();
                }
                else
                {
                    if (node.GetInfo() > max)
                        max = node.GetInfo();
                    if (node.GetInfo() < min)
                        min = node.GetInfo();
                    node = node.GetNext();
                }
            }

            if (node.GetInfo() > max)
                max = node.GetInfo();
            if (node.GetInfo() < min)
                min = node.GetInfo();

            resnode = new IntNode(min, resnode);
            resnode = new IntNode(max, resnode);
            IntNode temp = null;
            while(resnode != null)
            {
                temp = new IntNode(resnode.GetInfo(), temp);
                resnode = resnode.GetNext();
            }
            return temp;
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

                return this.info + " " + this.next;
            }

        }
    }
}
