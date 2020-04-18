using Entity.Code.Base.Documentary;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Entity.Code.Management
{
    public class Account : EntityDocument, INotifyPropertyChanged
    {
        private string _password = null;
        private string _name = null;
        private string _surname = null;
        private string _codePersonal = null;
        private string _email = null;
        private string _phone = null;
        private string _validationMessage = null;

        [Key]
        public int Id { get; set; }
        public string Tag { get; set; }
        public DateTime LastLogin { get; set; }
        public AccountSecurity CurrentSecurity { get; set; }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        } 
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        } 
        public string Surnames
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surnames));
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public string PersonalCode
        {
            get { return _codePersonal; }
            set
            {
                _codePersonal = value;
                OnPropertyChanged(nameof(PersonalCode));
            }
        } 
        public string ValidationMessage
        {
            get { return _validationMessage; }
            set
            {
                _validationMessage = value;
                OnPropertyChanged(nameof(ValidationMessage));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ValidateData()
        {
            if (Password.Trim().Length < 8)
            {
                ValidationMessage = "Password must be at least eight characters long";
            }
            else if (Password.Trim().Length > 20)
            {
                ValidationMessage = "Password cannot be more than twenty characters long";
            }
            else if (!Password.Any(char.IsUpper))
            {
                ValidationMessage = "Password must contain at least one upper-case character";
            }
            else if (!Password.Any(char.IsLower))
            {
                ValidationMessage = "Password must contain at least one lower-case character";
            }
            else if (!Password.Any(char.IsNumber))
            {
                ValidationMessage = "Password must contain at least one number";
            }
            else
            {
                ValidationMessage = "Password is secure";
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
