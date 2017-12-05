using FashionModeling.DAL;
using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling
{
    public class UnitOfWork : IDisposable
    {
        public ApplicationDbContext context = new ApplicationDbContext();


        private Repository<Gallery> _galleries;
        public Repository<Gallery> Galleries
        {
            get
            {

                if (this._galleries == null)
                {
                    this._galleries = new Repository<Gallery>(context);
                }
                return _galleries;
            }
        }
        private Repository<Jobs> _jobs;
        public Repository<Jobs> Jobs
        {
            get
            {

                if (this._jobs == null)
                {
                    this._jobs = new Repository<Jobs>(context);
                }
                return _jobs;
            }
        }
        private Repository<Address> _address;
        public Repository<Address> Address
        {
            get
            {

                if (this._address == null)
                {
                    this._address = new Repository<Address>(context);
                }
                return _address;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
