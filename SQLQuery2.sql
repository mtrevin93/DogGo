                        SELECT o.Id AS OwnerId, o.[Name], o.Email, o.[Address], o.Phone, n.Id AS NeighborhoodId
                        FROM Owner o
                        JOIN Neighborhood n
                        ON o.NeighborhoodId = n.Id
                        WHERE o.Id = 1