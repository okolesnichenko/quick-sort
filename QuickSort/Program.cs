using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SortThread
{
    class Program
    {
        static MassWithPar ex = new MassWithPar(0, 0, null);
        static object locker = new object();

        static void Main(string[] args)
        {
            Random rnd = new Random();
            ex.mass = new int[6];
            ex.left = 0;
            ex.right = ex.mass.Length - 1;
            for (int i=0; i<ex.mass.Length; i++)
            {
                ex.mass[i] = rnd.Next(50);
                Console.Write(ex.mass[i] + " ");
            }
            QuickSort(ex);
            Console.WriteLine();
            for (int i = 0; i < ex.mass.Length; i++)
            {
                Console.Write(ex.mass[i] + " ");
            }
            Console.ReadLine();
        }

        static int Partition(int [] mass, int left, int right)
        {
            int temp;
            int mark = left;
            for(int i = left; i<=right; i++)
            {
                if(mass[i]<mass[right])
                {
                    temp = mass[mark];
                    mass[mark] = mass[i];
                    mass[i] = temp;
                    mark++;
                }
            }
            temp = mass[mark];
            mass[mark] = mass[right];
            mass[right] = temp;
            return mark;
        }

        static void QuickSort(object a)
        {
            MassWithPar pars = (MassWithPar)a;
            if (pars.left >= pars.right)
            {
                return;
            }

            int middle = Partition(pars.mass, pars.left, pars.right);

            MassWithPar newpar1 = new MassWithPar(pars.left, middle-1, pars.mass);
            Thread thread1 = new Thread(new ParameterizedThreadStart(QuickSort));
            thread1.Start(newpar1);
            thread1.Join();

            MassWithPar newpar2 = new MassWithPar(middle+1, pars.right, pars.mass);
            Thread thread2 = new Thread(new ParameterizedThreadStart(QuickSort));
            thread2.Start(newpar2);
            thread2.Join();

        }

    }
}
