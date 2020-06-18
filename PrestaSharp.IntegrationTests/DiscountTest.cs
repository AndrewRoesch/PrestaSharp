﻿using System;
using System.Collections.Generic;
using System.Text;
using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using NUnit.Framework;
using language = Bukimedia.PrestaSharp.Entities.AuxEntities.language;

namespace PrestaSharp.IntegrationTests
{
    class DiscountTest : BaseTest
    {

        private OrderCartRuleFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new OrderCartRuleFactory(TestUrl, TestApiKey, null);
        }

        [Test]
        public void CreateUpdateAndRemove()
        {
            var discount = new Bukimedia.PrestaSharp.Entities.order_cart_rule();

            discount.name = new List<language> { new Bukimedia.PrestaSharp.Entities.AuxEntities.language(1, "DiscountName") };
            discount.code = "DISCCODE";
            discount.id_cart_rule = 1;
            discount.free_shipping = 0;
            discount.value_tax_excl = 0;
            discount.reduction_percent = (decimal?)10;

            discount.date_from = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");
            discount.date_to = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");
            discount.active = 1;
            discount.quantity = 1;
            discount.quantity_per_user = 1;

            var prestaDiscount = factory.Add(discount);
            long id = (long)prestaDiscount.id;

            var cartRuleList = factory.GetIds();
            var cartRule = factory.Get(id);

            Assert.AreEqual(1, cartRuleList.Count);
            Assert.AreEqual("DiscountName", cartRule.name[0].Value);

            cartRule.code = "UPDATED";
            factory.Update(cartRule);

            cartRule = new order_cart_rule();
            cartRule = factory.Get(id);
            Assert.AreEqual("UPDATED", cartRule.code);

            factory.Delete(cartRule);
        }
    }
}