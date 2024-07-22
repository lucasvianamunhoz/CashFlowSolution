

# Cashflow Microservices Project

## Overview

This project consists of two microservices developed in .NET 8.0 to manage financial transactions and generate daily consolidated reports. We use a microservices architecture, with SQL Server for the database and Redis for caching.

## Technologies Used

- **.NET 8.0**: Framework for developing microservices.
- **Entity Framework Core**: ORM for accessing the SQL Server database.
- **MediatR**: Implementation of the CQRS pattern.
- **Polly**: Library for resilience and retry policies.
- **Redis**: Distributed cache.
- **SQL Server**: Relational database.
- **NGINX**: Reverse proxy for load balancing.
- **Docker**: Platform for developing, shipping, and running applications in containers.

## Architecture

### Architecture Diagram

    +---------------+
    |      NGINX    |
    +-------+-------+
            |
    +-------+-------+
    |               |
    +---------+-----+   +-------+---------+
    |TransactionService|   |ConsolidatedService|
    +------------------+   +------------------+
            |                       |
    +-------+-------+       +-------+-------+
    |  SQL Server  |       | Redis Cache  |
    +---------------+       +---------------+

## How to Run the Project

### Prerequisites

- Docker: Install Docker

### Steps to Download and Run

1. Clone the repository:

    ```bash
    git clone <repository-url>
    cd Cashflow
    ```

2. Build and start the containers:

    ```bash
    docker-compose build
    docker-compose up
    ```

### Usage

#### 1. Create a Transaction

**Endpoint:** `POST /api/transactions`

**Command:**

    
    curl --location --request POST 'http://localhost/api/transactions' \
    --header 'Content-Type: application/json' \
    --data-raw '{
        "amount": 100,
        "type": "Credit"
    }'
 

#### 2. Get Daily Consolidated Report

**Endpoint:** `GET /api/consolidated`

**Command:**

 
    curl --location --request GET 'http://localhost/api/consolidated?date=2024-07-18' \
    --header 'Content-Type: application/json'
 
