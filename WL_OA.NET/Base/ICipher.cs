using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.NET
{
    public interface ICipher
    {
        void Encrypt(ref byte[] Input, int len);
        void Decrypt(ref byte[] Input, int len);
    }
}
