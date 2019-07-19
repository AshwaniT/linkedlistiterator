using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlistiterator
{
   public class Node<T>
    {
       public Node<T> Link { get; set; }
       public T Data { get; set; }
       public Node()
       {
           Link = null;
           Data = default(T);
       }
       public Node(T _data)
       {
           Link = null;
           Data = _data;
       }
    }
}
