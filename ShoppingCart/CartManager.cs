﻿using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class CartManager
    {
        private readonly List<CartItem> _cartItems;

        public CartManager()
        {
            _cartItems = new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            _cartItems.Add(cartItem);
        }

        public void Remove(int productId)
        {
            var product = _cartItems.FirstOrDefault
            (
                p => p.Product.ProductId == productId
            );
            _cartItems.Remove(product);
        }

        public List<CartItem> CartItems
        {
            get { return _cartItems; }
        }

        public void Clear()
        {
            _cartItems.Clear();
        }

        public int TotalQuantity
        {
            get { return _cartItems.Sum(t => t.Quantity); }
        }

        public decimal TotalPrice
        {
            get { return _cartItems.Sum(i => i.Quantity * i.Product.UnitPrice); }
        }

        public int TotalItem
        {
            get { return _cartItems.Count; }
        }
    }
}