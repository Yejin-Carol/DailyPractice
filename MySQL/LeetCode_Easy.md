## LeetCode Challenge Easy 

584. Find Customer Referee

![image](https://user-images.githubusercontent.com/81130006/175919550-18ab886a-cd3b-472e-97c4-af89edfc60fb.png)

SELECT name FROM Customer
WHERE referee_id  != 2 or referee_id IS NULL;


183. Customers Who Never Order

![image](https://user-images.githubusercontent.com/81130006/175920193-45a5fa8d-9667-4730-84b9-9019f0084b8a.png)

* My Answer
SELECT name AS 'Customers' FROM Customers
    WHERE NOT EXISTS (SELECT * FROM Orders
    WHERE Orders.customerId = Customers.id);

* Other's From Discussion (More Simple)
SELECT Name AS 'Customers' FROM Customers c LEFT JOIN Orders o ON c.Id = o.CustomerId WHERE o.CustomerId IS NULL

1873. Calculate Special Bonus
![image](https://user-images.githubusercontent.com/81130006/177058733-6c4fd249-d784-4462-9e2c-1464e4222027.png)
* CASE, ORDER BY 
SELECT employee_id,
(CASE 
    WHEN employee_id%2=1 AND name NOT LIKE 'M%' 
    THEN salary 
    ELSE 0
END) AS 'bonus'
FROM Employees ORDER BY employee_id;

* IF, ORDER BY
select employee_id , if(employee_id % 2 = 1 and name not like 'M%' , salary,0)  as bonus
from Employees ORDER BY employee_id ASC;
