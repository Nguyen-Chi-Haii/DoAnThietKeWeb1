document.querySelectorAll('.quantity-btn').forEach(btn => {
    btn.addEventListener('click', function () {
        const input = this.parentElement.querySelector('.quantity-input');
        let value = parseInt(input.value);

        if (this.classList.contains('minus')) {
            if (value > 1) input.value = value - 1;
        } else {
            input.value = value + 1;
        }
    });
});

// Xử lý nút xóa sản phẩm
document.querySelectorAll('.remove-btn').forEach(btn => {
    btn.addEventListener('click', function () {
        const cartItem = this.closest('.cart-item');
        cartItem.style.opacity = '0';
        setTimeout(() => {
            cartItem.remove();

            // Kiểm tra nếu giỏ hàng trống thì hiển thị trang trống
            if (document.querySelectorAll('.cart-item').length === 0) {
                document.getElementById('cart-with-items').style.display = 'none';
                document.getElementById('empty-cart').style.display = 'block';
            }
        }, 300);
    });
});
document.addEventListener('DOMContentLoaded', function () {

    let provinces = {}, districts = {}, wards = {};

    loadLocationData();

    async function loadLocationData() {
        // Tải dữ liệu từ GitHub
        const provinceRes = await fetch("/dist/tinh_tp.json");
        const districtRes = await fetch("/dist/quan_huyen.json");
        const wardRes = await fetch("/dist/xa_phuong.json");


        provinces = await provinceRes.json();
        districts = await districtRes.json();
        wards = await wardRes.json();

        const provinceSelect = document.getElementById("province");
        provinceSelect.innerHTML = '<option selected disabled>Chọn tỉnh/thành phố</option>';

        for (const code in provinces) {
            const name = provinces[code].name_with_type;
            provinceSelect.innerHTML += `<option value="${code}">${name}</option>`;
        }

        // Khi chọn tỉnh → lọc quận
        provinceSelect.addEventListener("change", function () {
            const selectedProvince = this.value;
            const districtSelect = document.getElementById("district");
            districtSelect.innerHTML = '<option selected disabled>Chọn quận/huyện</option>';

            for (const code in districts) {
                if (districts[code].parent_code === selectedProvince) {
                    const name = districts[code].name_with_type;
                    districtSelect.innerHTML += `<option value="${code}">${name}</option>`;
                }
            }

            // Reset phường/xã khi tỉnh thay đổi
            document.getElementById("ward").innerHTML =
                '<option selected disabled>Chọn quận trước</option>';
        });

        // Khi chọn quận → lọc phường
        document.getElementById("district").addEventListener("change", function () {
            const selectedDistrict = this.value;
            const wardSelect = document.getElementById("ward");
            wardSelect.innerHTML = '<option selected disabled>Chọn phường/xã</option>';
            for (const code in wards) {
                if (wards[code].parent_code === selectedDistrict) {
                    const name = wards[code].name_with_type;
                    wardSelect.innerHTML += `<option value="${code}">${name}</option>`;
                }
            }
        });
    }
});
