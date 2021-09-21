                        SELECT o.Id AS OwnerId, o.[Name], o.Email, o.[Address], o.Phone, 
                        n.Name AS NeighborhoodName, n.Id AS NeighborhoodId,
                        d.Name AS DogName, d.Breed, d.Id AS DogId
                        FROM Owner o
                        LEFT JOIN Neighborhood n
                        ON o.NeighborhoodId = n.Id
                        LEFT JOIN Dog d 
                        ON d.OwnerId = o.Id
                        WHERE o.Id = 8

                        SELECT * FROM OWNER WHERE Owner.Id = 8