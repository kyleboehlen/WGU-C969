INSERT IGNORE INTO country (countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy)
VALUES 
    (1, 'US', @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (2, 'Canada', @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (3, 'Norway', @seedDate, @createdBy, @seedDate, @lastUpdatedBy);

INSERT IGNORE INTO city (cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy)
VALUES 
    (1, 'New York', 1, @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (2, 'Los Angeles', 1, @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (3, 'Toronto', 2, @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (4, 'Vancouver', 2, @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (5, 'Oslo', 3, @seedDate, @createdBy, @seedDate, @lastUpdatedBy);

INSERT IGNORE INTO address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)
VALUES 
    (1, '123 Main', '', 1, '11111', '555-1212', @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (2, '123 Elm', '', 3, '11112', '555-1213', @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (3, '123 Oak', '', 5, '11113', '555-1214', @seedDate, @createdBy, @seedDate, @lastUpdatedBy);

INSERT IGNORE INTO customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
VALUES 
    (1, 'John Doe', 1, 1, @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (2, 'Alfred E Newman', 2, 1, @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (3, 'Ina Prufung', 3, 1, @seedDate, @createdBy, @seedDate, @lastUpdatedBy);

INSERT IGNORE INTO appointment (appointmentId, customerId, userId, title, description, location, contact, type, url, start, `end`, createDate, createdBy, lastUpdate, lastUpdateBy)
VALUES 
    (1, 1, 1, @notNeeded, @notNeeded, @notNeeded, @notNeeded, 'Presentation', @notNeeded, @seedDate, @seedDate, @seedDate, @createdBy, @seedDate, @lastUpdatedBy),
    (2, 2, 1, @notNeeded, @notNeeded, @notNeeded, @notNeeded, 'Scrum', @notNeeded, @seedDate, @seedDate, @seedDate, @createdBy, @seedDate, @lastUpdatedBy);