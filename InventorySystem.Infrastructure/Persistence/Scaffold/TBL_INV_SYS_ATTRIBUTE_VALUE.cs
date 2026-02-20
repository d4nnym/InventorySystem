using System;
using System.Collections.Generic;

namespace InventorySystem.Infrastructure.Persistence.Scaffold;

public partial class TBL_INV_SYS_ATTRIBUTE_VALUE
{
    public Guid ID { get; set; }

    public Guid ATTRIBUTE_ID { get; set; }

    public string VALUE { get; set; } = null!;

    public virtual TBL_INV_SYS_ATTRIBUTE ATTRIBUTE { get; set; } = null!;

    public virtual ICollection<TBL_INV_SYS_PRODUCT> PRODUCTs { get; set; } = new List<TBL_INV_SYS_PRODUCT>();
}
