# DIFAChat

- Một ứng dụng **real-time chat** sử dụng WebSocket (SignalR), được xây dựng bằng ASP.NET Core (backend), React + Vite (frontend), và MySQL (PlanetScale hoặc local) làm hệ quản trị cơ sở dữ liệu.
- Commit git: [id-task]-[nội dung công việc đã làm]

---

## 📚 Nội dung

- [Tổng quan](#tổng-quan)
- [Tính năng](#tính-năng)
- [Kiến trúc & cấu trúc thư mục](#kiến-trúc--cấu-trúc-thư-mục)
- [Cài đặt & chạy thử](#cài-đặt--chạy-thử)
- [Kế hoạch mở rộng](#kế-hoạch-mở-rộng)

---

## 🧱 Tổng quan

DIFAChat là một ứng dụng trò chuyện nhóm và cá nhân **thời gian thực**, hỗ trợ các tính năng:

- Đăng ký / đăng nhập với xác thực JWT và hệ thống phân quyền
- Gửi, nhận tin nhắn realtime
- Kết bạn, gửi lời mời, duyệt danh sách bạn bè
- Tạo “room” chat nhóm, thêm thành viên, quản lý quyền
- Quản trị người dùng, phân quyền admin/moderator, quản lý account

---

## ⚙️ Kiến trúc & cấu trúc thư mục

```plaintext
DIFAChat/
├── Backend/
│   ├── DIFAChat.API/              # Web API + SignalR hub + Auth
│   ├── DIFAChat.Core/             # Entity, DTO, Interface
│   ├── DIFAChat.Application/      # Business logic, UseCase
│   └── DIFAChat.Infrastructure/   # DBContext, Repositories, JWT
└── Frontend/
    ├── public/
    ├── src/
    │   ├── components/                 # ChatBox, MessageItem, Sidebar...
    │   ├── pages/                      # HomePage, ChatRoom, AdminPage...
    │   ├── hooks/                      # useChat, useAuth, useSignalR
    │   ├── services/                   # chatApi, authApi, signalRService
    │   ├── utils/                      # formatDate, localStorage
    │   └── App.tsx, main.tsx           # Entry point
    ├── vite.config.js
    └── package.json
```

---

## 🚀 Cài đặt & chạy thử

### Backend

1. Clone repo & vào thư mục `Backend/CommunityChat.API`
2. Cài package:
   ```bash
   dotnet restore
   dotnet build
   ```
3. Cấu hình **connection string**, JWT secret trong `appsettings.json`
4. Thực hiện migration và tạo DB nếu dùng EF Core
5. Chạy server:
   ```bash
   dotnet run
   ```

### Frontend

1. Vào thư mục `Frontend/`
2. Cài dependencies:
   ```bash
   npm install
   ```
3. Chỉnh URL API trong `src/services/*`
4. Chạy dev:
   ```bash
   npm run dev
   ```

Mở trình duyệt tại `http://localhost:3000` để kiểm tra ứng dụng.

---

## 🎯 Kế hoạch mở rộng

- Tích hợp upload file, emojis, reactions
- Thêm xác thực OAuth (Google, Facebook, GitHub)
- Tối ưu hiệu suất realtime bằng Redis backplane
- Phát triển ứng dụng mobile (React Native / Flutter)

---

## 📞 Liên hệ

Bạn có thể liên hệ qua GitHub hoặc email để trao đổi hoặc hợp tác phát triển.
