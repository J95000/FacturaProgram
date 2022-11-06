using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDistribuidor.Services
{
    public interface IPdfViewer
    {
        Task Open(byte[] pdf,int idMovimiento);

    }
}
