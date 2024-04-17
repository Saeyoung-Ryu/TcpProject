import redis
from tabulate import tabulate

# Connect to Redis
r = redis.StrictRedis(host='localhost', port=6379, db=0)

# Get all keys and their values
keys = r.keys('*')
data = []

for key in keys:
    value = r.get(key)
    data.append([key.decode('utf-8'), value.decode('utf-8')])

# Display data as table
print(tabulate(data, headers=['Key', 'Value'], tablefmt='grid'))
