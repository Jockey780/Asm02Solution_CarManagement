Link Youtube: [[https://youtu.be/xpG1VdDwh1I](https://youtu.be/xpG1VdDwh1I)https://youtu.be/xpG1VdDwh1I](https://youtu.be/1yUHESSxO6E)
- Video này em up lên là hôm nay em có phát hiện là link youtube trên github Assignment 2 là em gửi nhầm video test thử thuyết trình của em chứ không có gian dối gì đâu thầy. Em xin cảm ơn

Mô tả bài chi tiết Assigment 2 Razor Page
	Lê Hoàng Minh Nhật 
	SE161790 
	SĐT: 0338290661

Các chức năng đã thực hiện

 Tổng cộng bài là có 4 trang (Login, Register, Admin và Customer)
- Login:
	- Có valadiation khi đăng nhập (chỉ là em chưa thêm mấy cái messesage khi có lỗi)
	- Có chức năng phần quyền cho từng Roles(Admin và Customer)
   
- Sau khi Login thành công:
	- Mỗi user sẽ có những Pages riêng
	- Có thể Log out	
	- Admin có thể xem và chỉnh sửa(CRUD) User, Cars, Category, Order và Order detail 
		- có thể Search các thành phần trên(trừ Order detail)

	- Customer khi đang nhập thì chỉ đơn giản show User Profile của Customer đó và có thể edit

 
Bug:

- Bug Order và User Profile khi edit xong, chưa thay đổi gì ngay lập tức bên trang Index nhứng có thay đổi trong DB.
- Register (không tăng số Id cho mỗi lần User đăng kí => không Register được).
- Bug không show được CustomerName trong order và Car trong orderdetails.
- Bug khi create new car thì ko tự động nhảy sang trang index.


Tổng kết
(với đây là lần đầu em là host GitHub nếu có sai sót gì mong thầy thông cảm)

Với những chức năng và thiếu sót của em thì em xin đánh giá bài em là 8 điểm.

Em xin cảm ơn
