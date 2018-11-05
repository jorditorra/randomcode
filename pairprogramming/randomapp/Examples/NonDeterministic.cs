using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace randomapp.Examples
{
    public interface INonDeterministic
    {
        Task<int> CalculationWithDependencies(int a, int b);
    }

    public interface IDependency
    {
        Task<int> AsyncExternalCall(int a);        
    }

    public class NonDeterministic : INonDeterministic
    {
        protected IDependency _dependency;

        public NonDeterministic(IDependency dependency )
        {
            if (dependency == null)
                throw new ArgumentNullException("dependency");
            _dependency = dependency;
        }

        public async Task<int> CalculationWithDependencies(int a, int b)
        {
            return b + await _dependency.AsyncExternalCall(a);
        }
    }
}
