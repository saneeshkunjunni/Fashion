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


        #region Galleries
        private Repository<Gallery> _galleries;
        public Repository<Gallery> GalleriesRepo
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
        #endregion

        #region Job
        private Repository<Jobs> _jobs;
        public Repository<Jobs> JobsRepo
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
        #endregion

        #region Address
        private Repository<Address> _address;
        public Repository<Address> AddressRepo
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
        #endregion

        #region Common
        private Repository<Common> _common;
        public Repository<Common> CommonRepo
        {
            get
            {

                if (this._common == null)
                {
                    this._common = new Repository<Common>(context);
                }
                return _common;
            }
        }

        #endregion

        #region Notifications
        private Repository<Notifications> _notifications;
        public Repository<Notifications> NotificationRepo
        {
            get
            {

                if (this._notifications == null)
                {
                    this._notifications = new Repository<Notifications>(context);
                }
                return _notifications;
            }
        }

        #endregion
        #region Tags
        private Repository<Tags> _tags;
        public Repository<Tags> TagRepo
        {
            get
            {

                if (this._tags == null)
                {
                    this._tags = new Repository<Tags>(context);
                }
                return _tags;
            }
        }

        #endregion
        public int Save()
        {
           return context.SaveChanges();
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
