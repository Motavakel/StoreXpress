﻿using Domain.Entities.Base;
using Domain.Entities.Identity;

namespace Domain.Entities.ProductEntity;

public class Product : BaseAuditableEntity, ICommands
{
    public string Title { get; set; }
    public int Price { get; set; }
    public string PictureUrl { get; set; }
    public int ProductTypeId { get; set; }
    public int ProductBrandId { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
    public string Summary { get; set; }

    public ProductType ProductType { get; set; }
    public ProductBrand ProductBrand { get; set; }
}