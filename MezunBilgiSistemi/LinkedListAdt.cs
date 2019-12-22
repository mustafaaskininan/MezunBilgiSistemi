using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public abstract class LinkedListAdt
    {
        public LinkedListNode Head;
        public int Size = 0;
        public abstract void Insert(object valueE,object valueI);
        public abstract void Delete(int position);
        /*public abstract object GetElement(int position);
        public abstract string Display();*/
    }
}
