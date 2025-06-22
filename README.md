# Goroco Shop - Website Bán Thực Phẩm Hữu Cơ

![Goroco Shop Banner](https://via.placeholder.com/1200x400?text=Goroco+Shop+-+Fresh+Organic+Food)

Goroco Shop là website thương mại điện tử chuyên cung cấp các sản phẩm thực phẩm hữu cơ chất lượng cao, đảm bảo an toàn cho sức khỏe người tiêu dùng.

## Tính năng chính

### 1. Phân quyền người dùng
- **Người dùng thường (User)**:
  - Xem sản phẩm, đọc blog
  - Thêm sản phẩm vào giỏ hàng
  - Thanh toán, tạo đơn hàng
  - Đánh giá sản phẩm
  - Quản lý thông tin cá nhân
  
- **Quản trị viên (Admin)**:
  - Quản lý sản phẩm (thêm/sửa/xóa)
  - Quản lý người dùng
  - Quản lý đơn hàng
  - Quản lý bài viết/blog
  - Thống kê doanh số

### 2. Chức năng sản phẩm
- Hiển thị danh sách sản phẩm theo danh mục
- Tìm kiếm và lọc sản phẩm
- Xem chi tiết sản phẩm (hình ảnh, mô tả, đánh giá)
- Hệ thống đánh giá và xếp hạng sao
- Thêm sản phẩm vào giỏ hàng

### 3. Giỏ hàng & Thanh toán
- Thêm/xóa/sửa số lượng sản phẩm trong giỏ
- Tính toán tổng tiền tự động
- Đặt hàng và thanh toán
- Lưu lịch sử đơn hàng
- Hủy đơn hàng (khi trạng thái "Chưa xác nhận")

### 4. Quản lý người dùng
- Đăng ký tài khoản mới
- Đăng nhập/Đăng xuất
- Quên mật khẩu
- Cập nhật thông tin cá nhân
- Quản lý địa chỉ giao hàng

### 5. Blog & Bài viết
- Hiển thị danh sách bài viết
- Xem chi tiết bài viết
- Phân loại bài viết theo chủ đề
- Bình luận bài viết

### 6. Trang liên hệ
- Form liên hệ với cửa hàng
- Thông tin địa chỉ, số điện thoại
- Bản đồ chỉ dẫn

### 7. Admin Dashboard
- **Quản lý sản phẩm**:
  - Thêm/sửa/xóa sản phẩm
  - Quản lý danh mục sản phẩm
  - Quản lý kho hàng
  
- **Quản lý đơn hàng**:
  - Xem danh sách đơn hàng
  - Cập nhật trạng thái đơn hàng
  - Hủy đơn hàng
  
- **Quản lý người dùng**:
  - Xem danh sách người dùng
  - Khóa/mở tài khoản
  
- **Quản lý nội dung**:
  - Tạo/sửa/xóa bài viết blog
  - Quản lý bình luận
  
- **Thống kê**:
  - Doanh số theo ngày/tuần/tháng
  - Sản phẩm bán chạy
  - Thống kê người dùng mới

## Công nghệ sử dụng
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5
- **Backend**: ASP.NET Core MVC
- **Cơ sở dữ liệu**: SQL Server
- **Xác thực**: ASP.NET Core Identity
- **Payment**: Tích hợp cổng thanh toán (đang phát triển)

## Hướng phát triển trong tương lai
1. **Hệ thống yêu thích**
   - Thêm sản phẩm vào danh sách yêu thích
   - Thêm bài viết vào mục đã lưu
   - Nhận thông báo khi sản phẩm yêu thích giảm giá

2. **Đánh giá nâng cao**
   - Cho phép đăng đánh giá kèm hình ảnh
   - Hệ thống xác minh mua hàng trước khi đánh giá
   - Tương tác giữa người bán và người đánh giá

3. **Hệ thống gợi ý thông minh**
   - Gợi ý sản phẩm dựa trên lịch sử mua hàng
   - "Sản phẩm thường mua cùng"
   - "Khách hàng mua sản phẩm này cũng mua"
   - "Tìm kiếm sản phẩm"

4. **Tích hợp thanh toán trực tuyến**
   - Cổng thanh toán VNPay, MoMo
   - Thanh toán qua thẻ tín dụng

5. **Tích hợp mạng xã hội**
   - Đăng nhập bằng Facebook/Google
   - Chia sẻ sản phẩm lên mạng xã hội
   - Hiển thị đánh giá từ Facebook

6. **Chương trình khách hàng thân thiết**
   - Tích điểm khi mua hàng
   - Đổi điểm lấy voucher
   - Hạng thành viên (Vàng, Bạch kim)

7. **Hỗ trợ khách hàng**
   - Chat trực tuyến với nhân viên
   - Hệ thống ticket hỗ trợ
   - Câu hỏi thường gặp (FAQ)

8. **Tính năng đa ngôn ngữ**
   - Hỗ trợ tiếng Anh, tiếng Việt
   - Tùy chọn chuyển đổi ngôn ngữ

## Cài đặt và chạy dự án

### Yêu cầu hệ thống
- .NET 6.0 SDK
- SQL Server 2019+
- Visual Studio 2022 (khuyến nghị)

### Các bước cài đặt
1. Clone repository:
```bash
git clone https://github.com/yourusername/gorocoshop.git
```

2. Khôi phục packages:
```bash
dotnet restore
```

3. Cập nhật cơ sở dữ liệu:
```bash
dotnet ef database update
```

4. Chạy ứng dụng:
```bash
dotnet run
```

## Đóng góp vào dự án
Chúng tôi hoan nghênh mọi đóng góp từ cộng đồng! Để đóng góp:
1. Fork repository
2. Tạo branch mới (`git checkout -b feature/your-feature`)
3. Commit các thay đổi (`git commit -m 'Add some feature'`)
4. Push lên branch (`git push origin feature/your-feature`)
5. Tạo Pull Request

## Giấy phép
Dự án được phân phối dưới giấy phép [MIT](LICENSE).

## Liên hệ
- Email: contact@gorocoshop.com
- Website: https://gorocoshop.com
- Địa chỉ: 123 Đường ABC, Quận 1, TP.HCM

---
![Goroco Shop Footer](https://via.placeholder.com/1200x200?text=Fresh+Organic+Food+for+Healthy+Life)
