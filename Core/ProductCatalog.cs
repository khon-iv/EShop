﻿using System.Collections.Generic;
using System.Linq;

namespace Core;

public static class ProductCatalog
{
    private static readonly List<Product> Products = new List<Product>();
    public static IEnumerable<Product> ProductsForDisplay => 
        Products.Where(p => p is { Remains: > 0, Price: > 0 });

    static ProductCatalog()
    {
        CreateArrayOfProducts();
    }
    
    private static void CreateArrayOfProducts()
    {
        Products.AddRange(new List<Product>
        {
            new Product(
                0,
                "Электрочайник BEON BN-006 синий",
                ProductCategories.ForHome,
                450,
                5,
                "Электрический чайник BEON BN-006 предназначен для кипячения воды. " +
                "В модели открытая спираль. Функцию автоотключения прибор не имеет."
            ),
            new Product(
                1,
                "Фен Aceline BA-100 красный/черный",
                ProductCategories.ForBeautyAndHealth,
                599,
                7
            ),
            new Product(
                2,
                "6.7\" Смартфон realme Note 50 64 ГБ черный",
                ProductCategories.Phone,
                7499,
                10
            ),
            new Product(
                3,
                "24\" (61 см) LED-телевизор Aceline 24HEN1 черный",
                ProductCategories.TV,
                1199
            ),
            // не должен отображаться в каталоге, т.к. отстаток 0
            new Product(
                4,
                "14.1\" Ноутбук DEXP Aquilon серебристый",
                ProductCategories.PC,
                price: 10000,
                remains: 0,
                description: "Aquilon оборудован сенсорным NumPad, который упрощает ввод числовой информации. "
            )
        });
    }
}