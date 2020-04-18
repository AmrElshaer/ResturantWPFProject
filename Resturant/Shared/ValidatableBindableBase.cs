using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Resturant.Shared
{
    class ValidatableBindableBase:BindableBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        public bool HasErrors => errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (errors.ContainsKey(propertyName))
            {
                return errors[propertyName];
            }
            return null;
        }
        protected override void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            base.SetProperty(ref member, val, propertyName);
            ValidateProperty(propertyName, val);
        }

       

        private void ValidateProperty<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {

                errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                errors.Remove(propertyName);
            }
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
