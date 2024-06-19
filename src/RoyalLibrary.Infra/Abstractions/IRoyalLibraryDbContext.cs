﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace RoyalLibrary.Infra.Abstractions;

public interface IRoyalLibraryDbContext : IDisposable
{
    DbSet<T> Set<T>() where T : class;

    EntityEntry<T> Entry<T>(T entity) where T : class;

    int SaveChanges();
}
