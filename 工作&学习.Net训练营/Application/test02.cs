using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class test02:test01
    {
        public string sex { get; set; }

        public string getName
        {
            get
            {

                name = "fffff";

                return name;
 
            }
        }
    }

    public class BaseClass
    {
        protected internal int myValue = 0;
    }

    public class TestAccess
    {
        void Access()
        {
            var baseObject = new BaseClass();
            baseObject.myValue = 5;
        }
    }
}
