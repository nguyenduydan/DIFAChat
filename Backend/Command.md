# Cho EF Core
Install-Package Microsoft.EntityFrameworkCore
Install-Package Pomelo.EntityFrameworkCore.MySql
Install-Package Microsoft.EntityFrameworkCore.Design

# Cho SignalR (nếu dùng real-time)
Install-Package Microsoft.AspNetCore.SignalR

# JWT Authentication
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 8.0.5

# AutoMapper
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection

# FluentValidation
Install-Package FluentValidation.AspNetCore

#OAuth
Install-Package Microsoft.AspNetCore.Authentication.OAuth
Install-Package Microsoft.AspNetCore.Authentication.Google -Version 8.0.5
Install-Package Microsoft.AspNetCore.Authentication.Facebook -Version 8.0.5


# Flow createUser
Dưới đây là bản tổng kết đầy đủ flow CreateUser, gồm: thư mục tương ứng, thứ tự tạo file, và vai trò của từng phần:

✅ 1. CreateUserDto
📁 Thư mục: DIFAChat.Core/DTOs/

📝 File: CreateUserDto.cs

🔧 Vai trò: Truyền dữ liệu từ client → server (input model).

✅ 2. User Entity
📁 Thư mục: DIFAChat.Core/Entities/

📝 File: User.cs

🔧 Vai trò: Định nghĩa mô hình bảng Users trong database.

✅ 3. Repository Interface
📁 Thư mục: DIFAChat.Core/Interfaces/

📝 File: IUserRepository.cs

🔧 Vai trò: Định nghĩa hợp đồng truy cập dữ liệu người dùng.

✅ 4. Repository Implementation
📁 Thư mục: DIFAChat.Infrastructure/Repositories/

📝 File: UserRepository.cs

🔧 Vai trò: Thực thi logic lưu user vào DB.

✅ 5. UserValidator
📁 Thư mục: DIFAChat.Application/Validators/

📝 File: UserValidator.cs

🔧 Vai trò: Xác thực dữ liệu đầu vào bằng FluentValidation.

✅ 6. CreateUserUseCase
📁 Thư mục: DIFAChat.Application/UseCases/

📝 File: CreateUserUseCase.cs

🔧 Vai trò: Xử lý nghiệp vụ chính: validate → kiểm tra email → hash → lưu user.

✅ 7. MappingProfile
📁 Thư mục: DIFAChat.Application/Mappings/

📝 File: MappingProfile.cs

🔧 Vai trò: Cấu hình AutoMapper để map từ CreateUserDto → User.

✅ 8. UsersController
📁 Thư mục: DIFAChat.API/Controllers/

📝 File: UsersController.cs

🔧 Vai trò: Endpoint POST /api/users để tạo user mới.

✅ 9. Middleware xử lý lỗi
📁 Thư mục: DIFAChat.API/Middlewares/

📝 File: ErrorHandlingMiddleware.cs

🔧 Vai trò: Bắt và trả lỗi định dạng gọn gàng (ValidationException, AppException).

✅ 10. Đăng ký DI
📁 File: DIFAChat.API/Program.cs

🔧 Vị trí: Trong phương thức ConfigureServices(...)

🔧 Vai trò: Đăng ký các service: repository, use case, validator, automapper.