using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Proverki
{
    public class Proverki
    {
        public bool charactersMoreThenOne(string s)
        {
            return s.Length > 1;
        }

        public bool passwordLengthMoreThenVosem(string password)
        {
            return password.Length >= 8;
        }
        public bool rating(int r)
        {
            return r >= 0 & r <= 10;
        }
        public bool digitsPositiv(int d)
        {
            return d >= 0;
        }
    }
}