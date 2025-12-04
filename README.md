Unified API Response Architecture (ASP.NET Minimal API + Next.js)

This repository demonstrates a production-ready, fully typed **Unified API Response System**  
for projects using **ASP.NET Minimal API** on the backend and **Next.js** on the frontend.

It solves common problems with API consistency, error handling, validation, and frontend–backend synchronization — while keeping the developer experience clean and strongly typed.

---

# Features

### Unified API response format across the whole backend  
All endpoints return a consistent structure through `ApiResponse<T>`:

- `success`
- `errorCode`
- `message`
- `data`
- `validationErrors` (when needed)

No HTML errors, no raw exceptions — everything is structured JSON.

---

### Strongly typed `ErrorCode` enum (C# → TypeScript autogeneration)
Forget about magic strings and typos like `"UNAUHORIZED"`.

- Backend defines `ErrorCode.cs` (enum)
- Frontend imports generated `errorCodes.ts`
- Fully type-safe error handling
- No mismatch between backend and frontend — ever

---

### Centralized error handling (middleware)
The backend includes:

- Global exception handler (500 → structured JSON)
- Authorization handler for:
  - `401 Unauthorized`
  - `403 Forbidden`
  - `404 Not Found`
- Automatic validation response

Zero duplicated try/catch blocks.

---

### Strongly Typed ApiError class (frontend)
Frontend wraps API errors via custom `ApiError`, allowing:

- consistent error handling
- IDE autocomplete for `error.errorCode`, `error.validationErrors`
- easy integration with React Hook Form, React Query, SWR, etc.

---

### Validation errors with field-level details
Backend returns:

```json
{
  "success": false,
  "errorCode": "ValidationError",
  "message": "Validation failed",
  "validationErrors": [
    { "field": "email", "message": "Email is required" },
    { "field": "password", "message": "Password must be at least 6 characters" }
  ]
}
