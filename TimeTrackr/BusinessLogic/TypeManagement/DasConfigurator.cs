using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using BusinessLogic.Models;

namespace BusinessLogic.TypeManagement
{
    public static class DasConfigurator
    {

        #region Item configuration extension methods

        private static void Configure<T>(this IEnumerable<T> items, Action<T> applyConfiguration)
        {
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                applyConfiguration(item);
            }
        }

        private static void Configure<T>(this T item, Action<T> applyConfiguration)
        {
            if (item == null)
            {
                return;
            }

            applyConfiguration(item);
        }

        #endregion
    }
}