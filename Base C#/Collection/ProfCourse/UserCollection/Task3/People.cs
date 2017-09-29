using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class People
    {
        public string name;
        string surename;
        DateTime birth;

        public People(string name, string surename, DateTime birth)
        {
            this.birth = birth;
            this.name = name;
            this.surename = surename;
        }

        People[] relativs = new People[0];

        public People this[string name]
        {
            get
            {
                int posit = IndexOf(name);
                if (posit != -1)return relativs[posit];
                return null;
            }

        }
        
        public People[] GetFolkForYear(int year)
        {
            List<People> temp = new List<People>();
            for(int i = 0; i < relativs.Length; i++)
            {
                if (relativs[i].birth.Year == year) temp.Add(relativs[i]);
            }
            return temp.ToArray();
        }

        //Добавление родственника
        public void AddFolk(People folk)
        {
            Array.Resize(ref relativs, relativs.Length + 1);
            relativs[relativs.Length - 1] = folk;
        }

        //Удаление родственика
        public void DelFolk(string name)
        {
            int index = IndexOf(name);
            if(index != -1)
            {
                for(int i = index; i < relativs.Length - 1; i++)
                {
                    relativs[i] = relativs[i + 1];
                }
            }
            Array.Resize(ref relativs, relativs.Length - 1);
        }

        //Поиск индекс родственника
        public int IndexOf(string name)
        {
            for (int i = 0; i < relativs.Length; i++)
            {
                if (relativs[i].name == name) return i;
            }
            return -1;
        }

        public IEnumerable GetEnumerator()
        {
            for(int i = 0; i < relativs.Length; i++)
            {
                yield return relativs[i];
            }
        }

    }
}
