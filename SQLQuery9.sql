SELECT * FROM Walks

SELECT w.Date, w.Duration, wr.Name AS WalkerName, d.Name AS DogName
FROM Walks w
JOIN Walker wr ON w.WalkerId = wr.Id
JOIN Dog d ON d.Id = w.DogId

SELECT * FROM Dog

SELECT * From Dog