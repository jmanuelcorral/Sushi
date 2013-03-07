using System;
using System.IO;

namespace Sushi.Helpers.BlockHelper
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
