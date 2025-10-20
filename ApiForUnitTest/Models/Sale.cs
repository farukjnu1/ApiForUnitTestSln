using System;
using System.Collections.Generic;

namespace ApiForUnitTest.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public string? CustomerName { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }
}
