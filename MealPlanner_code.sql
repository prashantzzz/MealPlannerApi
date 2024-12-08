SELECT name,state_desc FROM sys.databases;
ALTER DATABASE MealPlannerDb SET ONLINE;

DBCC CHECKDB(MealPlannerDb) WITH NO_INFOMSGS;

create database MealPlannerDb
use MealPlannerDb
-- Users Table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(20) NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    Role NVARCHAR(20) NOT NULL,
    Email NVARCHAR(30) NOT NULL,
    PhoneNumber NVARCHAR(12),
    IsActive BIT NOT NULL
);

-- For assigning users to nutritionist and neutrisionist to chef
CREATE TABLE AssignedUsers (
    UserRoleId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    NutriId INT NOT NULL,
    ChefId INT NOT NULL,
	PlannerId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (NutriId) REFERENCES Users(UserId),
    FOREIGN KEY (ChefId) REFERENCES Users(UserId),
	FOREIGN KEY (PlannerId) REFERENCES Users(UserId)
);

-- Recipes Table
CREATE TABLE Recipes (
    RecipeId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(20) NOT NULL,
    Category NVARCHAR(15),
    Ingredients NVARCHAR(MAX),
    PreparationSteps INT,
    CookingTime INT,
    Servings INT,
    NutritionalInfo NVARCHAR(MAX)
);

-- CookingInstructions Table
CREATE TABLE CookingInstructions (
    InstructionId INT IDENTITY(1,1) PRIMARY KEY,
    RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes(RecipeId),
    StepNumber INT NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    EquipmentNeeded NVARCHAR(100)
);

-- MealPlans Table
CREATE TABLE MealPlans (
    MealPlanId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    MealType NVARCHAR(15) NOT NULL,
    RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes(RecipeId)
);

-- ShoppingList Table
CREATE TABLE ShoppingLists (
    ShoppingListId INT IDENTITY(1,1) PRIMARY KEY,
    MealPlanId INT NOT NULL FOREIGN KEY REFERENCES MealPlans(MealPlanId),
    IngredientName NVARCHAR(20) NOT NULL,
    Quantity FLOAT,
    Status NVARCHAR(10)
);

-- Nutrition Table
CREATE TABLE Nutrition (
    NutritionId INT IDENTITY(1,1) PRIMARY KEY,
    RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes(RecipeId),
    Calories INT,
    Protein FLOAT,
    Carbs FLOAT,
    Fat FLOAT,
    Vitamins NVARCHAR(MAX)
);

-- DietaryPreferences Table
CREATE TABLE DietaryPreferences (
    PreferenceId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    PreferenceType NVARCHAR(30) NOT NULL,
    Description NVARCHAR(MAX)
);

-- Reviews Table
CREATE TABLE Reviews (
    ReviewId INT IDENTITY(1,1) PRIMARY KEY,
    RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes(RecipeId),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    ReviewText NVARCHAR(MAX),
    ReviewDate DATE NOT NULL
);

-- Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

-- Subscriptions Table
CREATE TABLE Subscriptions (
    SubscriptionId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    SubscriptionType NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE,
    PaymentStatus NVARCHAR(50) NOT NULL
);

-- Reports Table
CREATE TABLE Reports (
    ReportId INT IDENTITY(1,1) PRIMARY KEY,
    ReportType NVARCHAR(50) NOT NULL,
    GeneratedDate DATE NOT NULL,
    Data NVARCHAR(MAX),
    CreatedBy NVARCHAR(50) NOT NULL
);

-- MealPrep Table
CREATE TABLE MealPrep (
    MealPrepId INT IDENTITY(1,1) PRIMARY KEY,
    RecipeId INT NOT NULL FOREIGN KEY REFERENCES Recipes(RecipeId),
    PortionSize NVARCHAR(50),
    IngredientsRequired NVARCHAR(MAX),
    PrepTime INT
);

