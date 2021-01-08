using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.Business.Interfaces
{
    public interface IDosyaService
    {
        string AktarPdf<T>(List<T> list);
        byte[] AktarExcel<T>(List<T> list);
    }
}
