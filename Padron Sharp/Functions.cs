using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padron
{
    class Functions
    {
        public string password(string curp)
        {
            string data = null;

            if(curp != "")
            {
                string dd = curp.Substring(8, 2);
                string mm = curp.Substring(6, 2);
                string yyyy = "19" + curp.Substring(4, 2);

                data = dd + mm + yyyy;
            } else {
                data = "12345678";
            }

            return data;
        }

        public string mail(string mail,string username)
        {
            string data = null;

            if (mail == "")
            {
                data = username +"@comunidad.unam.mx";
            }
            else
            {
                data = mail;
            }

            return data;
        }
    }
}
