using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Lab_1_Test
{
    class UlamekTest
    {
        [Test]
        public void Konstruktory()
        {
            //arrange
            Ulamek a = new Ulamek();
            Ulamek b = new Ulamek(12,3);
            Ulamek c = new Ulamek(a);
            //act

            //assert
        }
    }
}
