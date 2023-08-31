using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class NewToken
    {
        public Token token { get; set; } = new Token();

        public class Token
        {
            public string result { get; set; }
            public int id { get; set; }
            public object exception { get; set; }
            public int status { get; set; }
            public bool isCanceled { get; set; }
            public bool isCompleted { get; set; }
            public bool isCompletedSuccessfully { get; set; }
            public int creationOptions { get; set; }
            public object asyncState { get; set; }
            public bool isFaulted { get; set; }
        }
    }
}
