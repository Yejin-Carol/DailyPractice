## LeetCode Challenge Easy 

* DAY1_220627

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