-- Users table with different roles
select * from users
delete from users where userid>13;
INSERT INTO Users (Username, PasswordHash, Role, Email, PhoneNumber, IsActive) VALUES
('Admin1',		 '$2a$10$EjzloHBAOb0zkw8vhIz0Tey.uyg53xdHfEWnC9zTdcfBTXK0HVd7u', 'Admin',		'admin1@example.com',	'8271934652', 1),
('Chef1',		 '$2a$10$50dpGZFDq/G50Q4moaXXluJ9MbOmCFbviNP3UF1GUcXm.uyEUjcJm', 'Chef',		'chef1@example.com',	'9865457820', 1),
('Nutritionist1','$2a$10$.7DZQE3WTvoszyCudjVPfuxoFEirJbcEaWY/V1LhVwGatV53S2d3m', 'Nutritionist','nutri1@example.com',	'7812569663', 1),
('Mealplanner1', '$2a$10$uTtr5O22cCCJv.Pvsqo3AOXX2bzrR89/HZze1z1z5mCmtpO6pf3AS', 'MealPlanner',	'planner1@example.com', '7578125689', 1),
('Chef2',		 '$2a$10$50dpGZFDq/G50Q4moaXXluJ9MbOmCFbviNP3UF1GUcXm.uyEUjcJm', 'Chef',		'chef2@example.com',	'9865457820', 1),
('Nutritionist2','$2a$10$.7DZQE3WTvoszyCudjVPfuxoFEirJbcEaWY/V1LhVwGatV53S2d3m', 'Nutritionist','nutri2@example.com',	'7812569663', 1),
('Mealplanner2', '$2a$10$uTtr5O22cCCJv.Pvsqo3AOXX2bzrR89/HZze1z1z5mCmtpO6pf3AS', 'MealPlanner',	'planner2@example.com', '7578125689', 1),
('Prashant',	 '$2a$10$rtsdSo8xXzL7t0TMrMiU8enxvzOYRwldtF2dnIlZ0HeHcm2lyKDd2', 'Customer',	'piru7399@gmail.com',	'8956231245', 1),
('Yash',		 '$2a$10$rtsdSo8xXzL7t0TMrMiU8enxvzOYRwldtF2dnIlZ0HeHcm2lyKDd2', 'Customer',	'yash@example.com',		'9956231245', 1),
('Atharv',		 '$2a$10$rtsdSo8xXzL7t0TMrMiU8enxvzOYRwldtF2dnIlZ0HeHcm2lyKDd2', 'Customer',	'atharv@example.com',	'7956231245', 0),
('Ayaan',		 '$2a$10$rtsdSo8xXzL7t0TMrMiU8enxvzOYRwldtF2dnIlZ0HeHcm2lyKDd2', 'Customer',	'ayaan@example.com',	'8953231245', 1),
('Yashi',		 '$2a$10$rtsdSo8xXzL7t0TMrMiU8enxvzOYRwldtF2dnIlZ0HeHcm2lyKDd2', 'Customer',	'yashi@example.com',	'9856291245', 1),
('Ansh',		 '$2a$10$rtsdSo8xXzL7t0TMrMiU8enxvzOYRwldtF2dnIlZ0HeHcm2lyKDd2', 'Customer',	'ansh@example.com',		'7458231245', 0);


INSERT INTO AssignedUsers (UserId, NutriId, ChefId, PlannerId)
VALUES (5,3,2,4),(6,12,11,13);
select * from AssignedUsers;

-- Insert 5 rows into Recipes table
select * from recipes;
INSERT INTO Recipes (Name, Category, Ingredients, PreparationSteps, CookingTime, Servings, NutritionalInfo) VALUES
('Omelette',    'Breakfast',    'Eggs,      Milk,       Salt,       Pepper', 3, 10, 1, 'Protein-rich'),
('Pasta',       'Lunch',        'Pasta,     Tomato Sauce,      Cheese', 4, 30, 2, 'Carb-rich'),
('Grilled Chicken','Dinner',   'Chicken,   Spices,      Olive Oil', 5, 40, 3, 'High Protein'),
('Salad',       'Snacks',       'Lettuce,   Tomato,     Cucumber,   Dressing', 3, 10, 1, 'Low Calorie'),
('Smoothie',    'Breakfast',    'Milk,      Banana,     Berries',   4, 5, 1,    'Vitamins and Minerals');

