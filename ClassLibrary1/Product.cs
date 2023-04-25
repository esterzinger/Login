﻿using System;
using System.Collections.Generic;

namespace Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Price { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public string? Img { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
