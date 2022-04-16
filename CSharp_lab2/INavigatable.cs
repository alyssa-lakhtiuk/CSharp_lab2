using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_lab2
{
    internal interface INavigatable<TObject> where TObject : Enum
    {
        TObject ViewType
        {
            get;
        }
    }
}
