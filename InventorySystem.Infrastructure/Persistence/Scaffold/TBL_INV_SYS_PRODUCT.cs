using System;
using System.Collections.Generic;

namespace InventorySystem.Infrastructure.Persistence.Scaffold;

public partial class TBL_INV_SYS_PRODUCT
{
    public Guid ID { get; set; }

    public Guid MODEL_ID { get; set; }

    public string SKU { get; set; } = null!;

    public string PRODUCT_NAME { get; set; } = null!;

    public string DESCRIPTION { get; set; } = null!;

    public virtual TBL_INV_SYS_MODEL MODEL { get; set; } = null!;

    public virtual ICollection<TBL_INV_SYS_ATTRIBUTE_VALUE> VALUEs { get; set; } = new List<TBL_INV_SYS_ATTRIBUTE_VALUE>();
}
