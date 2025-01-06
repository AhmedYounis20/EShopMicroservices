# 🌐 E-Commerce Microservices Application 🛒

Welcome to the **E-Commerce Microservices Platform** built with **.NET 8**! This project demonstrates a scalable, event-driven, and maintainable architecture for an e-commerce system using modern technologies and best practices like **Clean Architecture**, **Onion Architecture**, and **Microservices**.

## 🚀 Technologies Used

![dotnet](https://img.shields.io/badge/.NET-8-512BD4?logo=.net&logoColor=white)  
![docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=white)  
![grpc](https://img.shields.io/badge/gRPC-7A4C37?logo=grpc&logoColor=white)  
![redis](https://img.shields.io/badge/Redis-DC382D?logo=redis&logoColor=white)  
![rabbitmq](https://img.shields.io/badge/RabbitMQ-FF6600?logo=rabbitmq&logoColor=white)  
![postgresql](https://img.shields.io/badge/PostgreSQL-336791?logo=postgresql&logoColor=white)  
![mssql](https://img.shields.io/badge/MSSQL-CC2927?logo=microsoft-sql-server&logoColor=white)  
![sqlite](https://img.shields.io/badge/SQLite-003B57?logo=sqlite&logoColor=white)  
![fluentvalidation](https://img.shields.io/badge/FluentValidation-71B72B?logo=fluent&logoColor=white)  
![mediatr](https://img.shields.io/badge/MediatR-00A9E0?logo=mediatr&logoColor=white)  
![mapster](https://img.shields.io/badge/Mapster-6D89A6?logo=mapster&logoColor=white)  

This project utilizes the following technologies to build a fully-featured E-commerce platform:

- **.NET 8** for backend development
- **Microservices Architecture** for modular services
- **Onion & Clean Architecture** to ensure maintainability
- **gRPC** for high-performance communication between services
- **Redis** for caching and session storage
- **RabbitMQ** for event-driven communication
- **FluentValidation** for input validation
- **MediatR** to implement **CQRS** (Command Query Responsibility Segregation)
- **Mapster** for object mapping
- **SQL Server (MSSQL)**, **PostgreSQL**, and **SQLite** for data storage
- **Docker** for containerizing microservices
- **Health Checks** to monitor service availability
- **Vertical Slice Architecture** for better organization

## 🏗️ Project Structure

### **Services:**

1. **Discount Service**  
   🛍️ Implements **gRPC** communication and uses **SQLite** for data persistence. Provides discounts to other services.

2. **Basket Service**  
   🛒 Leverages **Redis** for caching and implements **CQRS** with the **Mediator pattern**. Communicates asynchronously via **RabbitMQ**.

3. **Catalog Service**  
   🏷️ Built with **Vertical Slice Architecture** and **PostgreSQL**. Implements data seeding and global exception handling for robust error management.

4. **Ordering Service**  
   🧾 Implements **Onion Architecture**, utilizes **RabbitMQ** for event-driven communication, and includes **Health Checks** for service monitoring.

### **Key Features:**

- **🔄 Event-Driven Architecture**: Asynchronous communication via **RabbitMQ** for improved scalability and decoupling between services.
- **⚡ gRPC Communication**: Fast, efficient communication between services.
- **🏗️ Clean Architecture**: Ensures clear separation of concerns and maintainable code.
- **📈 CQRS Pattern**: Handles command and query operations separately, optimizing system performance.
- **🛠️ Dockerized Services**: All services are containerized using **Docker** for easy deployment and scaling.
- **🔒 Service Resilience**: Integrated **health checks**, **logging**, and **error handling** to ensure the system’s robustness.
- **🔄 Cross-Cutting Concerns**: Handles repetitive tasks like logging, validation, etc., across all services.
- **🚀 Minimal APIs** for efficient communication.

## 📝 Setup Instructions

To run the project locally or in a containerized environment, follow these steps:

### **Prerequisites:**

- **Docker** 🐳 (for containerized services)
- **.NET 8 SDK** 🔧
- **PostgreSQL** 🐘, **SQL Server (MSSQL)**, or any relational database
- **RabbitMQ** 🐇
- **Redis** 🧑‍💻
- **gRPC tools** 🔨

### **Steps to Run Locally:**

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/ecommerce-microservices.git
   ```

2. Navigate to the project directory:
   ```bash
   cd ecommerce-microservices
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Set up the databases (PostgreSQL, SQL Server, SQLite). Ensure connection strings are configured in each service's `appsettings.json`.

5. Start the services using Docker:
   ```bash
   docker-compose up
   ```

   This will start all microservices along with **RabbitMQ**, **Redis**, and the databases in Docker containers.

6. Alternatively, run each service locally:
   ```bash
   dotnet run --project BasketService
   dotnet run --project CatalogService
   dotnet run --project DiscountService
   dotnet run --project OrderingService
   ```

### **Test the Services:**

- Use tools like **Postman** or **Swagger** to interact with the API endpoints.
- Event-driven features can be tested by triggering events in one service and observing the responses of other services via **RabbitMQ**.

## 💡 Design Decisions

### **Onion and Clean Architecture**  
This project follows the principles of **Onion Architecture** and **Clean Architecture** to ensure that business logic remains independent of external frameworks. The core business logic is isolated at the center of the architecture.

### **CQRS & Mediator Pattern**  
The **CQRS** pattern is used to separate the command (write) and query (read) operations. This helps improve performance and scalability, while the **Mediator Pattern** simplifies the implementation of the CQRS logic.

### **Event-Driven Communication**  
By using **RabbitMQ** for event-driven communication, services are loosely coupled and can scale independently.

### **Service Resilience & Monitoring**  
With built-in **health checks**, **logging**, and **global exception handling**, this system is designed to remain robust and maintainable.

## 🔮 Future Improvements

- **💻 Frontend Integration:** Integrate with a frontend framework such as **React** or **Angular** for a complete end-to-end solution.
- **🛠️ CI/CD Pipeline:** Set up a continuous integration and delivery pipeline for automated testing and deployment.
- **📜 API Documentation:** Integrate **Swagger/OpenAPI** to document and test the APIs.
- **🔐 Authentication & Authorization:** Implement **OAuth2** or **JWT** for securing the APIs.

## 📢 Conclusion

This project demonstrates how to build a **microservices-based E-commerce platform** using **.NET 8** and modern technologies. By incorporating **Clean Architecture**, **CQRS**, **gRPC**, **Redis**, and other tools, the system is highly maintainable, scalable, and robust.
