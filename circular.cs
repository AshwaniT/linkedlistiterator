using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlistiterator
{
   public class Circular<T>
    {
       private Node<T> Header { get; set; }
       public int Count { get; private set; }
       public Circular()
       {
           Header = new Node<T>();
           Count = 0;
       }
       public bool IsEmpty
       {
           get
           {
               return Header.Link == null;
           }
       }

       public void AddAtEnd(T nodeData)
       {
           var newNode = new Node<T>(nodeData);
           if(Header.Link==null)
           {
               Header.Link=newNode;
               newNode.Link = Header.Link;
               Count=1;
               return;
           }
           var last = Last;
           last.Link = newNode;
           newNode.Link = Header.Link;
           Count++;

       }

       public void AddAtBegin(T nodeData)
       {
           var newNode = new Node<T>(nodeData);
           if (Header.Link == null)
           {
               Header.Link = newNode;
               newNode.Link = Header;
               Count = 1;
               return;
           }
           newNode.Link = Header.Link;
           Header.Link = newNode;
           Count++;

       }
       private Node<T> Last
       {
           get
           {
               if (Header.Link == null)
                   throw new InvalidOperationException("Empty list");
               var current = Header.Link;
               while (current.Link != Header.Link)
               {
                   current = current.Link;
               }
               return current;
           }
       }
       public void Delete(T nodedata)
       {
           if (Header.Link == null)
               throw new InvalidOperationException("Empty list");
           var current = Header.Link;
           var pre = Last;
           while (!current.Data.Equals(nodedata))
           {             
               if (current.Link == null)
                   throw new InvalidOperationException("Cant find data");
               pre = current;
               current = current.Link;
           }
           if (current.Data.Equals(nodedata))
           {
               if (Header.Link == current)
                   Header.Link = current.Link;
               pre.Link = current.Link;
               Count--;
           }

       }
       public void ShowList()
       {
           if (Header.Link == null)
               throw new IndexOutOfRangeException("empty list");
           var current = Header.Link;
           do
           {
               Console.WriteLine(current.Data);
               current = current.Link;
           } while (current != Header.Link);

       }
       public Node<T>[] ToArray()
       {
           if (Header.Link == null)
               throw new IndexOutOfRangeException("empty list");
           var array = new Node<T>[Count];
           var current=Header.Link;
           var i=0;
           do
           {
               array[i++] = current;
               current = current.Link;
           } while (current != Header.Link);
          

           return array;
       }

       public Node<T> Find(T dta)
       {
           if (Header.Link == null)
               throw new IndexOutOfRangeException("empty list");
           var current = Header.Link;
           if(current.Data.Equals(dta))
               return current;
           while (!current.Data.Equals(dta))
           {
               current=current.Link;
               if (Header.Link == current)
                   return null;
           }
           return current;
       }
       public Node<T> First
       {
           get
           {
               return Header.Link;
           }
       }
       public bool HasCycle()
       {
           if (Header.Link == null)
               return false;
           var current = Header.Link;
           if (current.Link==Header)
               return true;
           var i = 1;
           while (i<=Count)
           {
               current = current.Link;
               if (current.Link == Header)
                   return true;
               ++i;
           }
           return current;
       }
    }
}
