using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EFCodeFirstOperacionesCRUD.EntityFramework.Entities.Base;

namespace EFCodeFirstOperacionesCRUD.EntityFramework.Entities
{
    public class Customer : EntityBase
    {
        private int _customerId;
        private string _firstName;
        private string _lastName;

        [Key]
        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }

        [NotMapped]
        public string FullName => string.Format("{0} {1}", FirstName, LastName);

        public ICollection<Order> Orders { get; set; }
    }
}
