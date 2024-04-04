using System;

namespace Microsoft
{
    internal class Office
    {
        internal class Interop
        {
            internal class Excel
            {
                internal class Application
                {
                    internal bool Visible;
                    internal object Workbooks;

                    internal void Quit()
                    {
                        throw new NotImplementedException();
                    }
                }

                internal class Workbook
                {
                    internal void Close(bool v)
                    {
                        throw new NotImplementedException();
                    }

                    internal void PrintOut()
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }
    }
}