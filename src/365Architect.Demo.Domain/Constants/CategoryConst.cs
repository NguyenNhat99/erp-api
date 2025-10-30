using _365Architect.Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Domain.Constants
{
    public class CategoryConst
    {
        #region Database defines
        public const string TABLE_NAME = "Category";
        public const string FIELD_DESCRIPTION = "Description";
        public const string FIELD_CREATED_AT = "CreatedAt";
        public const string FIELD_UPDATED_AT = "UpdatedAt";
        #endregion

        #region Max length defines
        public const int DESCRIPTION_MAX_LENGTH = 400;
        public const int CATEGORYNAME_MAX_LENGTH = 200;
        #endregion

        #region Message defines
        public const string MSG_CATEGORY_ID_NOT_FOUND = $"{nameof(Category)} with this id was not found";
        #endregion
    }
}
