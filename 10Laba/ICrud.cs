using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Laba
{
    internal interface ICrud
    {
        void Create();
        void Read(bool read = true);
        void Update(int changeIndex, bool gang = true);
        void Delete(int deleteIndex);
    }
}
