//---------------------------------------------------------------------------
// <copyright file="ProductVariantEntity.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Domain.Entities;

using NetMicroservices.SqlWrapper.Nuget;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class ProductVariantEntity : EntityBase
{
    [JsonIgnore]
    public ProductEntity? Product { get; set; }
    public Guid ProductId { get; set; }


    public ProductTypeEntity? ProductType { get; set; }
    public Guid ProductTypeId { get; set; }

    [Column(TypeName ="decimal(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal OriginalPrice { get; set; }
}
