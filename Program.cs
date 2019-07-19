using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlistiterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Circular<int>();
            for (var i = 1; i <= 40; ++i)
            {
                list.AddAtEnd(i);
            }
            Console.WriteLine("**************Initial list***********");
            foreach (var item in list.ToArray())
            {
                Console.WriteLine(item.Data);
            }
            var f = list.First;
            while (list.Count > 2)
            {
                var todelete = f.Link.Link;
                f = todelete.Link;
                list.Delete(todelete.Data);                
            }
            //for(int j=1;list.Count>2;++j)
            //{
            //    if (j % 3 == 0)
            //    {
            //        var obj = list.Find(j);
            //        if (obj == null)
            //        {
            //            obj = list.Find(j % 40);
            //        }
            //        list.Delete(obj.Data);
            //    }
            //}
            
            Console.WriteLine("**************After  list***********");
            list.ShowList();
            Console.Read();

        }
    }
}
