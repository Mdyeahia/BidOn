using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidOn.Data;
using BidOn.Entities;

namespace BidOn.Service
{
    public class SharedService
    {
        #region Singleton
        public static SharedService Instance
        {
            get
            {
                if (instance == null) instance = new SharedService();

                return instance;
            }
        }
        private static SharedService instance { get; set; }

        private SharedService()
        {
        }

        #endregion

        public int SavePicture(Picture picture)
        {
            var context = new BidOnContext();

            context.Pictures.Add(picture);
            context.SaveChanges();

            return picture.Id;
        }
    }
}
