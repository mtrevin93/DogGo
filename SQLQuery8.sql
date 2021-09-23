SELECT * FROM Owner

SELECT * FROM Walker

SELECT * FROM Dog

SELECT * From Walks

                        SELECT wr.Id, wr.[Name], wr.ImageUrl, wr.NeighborhoodId,
                        w.Date, w.Duration,
                        o.Name
                        FROM Walker wr
                        LEFT JOIN Walks w ON w.WalkerId = wr.Id
                        LEFT JOIN Dog d on w.DogId = d.Id
                        LEFT JOIN Owner o on d.OwnerId = o.Id
                        WHERE wr.Id = 1