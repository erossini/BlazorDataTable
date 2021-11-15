using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Code.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable Set(this DbContext context, Type T) => typeof(DbContext).GetMethod(nameof(Set), BindingFlags.Instance | BindingFlags.Public).MakeGenericMethod(T).Invoke((object)context, (object[])null) as IQueryable;

        public static IQueryable<T> Set<T>(this DbContext context) => typeof(DbContext).GetMethod(nameof(Set), BindingFlags.Instance | BindingFlags.Public).MakeGenericMethod(typeof(T)).Invoke((object)context, (object[])null) as IQueryable<T>;
    }
}
