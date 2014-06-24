using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Global
    {
        public static WindowForm form;

        public Global()
        {
            form = new WindowForm();
            form.Show();
        }
    }
}
