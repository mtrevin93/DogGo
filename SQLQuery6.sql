                                      SELECT d.Id AS DogId, d.Name AS DogName, Breed, o.Id AS OwnerId
                                      FROM DOG d
                                      JOIN Owner o ON D.OwnerId = o.Id
                                      WHERE d.Id = 1