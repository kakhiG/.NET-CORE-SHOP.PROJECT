using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Infrastracture
{
    public static class DecimelExtensions
    {
        public static string GetValueString(this decimal value) =>
                $"£ {value.ToString("N2")}";

    }
}
