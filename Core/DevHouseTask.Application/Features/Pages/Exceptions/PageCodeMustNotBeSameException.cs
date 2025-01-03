using DevHouseTask.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Exceptions
{
    public class PageCodeMustNotBeSameException : BaseExceptions
    {
        public PageCodeMustNotBeSameException(){ }
        public PageCodeMustNotBeSameException(string message):base("Sayfa kodu zaten var")
        {
            
        }
    }
}
