using System;
using System.Threading.Tasks;

namespace randomapp.Examples
{
    public interface IDeterministic
    {
        int Add(int a, int b);
        Task<int> AsyncHeavyOperation(int a, int b);
    }

    public class Deterministic : IDeterministic
    {       
        public int Add( int a, int b)
        {
            return a + b;
        }

        public async Task<int> AsyncHeavyOperation( int a, int b)
        {
            return await Task.FromResult<int>(a+b);
        }
        
    }
}
