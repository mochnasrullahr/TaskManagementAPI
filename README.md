# Sistem Manajemen Tugas (Task Management API)

## Deskripsi

Aplikasi Sistem Manajemen Tugas ini adalah sebuah RESTful API yang dibangun menggunakan ASP.NET Core 9. API ini memungkinkan pengguna untuk membuat, melihat, memperbarui, dan menghapus tugas. 

## Fitur Utama

* **Manajemen Tugas:**
    * Membuat tugas baru dengan judul, deskripsi, tanggal jatuh tempo, dan status.
    * Melihat daftar semua tugas atau tugas tertentu berdasarkan ID.
    * Memperbarui detail tugas yang ada.
    * Menghapus tugas.
* **Autentikasi Pengguna:**
    * Registrasi pengguna baru (dibatasi untuk Admin).
    * Login pengguna untuk mendapatkan token JWT.
* **Otorisasi Berbasis Peran:**
    * Pembatasan akses ke endpoint berdasarkan peran pengguna (misalnya, hanya Admin yang dapat menghapus pengguna dan tugas terkait).
* **Penetapan Pembuat dan Penerima Tugas:**
    * Otomatis mencatat pembuat tugas berdasarkan token pengguna yang login.
    * Memungkinkan penetapan tugas kepada pengguna tertentu.

## Teknologi yang Digunakan

* **Backend:** ASP.NET Core API (.NET 9)
* **Autentikasi:** JWT (JSON Web Tokens)
* **Otorisasi:** Role-Based Authorization
* **ORM:** Entity Framework Core
* **Database:** SQL Server
* **Tools:** Visual Studio/VS Code, .NET CLI, Scalar/OpenAPI

## Cara Menjalankan Aplikasi

1.  **Prasyarat:**
    * .NET SDK (Software Development Kit) 
    * SQL server
    
2.  **Konfigurasi Database:**
    * Buka file `appsettings.json` dan sesuaikan `ConnectionStrings` dengan konfigurasi database Anda.

3.  **Migrasi Database:**
    * Dari command prompt atau powershell pada direktori aplikasi.
        ```bash
        dotnet ef database update
        ```

5.  **Menjalankan Aplikasi:**
    * Di command prompt atau powershell yang sama, jalankan perintah berikut:
        ```bash
        dotnet run
        ```
    * Aplikasi akan berjalan dan biasanya dapat diakses di `https://localhost:7116`.

## Endpoint API

Daftar endpoint dapat diakses pada `https://localhost:7116/openapi/v1.json`


**Catatan:** Ada endpoint yang memerlukan autentikasi token JWT yang valid di header `Authorization` dengan skema `Bearer` (contoh: `Authorization: Bearer <JWT_TOKEN>`).

## Desain Pattern yang Digunakan

* **RESTful API:** Resource-based architecture with a stateless server.
* **Dependency Injection (DI):** untuk memudahkan pengaturan dependensi.
* **Service Layer Pattern :** adanya `UserService`.
* **Bearer Token Authentication:** Menggunakan JWT untuk autentikasi stateless.

## Lifecycle Framework (ASP.NET Core)

* Aplikasi mengikuti lifecycle request pipeline dari ASP.NET Core, di mana setiap request diproses melalui serangkaian middleware yaitu routing, autentikasi, otorisasi, endpoint.
* Konfigurasi service dan middleware dilakukan di kelas `Program.cs`.
* Konfigurasi aplikasi dibaca dari `appsettings.json`.
* Dependency Injection container mengelola lifecycle objek yang terdaftar.

## Lisensi

MIT License

## Kontak

moch.nasrullah.r@gmail.com