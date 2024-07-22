import random
from datetime import datetime, timedelta
from locust import HttpUser, task, between

class MyLoadTestUser(HttpUser):
    wait_time = between(1, 5)
    host = "http://nginx"  # Acesse os servi�os atrav�s do Nginx

    @task(1)
    def create_transaction(self):
        amount = random.uniform(1.0, 1000.0)  # Valor aleat�rio entre 1 e 1000
        transaction_type = random.choice(["Credit", "Debit"])  # Tipo aleat�rio entre Cr�dito e D�bito
        
        # Data aleat�ria dentro dos �ltimos 30 dias
        start_date = datetime.now() - timedelta(days=30)
        random_date = start_date + timedelta(days=random.randint(0, 30))
        transaction_date = random_date.strftime('%Y-%m-%dT%H:%M:%S')
        
        # Dados da transa��o
        transaction_data = {
            "Amount": amount,
            "Type": transaction_type,
            "Date": transaction_date
        }
        # Envia a requisi��o POST para criar a transa��o
        self.client.post(f"http://localhost:8080/api/transactions", json=transaction_data)

    @task(1)
    def get_consolidated(self):
        # Envia a requisi��o GET para obter consolidados para uma data espec�fica
        self.client.get(f"http://localhost:8080/api/consolidated?date=2024-07-18")

if __name__ == "__main__":
    import os
    os.system("locust -f locustfile.py --host=http://nginx --web-host=0.0.0.0 --web-port=8080")