-- MealPlans table
INSERT INTO MealPlans (UserId, StartDate, EndDate, MealType, RecipeId) VALUES
(5, '2024-12-01', '2024-12-07', 'Breakfast', 1),
(6, '2024-12-01', '2024-12-14', 'Lunch', 2),
(5, '2024-12-01', '2024-12-07', 'Dinner', 3),
(6, '2024-12-01', '2024-12-14', 'Snacks', 4),
(7, '2024-12-01', '2024-12-10', 'Dinner', 3),
(8, '2024-12-01', '2024-12-14', 'Snacks', 4),
(9, '2024-12-01', '2024-12-07', 'Breakfast', 5),
(10, '2024-12-01', '2024-12-21', 'Breakfast', 5);

-- Insert 5 rows into ShoppingList table
INSERT INTO ShoppingList (MealPlanId, IngredientName, Quantity, Status) VALUES
(1, 'Eggs', '6 pcs', 'Pending'),
(2, 'Pasta', '200 gm', 'Pending'),
(3, 'Chicken', '500 gm', 'Pending'),
(4, 'Lettuce', '1 bunch', 'Purchased'),
(5, 'Milk', '500 ml', 'Pending');

-- Nutrition table
INSERT INTO Nutrition (RecipeId, Calories, Protein, Carbs, Fat, Vitamins) VALUES
(1, 200, 12.5, 1.5, 15, 'Vitamin D'),
(2, 350, 10, 50, 12, 'Vitamin B'),
(3, 500, 45, 0, 25, 'Iron'),
(4, 150, 2, 10, 5, 'Vitamin C'),
(5, 250, 8, 40, 3, 'Antioxidants');

-- DietaryPreferences table
INSERT INTO DietaryPreferences (UserId, PreferenceType, Description) VALUES
(5, 'Vegetarian', 'No meat, fish, or poultry'),
(6, 'Gluten-Free', 'No wheat or gluten products'),
(7, 'Keto', 'Low-carb, high-fat diet'),
(8, 'Vegan', 'No animal products'),
(9, 'Pescatarian', 'Includes fish but no other meat');

-- CookingInstructions table
INSERT INTO CookingInstructions (RecipeId, StepNumber, Description, EquipmentNeeded) VALUES
(1, 1, 'Crack the eggs into a bowl and add milk. Whisk until combined.', 'Bowl, Whisk'),
(1, 2, 'Heat a non-stick pan over medium heat.', 'Non-stick pan, Stove'),
(1, 3, 'Pour the egg mixture into the pan and cook until set.', 'Spatula, Stove'),

(2, 1, 'Bring a large pot of water to boil and add salt.', 'Pot, Stove'),
(2, 2, 'Add the pasta and cook until al dente, then drain.', 'Pot, Colander'),
(2, 3, 'Heat the tomato sauce in a pan.', 'Pan, Stove'),
(2, 4, 'Mix the drained pasta with the sauce and serve hot.', 'Pan, Serving spoon'),

(3, 1, 'Marinate the chicken with spices and olive oil.', 'Bowl'),
(3, 2, 'Preheat the grill to medium-high heat.', 'Grill'),
(3, 3, 'Place the chicken on the grill and cook each side for 5-7 minutes.', 'Grill tongs'),
(3, 4, 'Check the internal temperature to ensure it is fully cooked (165�F).', 'Meat thermometer'),
(3, 5, 'Remove from the grill and let rest for 5 minutes before serving.', 'Plate'),

(4, 1, 'Wash and chop lettuce, tomato, and cucumber.', 'Knife, Cutting board'),
(4, 2, 'Place the vegetables in a large bowl.', 'Bowl'),
(4, 3, 'Add dressing and toss to combine.', 'Serving spoon'),

