# QRCodeGenerator

## 📌 Overview
QR Code Generator is a simple and efficient API that allows users to generate QR codes from text or valid URLs and download them as PNG images.  
The project is designed with a clean and maintainable structure, following best practices in software architecture and version control.

This repository serves as a foundational project showcasing technical skills, independent work, and structured project delivery.

---

## 🎯 Objectives
- Generate QR codes from user-provided text or URLs
- Allow users to download the QR code as an image
- Demonstrate clean architecture principles and professional project setup
- Serve as a portfolio-ready project

---

## ✅ Features
- Text / URL input
- QR code generation
- Download QR as PNG image

---

## 🛠 Tech Stack

### Backend
- .NET 8 Web API
- Clean Architecture (lightweight implementation)

### Tooling & Collaboration
- GitHub (Version Control)
- GitHub Projects (Backlog & task tracking)
- Remote development approach

---

## 🧱 Architecture
The project follows a clean and modular structure to ensure maintainability and scalability.

## Running the Project

1. Clone the repository

2. Navigate to the API project

3. Run the application

4. Open Swagger UI to test the endpoints

## API Endpoint

### Generate QR Code

**POST**

Generates a PNG QR code from a text or URL.

### Request Body
```json
{
  "input": "https://example.com"
}
```

### Response

Returns a PNG image.

### Example Request

curl -X POST "https://localhost:5001/api/qrcode
"
-H "Content-Type: application/json"
-d ""https://example.com\
""
--output qrcode.png

This will download the generated QR code as `qrcode.png`.

## Error Responses

### Empty Input

HTTP 400 Bad Request

This will download the generated QR code as `qrcode.png`.

## Running Tests

Run all unit tests with:

The test suite validates:

- QR code generation
- Input validation
- Response time
- Controller error responses
