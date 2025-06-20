## 📦 Cài Đặt Các Package

```bash
🔧 Entity Framework Core
- Install-Package Microsoft.EntityFrameworkCore -Version 8.0.13
- Install-Package Pomelo.EntityFrameworkCore.MySql -Version 8.0.13
- Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.13
```

## 🔧 SignalR (nếu dùng real-time)

```bash
Install-Package Microsoft.AspNetCore.SignalR -Version 8.0.13
```

## 🔐 JWT Authentication

```bash
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 8.0.13
```

## 🔄 AutoMapper

```
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection -Version 12.0.1
```

## ✅ FluentValidation

```
Install-Package FluentValidation.AspNetCore -Version 11.8.2
```

## 🔑 OAuth Providers

```
- Install-Package Microsoft.AspNetCore.Authentication.OAuth -Version 8.0.13
- Install-Package Microsoft.AspNetCore.Authentication.Google -Version 8.0.13
- Install-Package Microsoft.AspNetCore.Authentication.Facebook -Version 8.0.13
```

## 🔄 Flow Tạo Người Dùng (CreateUser)

Dưới đây là quy trình chuẩn hóa để triển khai tính năng tạo người dùng mới, bao gồm cấu trúc thư mục, tên file, và vai trò tương ứng:

✅ `1. CreateUserDto
📁 Thư mục: DIFAChat.Core/DTOs/`

📝 File: CreateUserDto.cs

🎯 Vai trò: Làm model nhận dữ liệu đầu vào từ phía client.

✅ `2. User Entity
📁 Thư mục: DIFAChat.Core/Entities/`

📝 File: User.cs

🎯 Vai trò: Mô hình hóa bảng Users trong cơ sở dữ liệu.

✅ `3. Repository Interface
📁 Thư mục: DIFAChat.Core/Interfaces/`

📝 File: IUserRepository.cs

🎯 Vai trò: Định nghĩa các phương thức thao tác với dữ liệu người dùng.

✅ `4. Repository Implementation
📁 Thư mục: DIFAChat.Infrastructure/Repositories/`

📝 File: UserRepository.cs

🎯 Vai trò: Thực thi các thao tác với cơ sở dữ liệu.

✅ `5. UserValidator
📁 Thư mục: DIFAChat.Application/Validators/`

📝 File: UserValidator.cs

🎯 Vai trò: Xác thực dữ liệu đầu vào bằng FluentValidation.

✅ `6. CreateUserUseCase
📁 Thư mục: DIFAChat.Application/UseCases/`

📝 File: CreateUserUseCase.cs

🎯 Vai trò: Xử lý nghiệp vụ: xác thực → kiểm tra email → hash mật khẩu → lưu user.

✅ `7. MappingProfile
📁 Thư mục: DIFAChat.Application/Mappings/`

📝 File: MappingProfile.cs

🎯 Vai trò: Cấu hình AutoMapper để ánh xạ từ CreateUserDto sang User.

✅ `8. UsersController
📁 Thư mục: DIFAChat.API/Controllers/`

📝 File: UsersController.cs

🎯 Vai trò: Tạo endpoint POST /api/users để tạo mới người dùng.

✅ `9. Middleware Xử Lý Lỗi
📁 Thư mục: DIFAChat.API/Middlewares/`

📝 File: ErrorHandlingMiddleware.cs

🎯 Vai trò: Xử lý lỗi tập trung (như ValidationException, AppException) và trả JSON định dạng đẹp.

✅ `10. Đăng Ký DI (Dependency Injection)
📁 File: DIFAChat.API/Program.cs`

🔧 Vị trí: Trong phương thức ConfigureServices(...)

🎯 Vai trò: Đăng ký các dịch vụ: repository, use case, validator, AutoMapper,...
