using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    public class DTOValidator : IDataErrorInfo
    {
        [Browsable(false)]
        public string this[string property]
        {
            get
            {
                var propertyDes = TypeDescriptor.GetProperties(this)[property];
                if (propertyDes == null)
                    return string.Empty;
                IList<ValidationResult> valResults = new List<ValidationResult>();
                var rs = Validator.TryValidateProperty(propertyDes.GetValue(this), new ValidationContext(this, null, null) { MemberName = property }, valResults);
                if (!rs)
                {
                    return valResults.First().ErrorMessage;
                }
                return string.Empty;
            }
        }

        [Browsable(false)]
        public string Error
        {
            get
            {
                IList<ValidationResult> valResults = new List<ValidationResult>();
                var rs = Validator.TryValidateObject(this, new ValidationContext(this, null, null), valResults, true);
                if (!rs)
                {
                    string.Join(Environment.NewLine, valResults.Select(e => e.ErrorMessage));
                    return string.Format("Error");
                }
                return null;
            }
        }

        [Browsable(false)]
        public bool IsValid => string.IsNullOrEmpty(Error);
    }
}
