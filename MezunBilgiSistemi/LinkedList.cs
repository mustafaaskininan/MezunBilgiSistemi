using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class LinkedList : LinkedListAdt
    {
        public override void Insert(object valueE,object valueI)
        {
            LinkedListNode newLast = new LinkedListNode
            {
                DataE = valueE,
                DataI = valueI
            };
            if (Head == null)
                Head = newLast;
            else
            {
                LinkedListNode oldLast = Head;
                while (oldLast.Next != null)
                {
                    oldLast = oldLast.Next;
                }
                oldLast.Next = newLast;

            }
            Size++;
        }

        public override void Delete(int position)
        {
            int i = 1;
            if (Head != null && position != 0)
            {
                if (position == 1)
                    Head = Head.Next;
                else
                {
                    LinkedListNode posNode = Head;
                    LinkedListNode onceki = Head;
                    while (i != position)
                    {
                        onceki = posNode;
                        posNode = posNode.Next;
                        i++;
                    }
                    onceki.Next = posNode.Next;
                    posNode = null;
                }
            }
        }
        public object[] Veri()
        {
            object[] veri = new object[2];
            veri[0] = Head.DataE; veri[1] = Head.DataI;
            return veri;
        }
        /*public override object GetElement(int position)
        {
            int i = 0;

            LinkedListNode posNode = Head;
            if (position == 1)
                return Head.Data;
            else
            {
                while (i != position)
                {
                    posNode = Head.Next;
                    i++;
                }
                return posNode.Data;
            }
        }

        public override string Display()
        {
            string temp = "";
            LinkedListNode item = Head;
            while (item != null)
            {
                temp += "-->" + item.Data;
                item = item.Next;
            }

            return temp;
        }*/
    
    }
}
