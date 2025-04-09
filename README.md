# DeviceHub

**DeviceHub** is a full-stack application built with **Blazor** for the frontend and **ASP.NET Core** for the backend. It provides a REST API for managing devices and their measurements, along with a Blazor-based UI for interacting with the data.

---

## Features

### REST API
The backend exposes a REST API for managing devices and their measurements. Key features include:
- Adding new device records.
- Fetching a list of all devices.
- Retrieving measurements for a specific device.
- Counting the number of measurements for a device.

### Blazor UI
The frontend is built with Blazor and provides:
- A search interface for querying device measurements.
- A results section to display measurements.
- Loading indicators and error handling for a smooth user experience.

---

## Stack Used

### Frontend
- **Blazor**: Interactive UI framework for building web applications with C#.
- **Bootstrap**: For styling and responsive design.

### Backend
- **ASP.NET Core**: For building the REST API.
- **ConcurrentDictionary**: Used for thread-safe storage of device data.
- **System.Text.Json**: For JSON serialization and deserialization.

### Tools
- **C#**: Primary programming language.
- **Visual Studio Code**: Recommended IDE for development.
- **Postman**: For testing REST API endpoints.

---

## REST API Documentation

### Base URL

http://localhost:5293/api

### Endpoints

#### 1. Add a Record
- **URL**: `/add-record`
- **Method**: `POST`
- **Request Body**:
  ```json
  {
    "name": "Device1",
    "measurements": {
      "data": {
        "payload": "Sample payload data"
      }
    }
  }
  ```
- **Response**:
  - `200 OK`: Record added successfully.
  - `400 Bad Request`: Invalid request payload or measurement data.

#### 2. Get All Devices
- **URL**: `/devices`
- **Method**: `GET`
- **Response**:
  - `200 OK`: List of device names.
    ```json
    ["Device1", "Device2"]    ```


#### 3. Get Measurement Count for a Device
- **URL**: `/devices-count?deviceName={deviceName}` /devices-count?device?deviceName=Device1
- **Method**: `GET`
- **Response**:
  - `200 OK`: Count of measurements.
    ```json
    5
    ```
  - `404 Not Found`: Device not found.

---

## Blazor UI Documentation

### Pages

#### 1. DeviceHub Page
- **Path**: `/`
- **Features**:
  - Search bar for querying device measurements.
  - Results section to display measurements.
  - Loading indicator while fetching data.
  - Error handling for invalid queries.

#### 2. Search Functionality
- **Input Field**: Binds to `_searchQuery`.
- **Search Button**: Triggers the `GetMeasurements` method to fetch data from the backend.
- **Enter Key**: Also triggers the search functionality.

---

## How to Run

### Prerequisites
- .NET SDK installed (version 8.0 or later).
- A modern web browser.

### Steps
1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd DeviceHub
   ```
2. Build and run the application:
   ```bash
   dotnet build
   dotnet run
   ```
3. Open your browser and navigate to:
   ```
   http://localhost:5293
   ```

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
