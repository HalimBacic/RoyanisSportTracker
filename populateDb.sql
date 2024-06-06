use sporttracker;

INSERT INTO `SportTracker`.`User` (`Username`, `Password`, `Email`)
VALUES ('admin', SHA2('admin', 256), 'admin@sporttracker.com');

INSERT INTO `SportTracker`.`Activity` (`Name`, `Description`, `DateActivity`, `Duration`, `ActivityType_Id`, `User_Id`) VALUES
('Walking', 'Morning walk in the park', '2024-06-01', 30, 1, 9),
('HIIT', 'High-Intensity Interval Training', '2024-06-02', 20, 2, 9),
('Running', 'Evening run around the neighborhood', '2024-06-03', 45, 3, 9),
('Hiking', 'Hiking in the mountains', '2024-06-04', 120, 4, 9),
('Swimming', 'Swimming at the local pool', '2024-06-05', 60, 5, 9),
('Etc', 'Miscellaneous physical activities', '2024-06-06', 40, 6, 9),
('Biking', 'Biking along the river', '2024-06-07', 90, 7, 9),
('Workout', 'Strength training at the gym', '2024-06-08', 75, 8, 9),
('Walking', 'Evening walk to relax', '2024-06-09', 35, 1, 9);

INSERT INTO `SportTracker`.`User_has_target` (`User_Id`, `ActivityType_Id`, `DateActivity`, `Type`, `Count`, `Target`) VALUES
(9, 1, '2024-06-01', 'TimePerDay', 30, 60),
(9, 2, '2024-06-02', 'DurationPerDay', 45, 90),
(9, 3, '2024-06-03', 'TimePerDay', 60, 120),
(9, 1, '2024-06-04', 'DurationPerDay', 75, 100),
(9, 2, '2024-06-05', 'TimePerDay', 90, 150);

