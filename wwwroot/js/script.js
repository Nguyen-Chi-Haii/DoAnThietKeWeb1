document.addEventListener('DOMContentLoaded', function () {
    // Lấy các phần tử DOM
    const menuBtn = document.getElementById('menu-btn');
    const searchBtn = document.getElementById('search-btn');
    const cartBtn = document.getElementById('cart-btn');
    const loginBtn = document.getElementById('login-btn');

    const navbar = document.querySelector('.navbar');
    const searchForm = document.querySelector('.search-form');
    const shoppingCart = document.querySelector('.shopping-cart');
    const loginPopup = document.querySelector('.login-form');

    // Toggle menu
    menuBtn.addEventListener('click', () => {
        navbar.classList.toggle('active');
        searchForm.classList.remove('active');
        shoppingCart.classList.remove('active');
        loginPopup.classList.remove('active');
    });

    // Toggle search form
    searchBtn.addEventListener('click', () => {
        searchForm.classList.toggle('active');
        navbar.classList.remove('active');
        shoppingCart.classList.remove('active');
        loginPopup.classList.remove('active');
    });

    // Toggle shopping cart
    cartBtn.addEventListener('click', () => {
        shoppingCart.classList.toggle('active');
        navbar.classList.remove('active');
        searchForm.classList.remove('active');
        loginPopup.classList.remove('active');
    });

    // Toggle login popup
    loginBtn.addEventListener('click', () => {
        loginPopup.classList.toggle('active');
        navbar.classList.remove('active');
        searchForm.classList.remove('active');
        shoppingCart.classList.remove('active');
    });

    // Đóng các popup khi click ra ngoài
    document.addEventListener('click', (e) => {
        if (!loginPopup.contains(e.target) && e.target !== loginBtn) {
            loginPopup.classList.remove('active');
        }
        if (!searchForm.contains(e.target) && e.target !== searchBtn) {
            searchForm.classList.remove('active');
        }
        if (!shoppingCart.contains(e.target) && e.target !== cartBtn) {
            shoppingCart.classList.remove('active');
        }
        if (!navbar.contains(e.target) && e.target !== menuBtn) {
            navbar.classList.remove('active');
        }
    });

    // Ngăn chặn đóng popup khi click bên trong
    loginPopup.addEventListener('click', (e) => {
        e.stopPropagation();
    });
    searchForm.addEventListener('click', (e) => {
        e.stopPropagation();
    });
    shoppingCart.addEventListener('click', (e) => {
        e.stopPropagation();
    });
    navbar.addEventListener('click', (e) => {
        e.stopPropagation();
    });
});