(5, 1, 'Peel and chop the banana.', 'Knife, Cutting board'),
(5, 2, 'Add milk, banana, and berries to a blender.', 'Blender'),
(5, 3, 'Blend until smooth and creamy.', 'Blender'),
(5, 4, 'Pour into a glass and serve immediately.', 'Glass');


-- Reviews table
INSERT INTO Reviews (RecipeId, UserId, Rating, ReviewText, ReviewDate) VALUES
(1, 5, 5, 'Easy and delicious!', '2024-10-30'),
(1, 6, 4, 'Quick and tasty, perfect for breakfast.', '2024-11-15'),
(1, 7, 3, 'Good, but too basic for my taste.', '2024-12-01'),

(2, 6, 4, 'Tasty but needed more cheese.', '2024-09-30'),
(2, 8, 5, 'Loved the flavor! Will make it again.', '2024-11-10'),
(2, 9, 4, 'Great pasta, but could use a bit more seasoning.', '2024-12-05'),

(3, 7, 5, 'Perfect for dinner!', '2024-12-03'),
(3, 8, 4, 'Very flavorful, but a little dry.', '2024-11-22'),
(3, 9, 5, 'Juicy and tender, the best grilled chicken!', '2024-11-25'),
(3, 5, 5, 'Best chicken item!', '2024-11-25'),

(4, 8, 3, 'Healthy but bland.', '2024-11-30'),
(4, 9, 4, 'Simple but fresh and tasty.', '2024-12-02'),
(4, 10, 3, 'It was okay, a bit too plain for me.', '2024-12-05'),

(5, 9, 4, 'Quick and refreshing.', '2024-11-30'),
(5, 10, 5, 'Delicious and healthy, a perfect morning boost!', '2024-11-20'),
(5, 6, 4, 'Great flavor, but I wish it was a bit thicker.', '2024-12-01');

-- Subscriptions table
INSERT INTO Subscriptions (UserId, SubscriptionType, StartDate, EndDate, PaymentStatus) VALUES
(5, 'Basic', '2024-12-01', '2025-12-01', 'Paid'),
(6, 'Premium', '2024-12-01', '2025-12-01', 'Paid'),
(7, 'Basic', '2024-12-01', '2025-12-01', 'Pending'),
(8, 'Premium', '2024-12-01', '2025-12-01', 'Paid'),
(9, 'Basic', '2024-12-01', '2025-12-01', 'Paid');

-- Reports table with mock data
INSERT INTO Reports (ReportType, GeneratedDate, Data, CreatedBy) VALUES
('Users', '2024-11-30', 'Active: 8, Inactive: 2', 'Admin1'),
('Recipes', '2024-11-30', '5', 'Admin1'),
('Average Recipe Rating', '2024-11-30', 'Recipe ID 1: 4.5, Recipe ID 2: 3.5, Recipe ID 3: 4.2, Recipe ID 4: 4.4, Recipe ID 5: 4', 'Admin1'),
('Meal Plan Count by User', '2024-11-30', 'User 5: 2 meal plan, User 6: 2 meal plan, User 7: 1 meal plan, User 8: 1, User 9: 1', 'Admin1'),
('Subscription Types', '2024-11-30', 'Premium: 3, Basic: 2', 'Admin1'),
('Most Popular Recipe', '2024-11-30', 'Recipe ID 3: Grilled Chicken with 4 reviews', 'Admin1');

-- MealPrep table
INSERT INTO MealPrep (RecipeId, PortionSize, IngredientsRequired, PrepTime) VALUES
(1, '1 Serving', 'Eggs: 2 pcs, Milk: 50 ml, Salt: 3 gm, Pepper: 5 gm', 15),
(2, '2 Servings', 'Pasta: 200 gm, Sauce: 100 ml, Cheese: 50 gm', 30),
(3, '3 Servings', 'Chicken: 500 gm, Spices: 10 gm, Olive Oil: 10 ml', 40),
(4, '1 Serving', 'Lettuce: 1 cup, Tomato: 100 gm, Cucumber: 100gm, Dressing: 10 ml', 10),
(5, '1 Serving', 'Milk: 100 ml, Banana: 1, Berries: 50 gm', 5);
