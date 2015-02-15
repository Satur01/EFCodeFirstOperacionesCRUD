using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstOperacionesCRUD.EntityFramework.Entities.Base;

namespace EFCodeFirstOperacionesCRUD.EntityFramework.Entities
{
    public class Order : EntityBase
    {
        private int _orderId;
        private decimal _total;
        private int _customerId;

        [Key]
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                _orderId = value;
                OnPropertyChanged();
            }
        }

        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                OnPropertyChanged();
            }
        }

        public Customer Customer { get; set; }


    }
}
