using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.MailSystem
{
    public class MailEventArgs
    {
        
            public String From { get; set; }
            public String To { get; set; }
            public String Subject { get; set; }

            public String Body { get; set; }
        }
        // dichiaro il delegate nel name space, convenzionalmente il delegate finisce con Event Handler
        public delegate void MailManagerEventHandler(Object sender, MailEventArgs args);

    }

