using System;
using System.Threading;


namespace WebApplication2._2.Services
{
    public class LifeTimeLogger : IDisposable
    {
        private static int _count;
        private readonly string _name;
        private readonly int _id;

        protected LifeTimeLogger(string name)
        {
            _name = name;
            _id = Interlocked.Increment(ref _count);
            Console.WriteLine($"{_name} {_id} created");
        }

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine($"{_name} {_id} disposed");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
