//---------------------------------------------------------------------------
// <copyright file="UserContext.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

/// <summary>
/// <seealso cref="DbContext"/>  configuration for  <seealso cref="UserEntity"/>.
/// </summary>
public class UserContext : DbContext
{
    
}
