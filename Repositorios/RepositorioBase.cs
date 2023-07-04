using System;
using WebProjectPTI.Data;

namespace WebProjectPTI.Repositorios
{
    public class RepositorioBase
    {
        protected readonly Context _db;


        public RepositorioBase(Context db = null)
        {
            _db = db ?? new Context();
        }
    }
}
