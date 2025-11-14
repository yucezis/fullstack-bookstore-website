# Books – Full-Stack Bookstore E-Commerce Platform

This project is a fully featured e-commerce application designed for selling books. It includes both a customer storefront and a comprehensive admin panel.

Originally developed as an "Engineering Design" (Mühendislik Tasarımı) capstone project, it is now being actively modernized and refactored.

---

## Features Breakdown

###  1. Customer Storefront
The public-facing website where users browse, add items to cart, manage favorites, and make purchases.

* **Home Page:**
    * Featured books
    * New arrivals
    * Bestsellers 
    * Discounted books section 

* **Categories (Kategoriler):**
    * Multi-level category filtering (Çok seviyeli kategori filtreleme)
    * Grid-structured product listing (Grid yapısında ürün listesi)

* **Product Detail (Ürün Detayı):**
    * Cover image (Kapak görseli)
    * Author, publisher, and description (Yazar, yayınevi, açıklama)
    * Price / discounted price (Fiyat / indirimli fiyat)
    * "Add to Cart" and "Add to Favorites" buttons (Sepete ekle / Favorilere ekle)

* **Login / Registration (Giriş / Kayıt):**
    * Secure customer login page (Müşteri giriş sayfası)

* **Shopping Cart (Sepetim):**
    * Update quantity (Adet güncelleme)
    * Remove item (Ürün kaldırma)
    * View subtotal & total (Ara toplam & genel toplam)
    * Proceed to payment (Ödeme adımı)

* **Favorites (Favorilerim):**
    * A dedicated list page for a user's complete favorites (Favorilere eklenen ürünler listesi)

* **User Profile (Hesabım):**
    * Edit personal info (Bilgi güncelleme)
    * View order history (Sipariş geçmişi)
    * Logout / Delete account (Çıkış / Hesap silme)

---

###  2. Admin Panel
A secure and comprehensive dashboard for site owners to manage products, categories, customers, and sales.

* **Dashboard (İstatistikler):**
    * At-a-glance cards: Total products, customers, stock, & low stock alerts
    * Financial cards: Total revenue & today's revenue
    * Chart.js bar chart for sales visualization (Chart.js satış grafiği)

* **Product Management (Ürün Yönetimi):**
    * Full CRUD (Create, Read, Update, Delete) functionality
    * "Add New Product" (`Yeni Ürün Ekle`)
    * Modal-based updates (`Güncelle`)
    * Edit all fields: author, publisher, stock, price, discount, category, description, image URL

* **Category Management (Kategori Yönetimi):**
    * Full CRUD for categories and sub-categories

* **Sales History (Satış Geçmişi):**
    * A detailed, paginated log of all transactions (Product, customer, quantity, price, date)

* **Admin Management (Admin Yönetimi):**
    * Ability to manage admin accounts

---

##  Technology Stack
* **Backend:** ASP.NET MVC 5
* **Frontend:** HTML5, CSS3, JavaScript, jQuery
* **Database:** Microsoft SQL Server
* **Data Access:** Entity Framework (ORM)
* **Charting:** Chart.js (for admin dashboard)

---

## Geliştirici | Developer

**Name:** Zişan Yüce  
**Department:** Bilgisayar Mühendisliği (Computer Engineering)  
**Goal:** This project demonstrates my ability to design, build, and document a complex, full-stack application based on layered architecture. It showcases a deep understanding of e-commerce logic, full CRUD operations, and (most importantly) the process of refactoring and modernizing a significant codebase.

---

⭐ If you like this project, don’t forget to give it a star!  
