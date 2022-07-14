using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass
{
    public class ResourceWrapper : IDisposable
    {
        // can't override Finalize() but classic destructor is the same thing
        ~ResourceWrapper()
        {
            // any clean up
            // destroyed in 2 gc cycles: heap => finalization queue => 'freachable' => destr
            // do NOT call Dispose() here, destructor is supposed to be fallback
        }
        
        // to free resources ASAP; use any 'using' syntax or try/finally or call manually
        public void Dispose()
        {
            // clean up
            // call Dispose() on any contained disposable objects
            // if free resources here finalization is something meaningless/overkill
            GC.SuppressFinalize(this);
        }
    }
}
