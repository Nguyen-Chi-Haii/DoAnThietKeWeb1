document.addEventListener('click', function (e) {
    const heartIcon = e.target.closest('.favorite-icon');
    if (!heartIcon) return;

    e.preventDefault();

    const productId = heartIcon.dataset.productId;
    const isFavorited = heartIcon.classList.contains('favorited');

    const url = isFavorited
        ? `/Favorite/RemoveFromFavorite?productId=${productId}`
        : `/Favorite/AddToFavorite?productId=${productId}`;

    fetch(url)
        .then(res => {
            if (res.redirected) {
                window.location.href = res.url;
                return;
            }
            if (!res.ok) throw new Error("Yêu thích thất bại");

            heartIcon.classList.toggle('favorited');
            showToast(isFavorited ? "Đã xoá khỏi yêu thích" : "Đã thêm vào yêu thích");
        })
        .catch(err => {
            console.error(err);
            showToast("Thao tác thất bại", "error");
        });
});
