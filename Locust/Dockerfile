 
FROM python:3.9-slim
 
RUN apt-get update && apt-get install -y \
    gcc \
    libpq-dev \
    && apt-get clean

 
WORKDIR /app

  
COPY /Locust/locustfile.py /app/locustfile.py
 
RUN pip install locust

 
CMD ["locust", "-f", "locustfile.py"]
