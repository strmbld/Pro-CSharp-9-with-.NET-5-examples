using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass
{
    class ResourceWrapperOfficial : IDisposable
    {
        private bool disposed = false;
        public void Dispose()
        {
            // call helper method with all clean up logic
            CleanUp(true);

            // prevent finalization
            GC.SuppressFinalize(this);
        }
        private void CleanUp(bool disposing)
        {
            // check if not already disposed
            if (!disposed)
            {
                // true means client called dispose
                if (disposing)
                {
                    // dispose managed resources
                }
                //
                // clean up unmanaged resources
                //
            }
            disposed = true;
        }
        ~ResourceWrapperOfficial()
        {
            // false means it is kinda late for any dispose being in GC already
            CleanUp(false);
        }
    }
}
