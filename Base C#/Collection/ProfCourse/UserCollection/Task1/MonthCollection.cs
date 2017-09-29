using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class MonthCollection : IEnumerable, IEnumerator
    {
        Month[] month = new Month[12];

        public MonthCollection()
        {
            month[0] = new Month("January", 31, 1);
            month[1] = new Month("February", 28, 2);
            month[2] = new Month("March", 31, 3);
            month[3] = new Month("April", 30, 4);
            month[4] = new Month("May", 31, 5);
            month[5] = new Month("June", 30, 6);
            month[6] = new Month("July", 31, 7);
            month[7] = new Month("August", 31, 8);
            month[8] = new Month("September", 30, 9);
            month[9] = new Month("Oktober", 31, 10);
            month[10] = new Month("November", 30, 11);
            month[11] = new Month("December", 31, 12);
        }

        public Month this[int index]
        {
            get => month[index];
        }

        int position = -1;

        

        public string[] GetMonth(int serialnumber)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < month.Length; i++)
            {
                if (month[i].serialnumber == serialnumber)
                {
                    result.Add(month[i].name);
                }
            }
            return result.ToArray();
        }

        public string[] GetMothForCountDay(int amountday)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < month.Length; i++)
            {
                if (month[i].amountday == amountday)
                {
                    result.Add(month[i].name);

                }
            }
            return result.ToArray();
        }

        public object Current
        {
            get => month[position];
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < month.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
