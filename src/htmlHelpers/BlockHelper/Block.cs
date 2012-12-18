using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sushi.BlockHelper
{
    public class Block:IDisposable
    {
        private readonly TextWriter _writer;
        public Block(TextWriter writer)
        {
            _writer = writer;
        }

        public void Dispose()
        {
            _writer.Write("</div>");
        }

    }
}
