using Blossom.Data.Model.BusinessProfiles;
using Blossom.Data.Model.StudentProfiles;
using System.Collections.Generic;

namespace Blossom.Data
{
    public class EntityFilters
    {
        public List<ExpressionFilterGroup>? Group { get; set; }
    }

    public class ExpressionFilterGroup: EntityFilters
    { 

        public ExpressionFilter Filter { get; set; }

        public string Join { get; set; }
    }

    public class ExpressionFilter
	{
        public string Attribute { get; set; }

        public string Expression { get; set; }

        public string Value { get; set; }
    }
}

